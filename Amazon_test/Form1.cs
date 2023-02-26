using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Amazon_test
{
    public partial class ProductListForm : Form
    {
        public static string itemID = null;
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.myDataSet.Products);

        }

        private static string[] GetExcelSheetNames(string oleConnectionString)
        {
            using (OleDbConnection oleConnection = new OleDbConnection(oleConnectionString))
            {
                oleConnection.Open();
                DataTable dataTable = oleConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dataTable == null)
                {
                    return null;
                }
                else
                {
                    String[] excelSheetNames = new String[dataTable.Rows.Count];
                    int i = 0;

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        excelSheetNames[i] = dataRow["TABLE_NAME"].ToString();
                        i++;
                    }
                    dataTable.Dispose();
                    return excelSheetNames;
                }
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //SQL connection preparation
                SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.sqlConnectionString);

                //OLE connection and data reading preparation
                string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + openFileDialog1.FileName + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
                string oleQueryString = string.Format("SELECT * FROM [{0}]", GetExcelSheetNames(excelConnectionString)[0]); //Setting the first Excel sheet as source of data
                OleDbDataReader oleDbData = null;
                OleDbConnection oleConnection = new OleDbConnection(excelConnectionString);
                OleDbCommand oleDbCommand = new OleDbCommand(oleQueryString, oleConnection);

                try
                {   //SQL connection
                    sqlConnection.Open();

                    //OLE connection and data reading
                    oleConnection.Open();
                    oleDbData = oleDbCommand.ExecuteReader();

                    //Load data into SQL Server table                        
                    using (SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnection))
                    {
                        sqlBulk.DestinationTableName = "Products";

                        //Mapping database table columns with Excel table columns
                        sqlBulk.ColumnMappings.Add("Артикул", "Article");
                        sqlBulk.ColumnMappings.Add("[Наименование товара]", "Name");
                        sqlBulk.ColumnMappings.Add("Цена", "Price");
                        sqlBulk.ColumnMappings.Add("Количество", "Quantity");

                        //Write data from Excel file to the server database
                        sqlBulk.WriteToServer(oleDbData);
                    }

                    //Update DataGridView
                    this.productsTableAdapter.Fill(this.myDataSet.Products);
                    MessageBox.Show("The Excel file data has been uploaded to the server.", "Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                    oleDbData.Close();
                    oleConnection.Close();
                    oleDbCommand.Dispose();
                }
            }
        }
        
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Extract item ID based on selected row            
            itemID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            //Enable the buttons only when some row is selected
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Launch the form
            ProductForm productForm = new ProductForm();
            //If clicked OK, then update Data Grid View
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                this.productsTableAdapter.Fill(this.myDataSet.Products);

                //Turn off buttons
                itemID = null;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedProductName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();            
            if (DialogResult.Yes == MessageBox.Show("The product '" + selectedProductName + "' will be deleted. Are you sure?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string sqlQueryString = "DELETE FROM Products WHERE ID=@id";
                SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.sqlConnectionString);

                //Forming an SQL command with parameters
                SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                sqlCommand.Parameters["@id"].Value = Int32.Parse(itemID);

                try
                {
                    sqlConnection.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("The product has been successfully deleted from database.", "Successful Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.productsTableAdapter.Fill(this.myDataSet.Products);
                    }
                    else
                    {
                        MessageBox.Show("The product has NOT been successfully deleted.", "Not successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Turn off buttons
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    sqlConnection.Close();
                    sqlCommand.Dispose();
                    itemID = null;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

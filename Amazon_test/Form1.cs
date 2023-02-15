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

        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();
            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SqlBulkCopy oSqlBulk = null;

                //Estebilish connection with Excel file
                string excelFile = openFileDialog1.FileName;
                string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + excelFile + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";              
                OleDbConnection myExcelConn = new OleDbConnection(excelConnectionString);
                
                try
                {
                    string query = string.Format("SELECT * FROM [{0}]", GetExcelSheetNames(excelConnectionString)[0]); //Setting the first Excel sheet as source of data
                    myExcelConn.Open();

                    //Retrieve data from Excel file
                    OleDbCommand objOleDB = new OleDbCommand(query, myExcelConn);

                    //Read data from Excel file
                    OleDbDataReader objBulkReader = objOleDB.ExecuteReader();

                    //Estabilish connection with SQL Server
                    string sqlConnectionString = Properties.Settings.Default.sqlConnectionString;
                    
                    using (SqlConnection con = new SqlConnection(sqlConnectionString))
                    {
                        con.Open();

                        //Load data into SQL Server table                        
                        oSqlBulk = new SqlBulkCopy(con);

                        oSqlBulk.DestinationTableName = "Products";
                        //Mapping table column
                        oSqlBulk.ColumnMappings.Add("Артикул", "Article");
                        oSqlBulk.ColumnMappings.Add("[Наименование товара]", "Name");
                        oSqlBulk.ColumnMappings.Add("Цена", "Price");
                        oSqlBulk.ColumnMappings.Add("Количество", "Quantity");
                    
                        oSqlBulk.WriteToServer(objBulkReader);
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
                    if (oSqlBulk != null) oSqlBulk.Close();
                    myExcelConn.Close();
                }
            }
        }
        
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Extract item ID based on selected row
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            itemID = row.Cells[0].Value.ToString();

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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlConnectionString);
            try
            {
                con.Open();
                string SqlSelectQuery = "DELETE FROM Products WHERE ID =" + itemID;
                SqlCommand cmd = new SqlCommand(SqlSelectQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.productsTableAdapter.Fill(this.myDataSet.Products);
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
                itemID = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

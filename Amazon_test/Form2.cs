using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace Amazon_test
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadImage(@Directory.GetCurrentDirectory()+@"\pic\" + articleBox.Text+".jpg");
        }

        private static readonly string id = ProductListForm.itemID.ToString();
        private static string article;
        private static string name;
        private static decimal price;
        private static int qty;

        private void LoadData()
        {
            string sqlQueryString = "SELECT * FROM Products WHERE ID =@id";
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.sqlConnectionString);
            DataTable dataTable = new DataTable();

            //Forming an SQL command with parameters
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlCommand.Parameters["@id"].Value = id;
            
            try
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    //Fill datatable with SQL data                        
                    sqlDataAdapter.Fill(dataTable);

                    //Pass data to varibles
                    article = dataTable.Rows[0]["Article"].ToString();
                    name = dataTable.Rows[0]["Name"].ToString();
                    price = (decimal)dataTable.Rows[0]["Price"];
                    qty = (int)dataTable.Rows[0]["Quantity"];

                    SetBoxes(); //Setting values to textboxes                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                dataTable.Dispose();
            }
        }

        private void UploadData()
        {
            Object[] parametersObjects = new Object[4] //Collection of the data, which will be sent to server DB
                {
                    articleBox.Text,
                    nameBox.Text,
                    (double)priceUpDown.Value,
                    (int)qtyUpDown.Value
                };
            string sqlQueryString = "UPDATE Products SET Article=@article, Name=@name, Price=@price, Quantity=@qty" +
                    " WHERE ID =@id";

            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.sqlConnectionString);

            //Forming an SQL command with parameters
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);
            sqlCommand.Parameters.Add("@article", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@price", SqlDbType.Float);
            sqlCommand.Parameters.Add("@qty", SqlDbType.Int);
            sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlCommand.Parameters["@article"].Value = parametersObjects[0];
            sqlCommand.Parameters["@name"].Value = parametersObjects[1];
            sqlCommand.Parameters["@price"].Value = parametersObjects[2];
            sqlCommand.Parameters["@qty"].Value = parametersObjects[3];
            sqlCommand.Parameters["@id"].Value = id;

            try
            {
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("The product has been successfully updated.", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The product has NOT been successfully updated.", "Not successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
            }
        }

        private void LoadImage(string path)
        {
            try
            {
                //Load pic from file
                pictureBox1.Image = Image.FromFile(path);
            }
            catch
            {
                //If file not found, load NA file
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
        }

        private void SetBoxes()
        {
            //Passing values from variables to the textboxes
            articleBox.Text = article;
            nameBox.Text = name;
            priceUpDown.Value = price;
            qtyUpDown.Value = qty;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetBoxes(); //Setting values to textboxes
            LoadImage(@Directory.GetCurrentDirectory() + @"\pic\" + articleBox.Text + ".jpg"); //Update image after reset button clicked
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            UploadData();
            this.Close();
        }

        private void articleBox_TextChanged(object sender, EventArgs e)
        {
            LoadImage(@Directory.GetCurrentDirectory() + @"\pic\" + articleBox.Text + ".jpg"); //Update image when article is modifying
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

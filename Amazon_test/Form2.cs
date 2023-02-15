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

        private string id = ProductListForm.itemID.ToString();
        private string article;
        private string name;
        private decimal price;
        private int qty;

        private void LoadData()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlConnectionString);
            try
            {
                //Establish connection with SQL server
                con.Open();
                string SqlSelectQuery = "SELECT * FROM Products WHERE ID =" + id;
                SqlCommand cmd = new SqlCommand(SqlSelectQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Fill datatable with SQL data
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                da.Dispose();
                con.Close();
                
                //Pass data to varibles
                article = dataTable.Rows[0]["Article"].ToString();
                name = dataTable.Rows[0]["Name"].ToString();
                price = (decimal)dataTable.Rows[0]["Price"];
                qty = (int)dataTable.Rows[0]["Quantity"];

                SetBoxes(); //Setting values to textboxes
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void UploadData()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlConnectionString);
            try
            {
                con.Open();
                string SqlSelectQuery = "UPDATE Products SET Article='"+
                    articleBox.Text+"', Name='"+
                    nameBox.Text+"', Price="+
                    ((double)priceUpDown.Value).ToString(System.Globalization.CultureInfo.InvariantCulture) +", Quantity="+
                    qtyUpDown.Value.ToString() + " WHERE ID =" + id;
                SqlCommand cmd = new SqlCommand(SqlSelectQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                pictureBox1.Image = Image.FromFile(@Directory.GetCurrentDirectory() + @"\pic\NA.jpg");
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Shop
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            DisplayProducts();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\artur\OneDrive\Dokumenty\Hardware Shop MS.mdf"";Integrated Security=True;Connect Timeout=30");

        private void DisplayProducts()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void Cross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login login = new Login();  
            login.Show();
            this.Hide();
        }

        private void ResetFields()
        {
            ProNameTb.Text ="";
            CatComBox.Text="";
            QuantTb.Text ="";
            PriceTb.Text ="";
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName,Category,Quantity,Price) VALUES (@ProductName, @Category, @Quantity, @Price)", con);
                cmd.Parameters.AddWithValue("@ProductName", ProNameTb.Text);
                cmd.Parameters.AddWithValue("@Category", CatComBox.Text);
                cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(QuantTb.Text));
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(PriceTb.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully");
                con.Close();
                DisplayProducts();
                ResetFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName=@ProductName, Category=@Category, Quantity=@Quantity, Price=@Price WHERE ProductID= @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", id);
                    cmd.Parameters.AddWithValue("@ProductName", ProNameTb.Text);
                    cmd.Parameters.AddWithValue("@Category", CatComBox.Text);
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(QuantTb.Text));
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(PriceTb.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully");
                    con.Close();
                    DisplayProducts();
                    ResetFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully");
                    con.Close();
                    DisplayProducts();
                    ResetFields();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                ProNameTb.Text= dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();
                CatComBox.Text = dataGridView1.CurrentRow.Cells["Category"].Value.ToString();
                QuantTb.Text = dataGridView1.CurrentRow.Cells["Quantity"].Value.ToString();
                PriceTb.Text = dataGridView1.CurrentRow.Cells["Price"].Value.ToString();
            }
        }
    }
}

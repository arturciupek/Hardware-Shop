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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            DisplayCustomers();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\artur\OneDrive\Dokumenty\Hardware Shop MS.mdf"";Integrated Security=True;Connect Timeout=30");

        private void DisplayCustomers()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers ", con);
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
        private void ResetFields()
        {
            CusNameTb.Text = "";
            CusPhone.Text = "";
            CusEmail.Text = "";
        }
        private void Cross_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Show();
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CName,Phone,Email) VALUES (@CName, @Phone, @Email)", con);
                cmd.Parameters.AddWithValue("@CName", CusNameTb.Text);
                cmd.Parameters.AddWithValue("@Phone", CusPhone.Text);
                cmd.Parameters.AddWithValue("@Email", CusEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer added successfully");
                con.Close();
                DisplayCustomers();
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
                    SqlCommand cmd = new SqlCommand("UPDATE Customers SET CName=@CName, Phone=@Phone, Email=@Email WHERE CustomerId= @CustomerId", con);
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    cmd.Parameters.AddWithValue("@CName", CusNameTb.Text);
                    cmd.Parameters.AddWithValue("@Phone", CusPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", CusEmail.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customers updated successfully");
                    con.Close();
                    DisplayCustomers();
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId=@CustomerId", con);
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer deleted successfully");
                    con.Close();
                    DisplayCustomers();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                CusNameTb.Text = dataGridView1.CurrentRow.Cells["CName"].Value.ToString();
                CusPhone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
                CusEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            }
        }
    }
}

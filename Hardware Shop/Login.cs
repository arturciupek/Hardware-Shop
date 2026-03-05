using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Shop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTb.Text == "Admin" && PassTb.Text == "Password")
                {
                    MessageBox.Show("Login Successful!");
                    Product product = new Product();
                    product.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClrLbl_Click(object sender, EventArgs e)
        {
            UserTb.Text = "";
            PassTb.Text = "";
        }
    }
}

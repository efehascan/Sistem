using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Giriş
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection conn = new SqlConnection(@"Data Source=EFE\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Encrypt=False");
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        private void BankRegister_Load(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            formLogin formLogin = new formLogin();
            formLogin.Show();
            this.Hide();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("username and password are required", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPassword.Text == txtConfirmPassword.Text)
            {
                conn.Open();
                string register = "INSERT INTO Login_new (username, password) VALUES (@username, @password)";
                cmd = new SqlCommand(register, conn);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.ExecuteNonQuery();

                

                txtusername.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                
                
                MessageBox.Show("Your account has ben successfuly created", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                
            }
            else
            {
                MessageBox.Show("Password and Confirm Password are not match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();
                conn.Close();
            }
            conn.Close();
        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }
    }
}
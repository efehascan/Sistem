using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Giriş
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
        private SqlConnection conn = new SqlConnection(@"Data Source=EFE\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Encrypt=False");
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 sForm = new Form1();
            sForm.Show();
            this.Hide();
            
        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPassword.Checked)
            {
                txtPasswordLogin.PasswordChar = '\0';
            }
            else
            {
                txtPasswordLogin.PasswordChar = '*';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "select * from tbl_login where username=@username and password=@password";
            cmd = new SqlCommand(login, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new MainMenu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show( "Invalid username or password, please try again","Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusernameLogin.Clear();
                txtPasswordLogin.Clear();
                txtusernameLogin.Focus();
                dr.Close();
                conn.Close();
            }
            
        }
    }
}
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

namespace Ayubo_Drive
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void clearAllData()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Login_Details where Username = '" + username + "' and Password = '" + password + "' ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            if(dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Welcome to Ayubo Drive", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                MainMenu mm = new MainMenu();
                mm.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password ! Please try again", "Unable to Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                clearAllData();
            }
        }
    }
}

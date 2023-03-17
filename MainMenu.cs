using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentVehicle rv = new RentVehicle();
            rv.Show();
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            this.Hide();
            HireVehicle hv = new HireVehicle();
            hv.Show();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            this.Hide();
            PackageDetails pd = new PackageDetails();
            pd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully logged out", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            LoginPage lp = new LoginPage();
            lp.Show();
        }
    }
}

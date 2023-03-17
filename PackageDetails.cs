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
    public partial class PackageDetails : Form
    {
        public PackageDetails()
        {
            InitializeComponent();
        }

        private void btnRentpackage_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentPackage rp = new RentPackage();
            rp.Show();
        }

        private void btnHirepackages_Click(object sender, EventArgs e)
        {
            this.Hide();
            HirePackage hp = new HirePackage();
            hp.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}

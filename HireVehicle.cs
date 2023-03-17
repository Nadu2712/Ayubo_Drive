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
    public partial class HireVehicle : Form
    {
        public HireVehicle()
        {
            InitializeComponent();
        }

        private void btnDayTours_Click(object sender, EventArgs e)
        {
            this.Hide();
            txtDaytotal dt = new txtDaytotal();
            dt.Show();
        }

        private void btnHirePackages_Click(object sender, EventArgs e)
        {
            this.Hide();
            LongTours lt = new LongTours();
            lt.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }
    }
}

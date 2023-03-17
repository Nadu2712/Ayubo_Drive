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
    public partial class txtDaytotal : Form
    {
        public txtDaytotal()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");

        void getAllData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Day_Hired", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDay.DataSource = dt;
        }

        void clearAllData()
        {
            txtDaypackagetype.Text = "";
            txtDaystartingkm.Text = "";
            txtDayendingkm.Text = "";
            dtpDaystime.Text = "";
            dtpDayetime.Text = "";
            txtDaybasehire.Text = "";
            txtDaywaiting.Text = "";
            txtDayextrakm.Text = "";
            txtTotalday.Text = "";
        }
        private void btnDayhire_Click(object sender, EventArgs e)
        {
            try
            {
                string ptype = txtDaypackagetype.Text;
                int skm = int.Parse(txtDaystartingkm.Text);
                int ekm = int.Parse(txtDayendingkm.Text);
                DateTime stime = dtpDaystime.Value;
                DateTime etime = dtpDayetime.Value;
                float basehire = float.Parse(txtDaybasehire.Text);
                float waitcharge = float.Parse(txtDaywaiting.Text);
                float extrakm = float.Parse(txtDayextrakm.Text);
                float totalchargeday = float.Parse(txtTotalday.Text);

                string insert_query = "insert into Day_Hired values ('" + ptype + "','" + skm + "','" + ekm + "','" + stime + "','" + etime + "','" + basehire + "','"+ waitcharge + "','" + extrakm + "','" + totalchargeday + "')";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Day tour hired !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
                clearAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in placing hire !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDaycheck_Click(object sender, EventArgs e)
        {
            string ptype = txtDaypackagetype.Text;
            int skm = int.Parse(txtDaystartingkm.Text);
            int ekm = int.Parse(txtDayendingkm.Text);
            DateTime stime = dtpDaystime.Value;
            DateTime etime = dtpDayetime.Value;

            TimeSpan difference = etime - stime;
            double hoursonly = difference.TotalHours;

            int baserates = 0;
            double waitingrates = 0;
            double extrakmrates = 0;
            int maxkm = 0;
            int maxhours = 0;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Day_Package where Package_Type = '" + ptype + "'";

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                baserates = Convert.ToInt32(rdr["Package_Rate"].ToString());
                maxkm = Convert.ToInt32(rdr["Max_km"].ToString());
                maxhours = Convert.ToInt32(rdr["Max_Hour"].ToString());
                extrakmrates = Convert.ToDouble(rdr["Extra_kmrate"].ToString());
                waitingrates = Convert.ToDouble(rdr["Extra_Hourrates"].ToString());
            }

            int totalhours = Convert.ToInt32(hoursonly);

            int travelhours = 0;
            travelhours = totalhours - maxhours;

            int h = 0;
            int n = 0;

            int waitinghours = Convert.ToInt32(waitingrates);

            if(travelhours >= 1)
            {
                h = travelhours * waitinghours;
                txtDaywaiting.Text = h.ToString();
            }
            else
            {
                txtDaywaiting.Text = n.ToString();
            }

            int distravel = 0;
            distravel = ekm - skm;

            int extravelkm = 0;
            extravelkm = distravel - maxkm;

            int k = 0;
            int extrakmcharge = Convert.ToInt32(extrakmrates);

            if(extravelkm >= 1)
            {
                k = extravelkm * extrakmcharge;
                txtDayextrakm.Text = k.ToString();
            }
            else
            {
                txtDayextrakm.Text = n.ToString();
            }

            txtDaybasehire.Text = baserates.ToString();

            int totaldayhirerates = 0;
            if (travelhours >= 1 && extravelkm >= 1)
            {
                totaldayhirerates = baserates + h + k;
                txtTotalday.Text = totaldayhirerates.ToString();
            }
            else if(travelhours >= 1)
            {
                totaldayhirerates = baserates + h;
                txtTotalday.Text = totaldayhirerates.ToString();
            }
            else if (extravelkm >=1)
            {
                totaldayhirerates = baserates + k;
                txtTotalday.Text = totaldayhirerates.ToString();
            }
            else
            {
                totaldayhirerates = baserates + k;
                txtTotalday.Text = totaldayhirerates.ToString();
            }

            txtDaybasehire.Text = baserates.ToString();
            txtDayextrakm.Text = k.ToString();
            txtDaywaiting.Text = h.ToString();

            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HireVehicle hv = new HireVehicle();
            hv.Show();
        }

        private void txtDaytotal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Package_Type from Day_Package";

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtDaypackagetype.Items.Add(rdr.GetValue(0).ToString());
            }
            con.Close();
            getAllData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ptype = txtDaypackagetype.Text;
                string delete_query = "delete from Day_Hired where Package_Type ='" + ptype + "'";

                SqlCommand cmd = new SqlCommand(delete_query, con);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete Successfull !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
                clearAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

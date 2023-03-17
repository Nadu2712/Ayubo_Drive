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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ayubo_Drive
{
    public partial class LongTours : Form
    {
        public LongTours()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");

        void getAllData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Long_Hired", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvLong.DataSource = dt;
        }

        void clearAllData()
        {
            txtLongpackagetype.Text = "";
            dtpLongstart.Text = "";
            dtpLongend.Text = "";
            txtLongstartingkm.Text = "";
            txtLongendingkm.Text = "";
            txtLongbasehire.Text = "";
            txtLongovernight.Text = "";
            txtLongextrakm.Text = "";
            txtLongparking.Text = "";
            txtLongtotal.Text = "";
        }
        private void btnLonghire_Click(object sender, EventArgs e)
        {
            try
            {
                string ptype = txtLongpackagetype.Text;
                DateTime sdate = dtpLongstart.Value;
                DateTime edate = dtpLongend.Value;
                int skm = int.Parse(txtLongstartingkm.Text);
                int ekm = int.Parse(txtLongendingkm.Text);
                float basehire = float.Parse(txtLongbasehire.Text);
                float overnight = float.Parse(txtLongovernight.Text);
                float extrakm = float.Parse(txtLongextrakm.Text);
                float nightparking = float.Parse(txtLongparking.Text);
                float totallong = float.Parse(txtLongtotal.Text);

                string insert_query = "insert into Long_Hired values ('" + ptype + "','" + sdate + "','" + edate + "','" + skm + "'," +
                        "'" + ekm + "','" + basehire + "','" + overnight + "','"+extrakm+"','" + nightparking + "','" + totallong + "')";
                SqlCommand cmd = new SqlCommand(insert_query, con);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Long tour hired !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnLongcheck_Click(object sender, EventArgs e)
        {
                string ptype = txtLongpackagetype.Text;
                DateTime sdate = dtpLongstart.Value;
                DateTime edate = dtpLongend.Value;
                int skm = int.Parse(txtLongstartingkm.Text);
                int ekm = int.Parse(txtLongendingkm.Text);

                TimeSpan difference = edate - sdate;
                double daysonly = difference.TotalDays;
                double totdays = daysonly + 1;

                int baserates = 0;
                int maxkm = 0;
                double extrakmrates = 0;
                double overnight = 0;
                double nightpar = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Long_Package where Package_Type = '" + ptype + "'";

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    baserates = Convert.ToInt32(rdr["Package_Rate"].ToString());
                    maxkm = Convert.ToInt32(rdr["Max_km"].ToString());
                    extrakmrates = Convert.ToInt32(rdr["Extra_kmRate"].ToString());
                    overnight = Convert.ToInt32(rdr["Overnight_Cost"].ToString());
                    nightpar = Convert.ToInt32(rdr["Nightparking_Cost"].ToString());
                }
    
                con.Close();

                int totaldays = Convert.ToInt32(totdays);

                double ovnghtcost = 0;
                double nightparkcharge = 0;
                double n = 0;

                if (totaldays >= 2)
                {
                    ovnghtcost = totaldays * overnight;
                    nightparkcharge = totaldays * nightpar;

                    txtLongovernight.Text = ovnghtcost.ToString();
                    txtLongparking.Text = nightparkcharge.ToString();
                }
                else
                {
                    txtLongovernight.Text = n.ToString();
                    txtLongparking.Text = n.ToString();
                }

                int totkms = 0;
                int extrakms = 0;
                totkms = ekm - skm;
                extrakms = (totkms - (totaldays * maxkm));

                int extrakmcharges = 0;
                if (extrakms >= 1)
                {
                    int exkmrates = Convert.ToInt32(extrakmrates);

                    extrakmcharges = extrakms * exkmrates;
                    txtLongextrakm.Text = extrakmcharges.ToString();
                }
                else
                {
                    txtLongextrakm.Text = n.ToString();
                }

                txtLongbasehire.Text = baserates.ToString();

                int totaldayshirecharge = 0;

                int overn = Convert.ToInt32(ovnghtcost);
                int basera = Convert.ToInt32(baserates);
                int nightpark = Convert.ToInt32(nightparkcharge);

                if (totaldays >= 2 && extrakms >= 1)
                {
                    totaldayshirecharge = overn + basera + extrakmcharges + nightpark;
                    txtLongtotal.Text = totaldayshirecharge.ToString();
                }
                else if (totaldays >= 2)
                {
                    totaldayshirecharge = overn + basera + nightpark;
                    txtLongtotal.Text = totaldayshirecharge.ToString();
                }
                else
                {
                    totaldayshirecharge = basera;
                    txtLongtotal.Text = totaldayshirecharge.ToString();
                }
            
            txtLongbasehire.Text = basera.ToString();
            txtLongextrakm.Text = extrakmcharges.ToString();
            txtLongovernight.Text = overn.ToString();
            txtLongparking.Text = nightpark.ToString();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HireVehicle hv = new HireVehicle();
            hv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Package_Type from Long_Package";

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtLongpackagetype.Items.Add(rdr.GetValue(0).ToString());
            }
            con.Close();
            getAllData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ptype = txtLongpackagetype.Text;
                string delete_query = "delete from Long_Hired where Package_Type ='" + ptype + "'";

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

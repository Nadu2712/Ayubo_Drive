using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class RentVehicle : Form
    {
        public RentVehicle()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");

        void getAllData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rented_Vehicle", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvRentvehicle.DataSource = dt;
        }

        private void btnRentvehicle_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = cbVehicletype.Text;
                DateTime rentdate = dtpRenteddate.Value;
                DateTime returndate = dtpReturndate.Value;
                string driver = rdoYes.Text;
                float total = float.Parse(txtRenttotal.Text);

                if (rdoYes.Checked == true)
                {
                    string query_select = "insert into Rented_Vehicle values ('" + vtype + "','" + rentdate + "','" + returndate + "','Yes','" + total + "')";
                    SqlCommand cmd = new SqlCommand(query_select, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else if(rdoNo.Checked == true)
                {
                    string query_select = "insert into Rented_Vehicle values ('" + vtype + "','" + rentdate + "','" + returndate + "','No','" + total + "')";
                    SqlCommand cmd = new SqlCommand(query_select, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Vehicle rented successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot rent a vehicle !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.Show();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string vtype = cbVehicletype.Text;
            DateTime rentdate = dtpRenteddate.Value;
            DateTime returndate = dtpReturndate.Value;

            TimeSpan difference = returndate - rentdate;
            double daysonly = difference.TotalDays;
            double totdays = daysonly + 1;

            int dcost = 0;
            int drate = 0;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Rent_Package where Vehicle_Type = '" + vtype + "'";

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                dcost = Convert.ToInt32(rdr["Driver_Cost"].ToString());
                drate = Convert.ToInt32(rdr["Daily_Rate"].ToString());
            }
            con.Close();
            txtDailyrate.Text = drate.ToString();
            txtDrivercost.Text = dcost.ToString();

            int totaldays = Convert.ToInt32(totdays);

            if(rdoYes.Checked == true)
            {
                int totalrent = (totaldays * drate) + dcost;
                txtRenttotal.Text = totalrent.ToString();
            }
            if (rdoNo.Checked == true)
            {
                int totalrent = totaldays * drate;
                txtRenttotal.Text = totalrent.ToString();
                txtDrivercost.Text = "";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Vehicle_Type from Rent_Package";

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                cbVehicletype.Items.Add(rdr.GetValue(0).ToString());
            }
            con.Close();
            getAllData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = cbVehicletype.Text;
                DateTime rentdate = dtpRenteddate.Value;
                DateTime returndate = dtpReturndate.Value;

                string update_query = "update Rented_Vehicle set Rented_Date = '" + rentdate + "', Return_Date = '" + returndate + "' where Vehicle_Type ='" + vtype + "'";

                SqlCommand cmd = new SqlCommand(update_query, con);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update Successfull !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update data !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string tr = txtRenttotal.Text;
                string delete_query = "delete from Rented_Vehicle where Total_Rent ='" + tr + "'";

                SqlCommand cmd = new SqlCommand(delete_query, con);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete Successfull !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = cbVehicletype.Text;
                string rentd = dtpRenteddate.Text;
                string returnd = dtpReturndate.Text;

                string search_query = "select * from Rented_Vehicle where Vehicle_Type = '" + vtype + "' AND Rented_Date = '" + rentd + "' AND Return_Date = '" + returnd + "' ";

                SqlCommand cmd = new SqlCommand(search_query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dtpRenteddate.Text = dr[2].ToString();
                    dtpReturndate.Text = dr[3].ToString();
                    txtRenttotal.Text = dr[5].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot search data !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            txtDailyrate.Text = "";
            txtDrivercost.Text = "";
        }
    }
}

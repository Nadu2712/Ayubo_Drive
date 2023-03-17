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
    public partial class RentPackage : Form
    {
        public RentPackage()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            PackageDetails pd = new PackageDetails();
            pd.Show();
        }

        void getAllData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Rent_Package", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvRentpackages.DataSource = dt;
        }

        void clearAllData()
        {
            txtRentvehicletype.Text = "";
            txtRentdailyrate.Text = "";
            txtRentweeklyrate.Text = "";
            txtRentmonthlyrate.Text = "";
            txtRentdrivercost.Text = "";
        }

        private void btnRentadd_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = txtRentvehicletype.Text;
                float drates = float.Parse(txtRentdailyrate.Text);
                float wrates = float.Parse(txtRentweeklyrate.Text);
                float mrates = float.Parse(txtRentmonthlyrate.Text);
                float dcost = float.Parse(txtRentdrivercost.Text);

                string insert_query = "insert into Rent_Package values('" + vtype + "','" + drates + "','" + wrates + "','" + mrates + "','" + dcost + "')";

                SqlCommand cmd = new SqlCommand(insert_query, con);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Added successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
                clearAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot add data !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnRentupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = txtRentvehicletype.Text;
                float drates = float.Parse(txtRentdailyrate.Text);
                float wrates = float.Parse(txtRentweeklyrate.Text);
                float mrates = float.Parse(txtRentmonthlyrate.Text);
                float dcost = float.Parse(txtRentdrivercost.Text);

                string update_query = "update Rent_Package set Daily_Rate = '" + drates + "', Weekly_Rate = '" + wrates + "', Monthly_Rate = '" + mrates + "', " +
                    "Driver_Cost = '" + dcost + "' where Vehicle_Type ='" + vtype + "'";

                SqlCommand cmd = new SqlCommand(update_query, con);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update Successfull !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getAllData();
                clearAllData();
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

        private void btnRentdelete_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = txtRentvehicletype.Text;
                string delete_query = "delete from Rent_Package where Vehicle_Type ='" + vtype + "'";

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

        private void btnRentsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string vtype = txtRentsearch.Text;

                string search_query = "select * from Rent_Package where Vehicle_Type = '" + vtype + "'";

                SqlCommand cmd = new SqlCommand(search_query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    txtRentvehicletype.Text = dr[0].ToString();
                    txtRentdailyrate.Text = dr[1].ToString();
                    txtRentweeklyrate.Text = dr[2].ToString();
                    txtRentmonthlyrate.Text = dr[3].ToString();
                    txtRentdrivercost.Text = dr[4].ToString();
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
        }
    }
}

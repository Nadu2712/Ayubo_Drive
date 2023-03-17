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
    public partial class HirePackage : Form
    {
        public HirePackage()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=NADU-PC;Initial Catalog=AyuboDriveDB;Integrated Security=True");

        void getAllDayData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Day_Package", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvHireday.DataSource = dt;
        }

        void getAllLongData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Long_Package", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvHirelong.DataSource = dt;
        }

        void clearAllData()
        {
            txtHirepackagetype.Text = "";
            txtHirebaserate.Text = "";
            txtHiremaxkm.Text = "";
            txtHiremaxhourlimit.Text = "";
            txtHireextrakmrate.Text = "";
            txtHireextrahourrate.Text = "";
            txtHireovernightrate.Text = "";
            txtHireparkingrate.Text = "";
            txtwaitingcharge.Text = "";
        }

        private void btnHireadd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (rdoDay.Checked == true)
                {
                    string ptype = txtHirepackagetype.Text;
                    float prates = float.Parse(txtHirebaserate.Text);
                    int maxkm = int.Parse(txtHiremaxkm.Text);
                    int maxhour = int.Parse(txtHiremaxhourlimit.Text);
                    float extrakmrts = float.Parse(txtHireextrakmrate.Text);
                    float extrahourrts = float.Parse(txtHireextrahourrate.Text);
                    float waitingcharge = float.Parse(txtwaitingcharge.Text);

                    string insert_query = "insert into Day_Package values ('" + ptype + "','" + prates + "'," +
                        "'" + maxkm + "','" + maxhour + "','" + extrakmrts + "','" + extrahourrts + "','"+ waitingcharge + "')";

                    SqlCommand cmd = new SqlCommand(insert_query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Added successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllDayData();
                    clearAllData();
                }
                else if (rdoLong.Checked == true)
                {
                    string ptype = txtHirepackagetype.Text;
                    float prates = float.Parse(txtHirebaserate.Text);
                    int maxkm = int.Parse(txtHiremaxkm.Text);
                    float extrakmrts = float.Parse(txtHireextrakmrate.Text);
                    float overnightrts = float.Parse(txtHireovernightrate.Text);
                    float nightparkingrts = float.Parse(txtHireparkingrate.Text);

                    string insert_query = "insert into Long_Package values ('" + ptype + "','" + prates + "'," +
                       "'" + maxkm + "','" + extrakmrts + "','" + overnightrts + "','" + nightparkingrts + "')";

                    SqlCommand cmd = new SqlCommand(insert_query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Added successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllLongData();
                    clearAllData();
                }
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

        private void btnHireupdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (rdoDay.Checked == true)
                {
                    string ptype = txtHirepackagetype.Text;
                    float prates = float.Parse(txtHirebaserate.Text);
                    int maxkm = int.Parse(txtHiremaxkm.Text);
                    int maxhour = int.Parse(txtHiremaxhourlimit.Text);
                    float extrakmrts = float.Parse(txtHireextrakmrate.Text);
                    float extrahourrts = float.Parse(txtHireextrahourrate.Text);
                    float waitingcharge = float.Parse(txtwaitingcharge.Text);

                    string update_query = "update Day_Package set Package_Rate = '" + prates + "',Max_km = '" + maxkm + "'," +
                        "Max_Hour = '" + maxhour + "', Extra_kmRate = '" + extrakmrts + "', Extra_Hourrates = '" + extrahourrts + "', Waiting_Charge = '" + waitingcharge + "' where Package_Type = '" + ptype + "' "; 

                    SqlCommand cmd = new SqlCommand(update_query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data updated successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllDayData();
                    clearAllData();
                }
                else if (rdoLong.Checked == true)
                {
                    string ptype = txtHirepackagetype.Text;
                    float prates = float.Parse(txtHirebaserate.Text);
                    int maxkm = int.Parse(txtHiremaxkm.Text);
                    float extrakmrts = float.Parse(txtHireextrakmrate.Text);
                    float overnightrts = float.Parse(txtHireovernightrate.Text);
                    float nightparkingrts = float.Parse(txtHireparkingrate.Text);

                    string update_query = "update Long_Package set Package_Rate = '" + prates + "',Max_km = '" + maxkm + "'," +
                        " Extra_kmRate = '" + extrakmrts + "', Overnight_Cost = '" + overnightrts + "', Nightparking_Cost = '" + nightparkingrts + "' where Package_Type = '" + ptype + "' ";

                    SqlCommand cmd = new SqlCommand(update_query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data updated successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllLongData();
                    clearAllData();
                }
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

        private void btnHiredelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (rdoDay.Checked == true)
                {
                    string hpt = txtHirepackagetype.Text;
                    string delete_query = "delete from Day_Package where Package_Type = '" + hpt + "'";

                    SqlCommand cmd = new SqlCommand(delete_query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data deleted successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllDayData();
                    clearAllData();
                }
                else if (rdoLong.Checked == true)
                {
                    string hpt = txtHirepackagetype.Text;
                    string delete_query = "delete from Long_Package where Package_Type = '" + hpt + "'";

                    SqlCommand cmd = new SqlCommand(delete_query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data deleted successfully !", "Successfull !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getAllLongData();
                    clearAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete data !", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnHiresearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(rdoDay.Checked == true)
                {
                    string pt = txtHiresearch.Text;
                    string search_query = "select * from Day_Package where Package_Type = '" + pt + "'";

                    SqlCommand cmd = new SqlCommand(search_query, con);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        txtHirepackagetype.Text = dr[0].ToString();
                        txtHirebaserate.Text = dr[1].ToString();
                        txtHiremaxkm.Text = dr[2].ToString();
                        txtHiremaxhourlimit.Text = dr[3].ToString();
                        txtHireextrakmrate.Text = dr[4].ToString();
                        txtHireextrahourrate.Text = dr[5].ToString();
                        txtwaitingcharge.Text = dr[6].ToString();
                    }
                }
                else if(rdoLong.Checked == true)
                {
                    string pt = txtHiresearch.Text;
                    string search_query = "select * from Long_Package where Package_Type = '" + pt + "'";

                    SqlCommand cmd = new SqlCommand(search_query, con);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtHirepackagetype.Text = dr[0].ToString();
                        txtHirebaserate.Text = dr[1].ToString();
                        txtHiremaxkm.Text = dr[2].ToString();
                        txtHireextrakmrate.Text = dr[3].ToString();
                        txtHireovernightrate.Text = dr[4].ToString();
                        txtHireparkingrate.Text = dr[5].ToString();
                    }
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            PackageDetails pd = new PackageDetails();
            pd.Show();
        }
    }
}

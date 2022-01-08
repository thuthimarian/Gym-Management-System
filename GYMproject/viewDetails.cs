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

namespace GYMproject
{
    public partial class viewDetails : Form
    {
        public viewDetails()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int memberId = int.Parse(this.txtID.Text);

            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query1 = "SELECT member_id , member_name FROM MemberDetails WHERE member_id = " + memberId + "";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                membersDGV.DataSource = ds.Tables[0];
                con.Close();
                txtID.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        private void populate()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT member_id , member_name FROM MemberDetails";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                membersDGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void viewDetails_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            populate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

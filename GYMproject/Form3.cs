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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {  //logout button
            new Form1().Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new memberPerformance().Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new payment().Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        private void button8_Click(object sender, EventArgs e)
        {
            //search button
            int memberId = int.Parse(this.txtID.Text);

            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query1 = "SELECT * FROM MemberDetails WHERE member_id = " + memberId + "";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                con.Close();
                if (dtbl.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Member ID. Try Again!!");
                }
                else
                {
                    var ds = new DataSet();
                    sda.Fill(ds);
                    memberDetailsDGV.DataSource = ds.Tables[0];
                }
             
                txtID.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new updateDeleteUI().Show();
            this.Hide();
        }
    }
}

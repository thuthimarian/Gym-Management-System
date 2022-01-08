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
    public partial class memberPerformance : Form
    {
        public memberPerformance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtname.Clear();
            txtInstructorId.Clear();
            txtInstructorName.Clear();
            txtDate.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";

        }

        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberPerformance_Load(object sender, EventArgs e)
        {
            
        }


        // CONNECTION STRING
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int memberID = int.Parse(txtID.Text);
            string membername = txtname.Text.ToString();
            int instructorID = int.Parse(txtInstructorId.Text);
            string instructorName = txtInstructorName.Text.ToString();
            string currentDate = txtDate.Text.ToString();
            string startTime = txtStartTime.Text.ToString();
            string endTime = txtEndTime.Text.ToString();
            Attendance member1 = new Attendance();
            member1.setInstructorID(instructorID);
            member1.setInstructorName(instructorName);
            member1.setDate(currentDate);
            member1.setStartTime(startTime);
            member1.setEndTime(endTime);
            member1.addAttendance(memberID, membername);
            populate();

           
        }

        private void populate()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT * FROM Member_attendance";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                memberPerformanceDGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Attendance member1 = new Attendance();
            member1.setAttendanceID(attendanceID);
            member1.deleteAttendance();
            populate();
           
        }

        private int attendanceID;
        private void memberPerformanceDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            attendanceID = int.Parse(memberPerformanceDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int memberID = int.Parse(txtMemId.Text);
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT * FROM Member_attendance WHERE memberID='"+memberID+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                memberPerformanceDGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMemId.Clear();
            populate();
        }
    }
}

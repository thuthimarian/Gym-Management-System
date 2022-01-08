using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMproject
{
    class Attendance :Member
    {
        private int instructorID;
        private string instructorName;
        private string date;
        private string startTime;
        private string endTime;
        private int attendanceID;

        public void setInstructorID(int instructorID)
        {
            this.instructorID = instructorID;
        }
        public void setInstructorName(string instructorName) 
        {
            this.instructorName = instructorName;
        }
        public void setDate(string date)
        {
            this.date = date;
        }
        public void setStartTime(string startTime)
        {
            this.startTime = startTime;
        }
        public void setEndTime(string endTime)
        {
            this.endTime = endTime;
        }
        public void setAttendanceID(int attendanceID)
        {
            this.attendanceID = attendanceID;
        }

        // CONNECTION STRING
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        //add attendance
        public void addAttendance(int memberID, string membername)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "INSERT INTO Member_attendance (memberID,memberName,instructorID,instructorName,currentDate,settime,endtime)" +
                    " VALUES(" + memberID + ",'" + membername + "'," + instructorID + ",'" + instructorName + "','" + date + "','" + startTime + "','" + endTime + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records saved successfully!!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //delete attendance
        public void deleteAttendance()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "DELETE FROM Member_attendance WHERE attendanceID='" + attendanceID + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records deleted successfully!!");
                con.Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

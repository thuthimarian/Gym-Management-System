using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMproject
{
    class MemberPayment : Member
    {
        private string payDate;
        private string description;
        private int payAmount;
        private int paymentID;

        public void setPayDate(string payDate)
        {
            this.payDate = payDate;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setPayAmount(int amount)
        {
            this.payAmount = amount;
        }
        public void setPaymentId(int paymentID)
        {
            this.paymentID = paymentID;
        }


        // CONNECTION STRING
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        //add payment details
        public void addPayment(int memberID, string memberName)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "INSERT INTO Payments (payment_date,member_id,member_name,payment_description,amount) " +
                    "values('" + payDate + "'," + memberID + ",'" + memberName + "','" + description + "'," + payAmount + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully!!");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //deletePayment
        public void deletePayment()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "DELETE FROM Payments WHERE payment_id='" + paymentID + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Do you want to delete this record?");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

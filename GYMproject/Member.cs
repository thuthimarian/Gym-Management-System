using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace GYMproject
{
    class Member 
    {
        private int id;
        private string name;
        private string gender;
        private string phoneNo;
        private string email;
        private string address;
        private string dob;
        private string joinDate;
        private string plan;
        private string package;
        private int amount;
        private string validate;

        
        
        public void setID(int id)
        {
            this.id = id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setGender(string gender)
        {
            this.gender = gender;
        }
        public void setPhoneNo(string phoneNo)
        {
            this.phoneNo = phoneNo;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setDob(string dob)
        {
            this.dob = dob;
        }
        public void setJoindate(string joinDate)
        {
            this.joinDate = joinDate;
        }
        public void setPlan(string plan)
        {
            this.plan = plan;
        }
        public void setPackage(string package)
        {
            this.package = package;
        }
        public void setAmount(int amount)
        {
            this.amount = amount;
        }
        public void setValidate(string validate)
        {
            this.validate = validate;
        }
        
       
        // CONNECTION STRING
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        
        //add member details
        public void addMember()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();

                string query = "INSERT INTO MemberDetails (member_name,member_address,gender,dob,phoneNo,email,joinDate,member_plan,package,amount,validate) " +
                    "values('" + name + "','" + address + "','" + gender + "','" + dob + "','" + phoneNo + "','" + email + "','" + joinDate + "','" + plan + "','" + package + "'," + amount + ",'" + validate + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully registered!!");
            }
            catch(Exception e)
            { 
                MessageBox.Show(e.Message);
            }
  
        }

        //delete member details
        public void deleteMember()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "DELETE FROM MemberDetails WHERE member_id='"+id+"'";
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

        //update member details
        public void updateMember()
        {
           SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "UPDATE MemberDetails SET member_name='" + name + "',member_address='" + address + "',gender='" + gender + "',dob='" + dob + "',phoneNo='" + phoneNo + "',email='" + email + "',joinDate='" + joinDate + "',member_plan='" + plan + "',package='" + package + "',amount=" + amount + ",validate='" + validate + "' WHERE member_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Records updated successfully!!");
                con.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

    }
}

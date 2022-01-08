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
    public partial class updateDeleteUI : Form
    {

        public updateDeleteUI()
        {
            InitializeComponent();
            con = new SqlConnection(conString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }


        //string connection
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        SqlConnection con;
        int memberID;
        string gender;

        private void populate()
        {
            try
            { 
                con.Open();
                string query = "SELECT * FROM MemberDetails";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                memberViewDGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }


        private void updateDeleteUI_Load(object sender, EventArgs e)
        {
            populate();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            memberID = int.Parse(this.txtMemberID.Text);

            
            try
            {
                con.Open();
                string query1 = "SELECT * FROM MemberDetails WHERE member_id = " + memberID + "";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                memberViewDGV.DataSource = ds.Tables[0];
                con.Close();
                txtMemberID.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            populate();
        }

        
        private void memberViewDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

       
        private void memberViewDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            memberID = int.Parse(memberViewDGV.SelectedRows[0].Cells[0].Value.ToString());
            txtMemberName.Text = memberViewDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = memberViewDGV.SelectedRows[0].Cells[2].Value.ToString();
            rdFemale.Checked = false;
            rdMale.Checked = true;
            if (memberViewDGV.SelectedRows[0].Cells[3].Value.ToString() == "Female")
            {
                rdFemale.Checked = true;
                rdMale.Checked = false;
            }
            dob.Text = memberViewDGV.SelectedRows[0].Cells[4].Value.ToString();
            txtPhoneNo.Text = memberViewDGV.SelectedRows[0].Cells[5].Value.ToString();
            txtEmail.Text = memberViewDGV.SelectedRows[0].Cells[6].Value.ToString();
            joinDate.Text = memberViewDGV.SelectedRows[0].Cells[7].Value.ToString();
            cmbPlan.Text = memberViewDGV.SelectedRows[0].Cells[8].Value.ToString();
            cmbPackage.Text = memberViewDGV.SelectedRows[0].Cells[9].Value.ToString();
            txtAmount.Text = memberViewDGV.SelectedRows[0].Cells[10].Value.ToString();
            cmbValidate.Text = memberViewDGV.SelectedRows[0].Cells[11].Value.ToString();
            
        }

        public void clear()
        {
            txtMemberName.Clear();
            txtAddress.Clear();
            rdFemale.Checked = false;
            rdMale.Checked = false;
            dob.Text = "";
            joinDate.Text = "";
            txtPhoneNo.Clear();
            txtEmail.Clear();
            cmbPlan.Text = "";
            cmbPackage.Text = "";
            cmbValidate.Text = "";
            txtAmount.Clear();
        }

        //reset button_click
        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string memberName = txtMemberName.Text;
            string memberAddress = txtAddress.Text;
            string birthDate = dob.Text;
            string phoneNo = txtPhoneNo.Text;
            string email = txtEmail.Text;
            string joiningDate = joinDate.Text;
            string plan = cmbPlan.Text;
            string package = cmbPackage.Text;
            int amount = int.Parse(txtAmount.Text);
            string validate = cmbValidate.Text;

            Member member1 = new Member();
            member1.setID(memberID);
            member1.setName(memberName);
            member1.setGender(gender);
            member1.setPhoneNo(phoneNo);
            member1.setEmail(email);
            member1.setAddress(memberAddress);
            member1.setDob(birthDate);
            member1.setJoindate(joiningDate);
            member1.setPlan(plan);
            member1.setPackage(package);
            member1.setAmount(amount);
            member1.setValidate(validate);

            member1.updateMember();
            populate();
            clear();
          
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            Member member1 = new Member();
            member1.setID(memberID);
            member1.deleteMember();
            populate();
            clear();
        }
    }
}

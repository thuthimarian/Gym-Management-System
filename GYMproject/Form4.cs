using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMproject
{
    public partial class Form4 : Form
    {
        public Form4()
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

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            new viewDetails().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new updateDeleteUI().Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new memberPerformance().Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new payment().Show();
            this.Hide();
        }


        //submit button
        String gender;
        private void button6_Click(object sender, EventArgs e)
        {
            string name = txtMemberName.Text.ToString();
            string phoneNo = txtPhoneNo.Text.ToString();
            string email = txtEmail.Text.ToString();
            string address = txtAddress.Text.ToString();
            string birthDate = dob.Text;
            string joiningDate = joinDate.Text;
            string plan = cmbPlan.SelectedItem.ToString();
            string package = cmbPackage.SelectedItem.ToString();
            string validate = cmbValidate.SelectedItem.ToString();
            int amount = int.Parse(this.txtAmount.Text);

            if(txtMemberName.Text == "" || txtAddress.Text == "" || txtPhoneNo.Text == "" || txtEmail.Text == "" || joinDate.Text == "")
            {
                MessageBox.Show("Check the input fields again!!");
            }
            else
            {
                Member member1 = new Member();
                member1.setName(name);
                member1.setGender(gender);
                member1.setPhoneNo(phoneNo);
                member1.setEmail(email);
                member1.setAddress(address);
                member1.setDob(birthDate);
                member1.setJoindate(joiningDate);
                member1.setPlan(plan);
                member1.setPackage(package);
                member1.setAmount(amount);
                member1.setValidate(validate);
               
                member1.addMember();
                clear();
               

            }

        }

        //refresh the fields
        private void clear()
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

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();      
        }
    }
}

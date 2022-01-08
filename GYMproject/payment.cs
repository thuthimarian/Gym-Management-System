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
    public partial class payment : Form
    {
        public payment()
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

        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string paymentDate = payment_date.Text;
            int memberId = int.Parse(this.txtmember.Text);
            string memberName = txtname.Text.ToString();
            string description = txtDescription.SelectedItem.ToString();
            int amount = int.Parse(this.txtAmount.Text);

             MemberPayment pay = new MemberPayment();
             pay.setPayDate(paymentDate);
             pay.setDescription(description);
             pay.setPayAmount(amount);
             pay.addPayment(memberId,memberName);
            

            displayPayments();
            refresh();



        }

        public void refresh()
        {
            payment_date.Text = "";
            txtmember.Clear();
            txtname.Clear();
            txtDescription.Text = "";
            txtAmount.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }

       

        private void displayPayments()
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT * FROM Payments";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                
                var ds = new DataSet();
                sda.Fill(ds);
                paymentViewDGV.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void payment_Load(object sender, EventArgs e)
        {
          
        }

        int paymentId;
        private void paymentViewDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            paymentId = int.Parse(paymentViewDGV.SelectedRows[0].Cells[0].Value.ToString());
            payment_date.Text = paymentViewDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtmember.Text = paymentViewDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtname.Text = paymentViewDGV.SelectedRows[0].Cells[3].Value.ToString();
            txtDescription.Text = paymentViewDGV.SelectedRows[0].Cells[4].Value.ToString();
            txtAmount.Text = paymentViewDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MemberPayment pay = new MemberPayment();
            pay.setPaymentId(paymentId);
            pay.deletePayment();
            displayPayments();
            refresh();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            int memberId = int.Parse(txtid.Text);
            try
            {
                con.Open();
                string query1 = "SELECT * FROM Payments WHERE member_id = " + memberId + "";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                paymentViewDGV.DataSource = ds.Tables[0];
                con.Close();
                txtid.Clear();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            displayPayments();
        }
    }
}

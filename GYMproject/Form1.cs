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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        public string conString = "Data Source=LAPTOP-PPCOJGC0;Initial Catalog=GymDB;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text.ToString();
            string pwd = txtpassword.Text.ToString();
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT * FROM UserDetails WHERE UserName='" + userName + "' AND userPassword='" + pwd + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                con.Close();
                if(dtbl.Rows.Count == 1)
                {
                    new Form2().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password. Try Again!!");
                    txtUserName.Clear();
                    txtpassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            
        }

        
      
           
           
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LabProject
{
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;

        public UpdateStudent(int StudentID)
        {
            ID = StudentID;
            InitializeComponent();
        }
        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from student where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[1].ToString();
            textBox2.Text = reader[2].ToString();
            textBox3.Text = reader[3].ToString();
            textBox4.Text = reader[4].ToString();
            textBox5.Text = reader[5].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "Select LookupId from Lookup where Name='" + comboBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            var dt = cmd2.ExecuteReader();
            dt.Read();
            int stateId = (int)dt.GetValue(0);
            dt.Close();
            
            string query = "update Student set FirstName ='" + textBox1.Text.ToString() + "' ,LastName= '" + textBox2.Text.ToString() + "' , Contact= '" + textBox3.Text.ToString() + "' , Email='" + textBox4.Text.ToString() + "' , RegistrationNumber='" + textBox5.Text.ToString() + "', Status="+stateId+"  where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data successfully updated");
            textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " "; textBox4.Text = " "; textBox5.Text = " "; comboBox1.Text = " ";

            DetailStudent frm = new DetailStudent();
            frm.Show();
            this.Hide();
        }
    }
}

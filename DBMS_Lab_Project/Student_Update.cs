﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_Lab_Project
{
    public partial class Student_Update : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;

        public Student_Update()
        {
            InitializeComponent();
        }
        public Student_Update(int upID)
        {
            ID = upID;
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void Student_Update_Load(object sender, EventArgs e)
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
            textBox6.Text = reader[4].ToString();
            textBox5.Text = reader[5].ToString();
        }
            private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "Select LookupId from Lookup where Name='" + comboBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            var dt = cmd2.ExecuteReader();
            dt.Read();
            int stateId = (int)dt.GetValue(0);
            dt.Close();
            //--------------------------------------------------------------------------------------------------------------------------------
            string query = "update Student set FirstName ='" + textBox1.Text.ToString() + "' ,LastName= '" + textBox2.Text.ToString() + "' , Contact= '" + textBox3.Text.ToString() + "' , Email='" + textBox6.Text.ToString() + "' , RegistrationNumber='" + textBox5.Text.ToString() + "', Status=" + stateId + "  where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Record Successfully Updated");
            textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " "; textBox6.Text = " "; textBox5.Text = " "; comboBox1.Text = " ";
            //---------------------------------------------------------------------------------------------------------------------------------
           Student_detail frm = new Student_detail();
           frm.Show();
           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Student frm = new Add_Student();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attendance frm = new Add_Attendance();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_clo frm = new Add_clo();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Rubric frm = new Add_Rubric();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Rubric_Level frm = new Add_Rubric_Level();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Assessment frm = new Add_Assessment();
            frm.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add_Result frm = new Add_Result();
            frm.Show();
            this.Hide();
        }
    }
}

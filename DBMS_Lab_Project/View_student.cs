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
    public partial class View_student : Form
    {
        public int ID;
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public View_student()
        {
            InitializeComponent();
        }
        public View_student(int viewID)
        {
            ID = viewID;
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Student_detail frm = new Student_detail();
            frm.Show();
            this.Hide();
        }

        private void View_student_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "select * from student where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            label15.Text = reader[1].ToString();
            label14.Text = reader[2].ToString();
            label13.Text = reader[3].ToString();
            label12.Text = reader[4].ToString();
            label11.Text = reader[5].ToString();
            reader.Close();
            string query2 = "select status from student where Id=" + ID + "";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            int getId = int.Parse(cmd2.ExecuteScalar().ToString());
           if (getId == 5)
            {
                label10.Text = "Active";
            }
            else
            {
                label10.Text = "InActive";
            }
 }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

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

namespace LabProject
{
    public partial class DetailCLO : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        int r;
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;

        private void viewR(string q)
        {
            SqlConnection con = new SqlConnection(constr);
            sda = new SqlDataAdapter(q, con);
            DataSet s = new DataSet();
            sda.Fill(s);
            dataGridView1.DataSource = s.Tables[0];
            con.Close();


        }
        public DetailCLO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClo frm = new AddClo();
            frm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void DetailCLO_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Select * from Clo", constr);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                
                int var1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
                string q = "Delete from Clo where Id=" + var1 + "";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                

                string q2 = "select * from Clo";
                viewR(q2);
                MessageBox.Show("Clo deleted successfully");

            }


            else
            {
                MessageBox.Show("Error");
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            UpdateClo frm = new UpdateClo(var1);
            frm.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            ViewClocs frm = new ViewClocs(var1);
            frm.Show();
            this.Hide();
        }
    }
}

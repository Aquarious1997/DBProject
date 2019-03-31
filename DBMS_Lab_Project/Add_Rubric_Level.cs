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

namespace DBMS_Lab_Project
{
    public partial class Add_Rubric_Level : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Add_Rubric_Level()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Rubric frm = new Add_Rubric();
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_clo frm = new Add_clo();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Student frm = new Add_Student();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "Insert into RubricLevel(RubricId,Details,MeasurementLevel)values(" + comboBox1.Text + ",'" + textBox1.Text + "'," + comboBox2.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rubric Level Set");
                comboBox1.Text = "Select Rubric ID";
                comboBox2.Text = " Select Mesurement Level";
                textBox1.Text = "";


            }
            else
            {
                MessageBox.Show("Database not connected");
            }
        }

        private void Add_Rubric_Level_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select Id from Rubric";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader doit;
            doit = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("Id", typeof(string));
            tb.Load(doit);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Id";
            comboBox1.DataSource = tb;
            comboBox1.Text = "Select Rubric ID";
            comboBox2.Text = " Select Mesurement Level";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attendance frm = new Add_Attendance();
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

        private void button12_Click(object sender, EventArgs e)
        {
            Rubric_level_detail frm = new Rubric_level_detail();
            frm.Show();
            this.Hide();
        }
    }
    }


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
    public partial class Add_assessment_comp : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Add_assessment_comp()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string s = " ";
                string query = "Insert into AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) values ('" + textBox1.Text + "'," + comboBox1.Text + "," + textBox2.Text + ",'" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + s + "', " + comboBox2.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");
                comboBox1.Text = "Choose Rubric Id  From Here";
                textBox1.Text = "";
                textBox2.Text = "";


            }
            else
            {
                MessageBox.Show("Error in Connection");
            }
        }

        private void Add_assessment_comp_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //------------------------------------------------------
            string query1 = "Select max(Id) from Assessment";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            int getId = int.Parse(cmd2.ExecuteScalar().ToString());
            comboBox2.Text = getId.ToString();

            //-------------------------------------------------------
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
            comboBox1.Text = "Choose Rubric Id  From Here";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

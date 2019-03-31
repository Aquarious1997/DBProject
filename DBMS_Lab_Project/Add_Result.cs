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
    public partial class Add_Result : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Add_Result()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Assessment frm = new Add_Assessment();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Rubric_Level frm = new Add_Rubric_Level();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Rubric frm = new Add_Rubric();
            frm.Show();
            this.Hide();
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

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Add_Result_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //------------------------------------------------------
            string query1 = "Select Id from AssessmentComponent";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            SqlDataReader doi;
            doi = cmd2.ExecuteReader();
            DataTable tb1 = new DataTable();
            tb1.Columns.Add("Id", typeof(string));
            tb1.Load(doi);
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Id";
            comboBox3.DataSource = tb1;
            comboBox3.Text = "Choose Assessment Id  From Here";
            doi.Close();

            //------------------------------------------------------
            string query = "Select Id,RegistrationNumber from Student where status=" + 5 + "";
            SqlCommand cmd3 = new SqlCommand(query, con);
            SqlDataReader doit;
            doit = cmd3.ExecuteReader();
            DataTable tb3 = new DataTable();
            tb3.Columns.Add("RegistrationNumber", typeof(string));
            tb3.Load(doit);
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "RegistrationNumber";
            comboBox2.DataSource = tb3;
            comboBox2.Text = "Choose Registration# From Here";
            doit.Close();

            //------------------------------------------------------
            string query3 = "Select Id from RubricLevel";
            SqlCommand cmd4 = new SqlCommand(query3, con);
            SqlDataReader doitt;
            doitt = cmd4.ExecuteReader();
            DataTable tb4 = new DataTable();
            tb4.Columns.Add("Id", typeof(string));
            tb4.Load(doitt);
            comboBox4.ValueMember = "Id";
            comboBox4.DisplayMember = "Id";
            comboBox4.DataSource = tb4;
            comboBox4.Text = "Choose Measurement IdFrom Here";
            doitt.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                string xquery = "Select Id from Student where RegistrationNumber='" + comboBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(xquery, con);
                int maxId = int.Parse(cmd1.ExecuteScalar().ToString());
                string query2 = "Insert into StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate)values('" + maxId + "' ,'" + comboBox3.Text + "'," + comboBox4.Text + ",'" + Convert.ToDateTime(dateTimePicker1.Text) + "')";
                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");
                comboBox4.Text = "Choose Measurement Id From Here";
                comboBox2.Text = "Choose Registration# From Here";
                comboBox3.Text = "Choose Assessment Id From Here";

            }
            else
            {
                MessageBox.Show("Error in Connection");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attendance frm = new Add_Attendance();
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            frm.Show();
            this.Hide();
        }
    }
}

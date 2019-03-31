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
    public partial class Add_StudentAtt : Form
    {
        public Add_StudentAtt()
        {
            InitializeComponent();
        }

        string rep;
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            if (checkBox1.Checked == true)
            {
                rep = "Present";
            }
            else if (checkBox2.Checked == true)
            {
                rep = "Absent";
            }
            else if (checkBox3.Checked == true)
            {
                rep = "Leave";

            }
            else
            {
                rep = "Late";
            }

            if (conn.State == ConnectionState.Open)
            {
                string xquery = "Select Id from Student where RegistrationNumber='" + comboBox1.Text + "'";
                SqlCommand cmd1 = new SqlCommand(xquery, conn);
                int maxId = int.Parse(cmd1.ExecuteScalar().ToString());

                string query1 = "Select LookupId from Lookup where Name='" + rep + "'";
                SqlCommand cmd2 = new SqlCommand(query1, conn);
                var dt = cmd2.ExecuteReader();
                dt.Read();
                int stateId = (int)dt.GetValue(0);
                dt.Close();
                string maxquery = "select Id  from ClassAttendance";
                SqlCommand cmd3 = new SqlCommand(maxquery, conn);
                int maxId2 = int.Parse(cmd3.ExecuteScalar().ToString());
                string query = "INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus) values('" + maxId2 + "','" + maxId + "' ," + stateId + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendance Marked");
                comboBox1.Text = "Choose Registration# From Here";

            }
            else
            {
                MessageBox.Show("Some sort of error");
            }
        }

        private void Add_StudentAtt_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select Id,RegistrationNumber from Student where status=" + 5 + "";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader doit;
            doit = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("RegistrationNumber", typeof(string));
            tb.Columns.Add("Id", typeof(string));
            tb.Load(doit);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "RegistrationNumber";
            comboBox1.DataSource = tb;
            comboBox1.Text = "Choose Registration# From Here";
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

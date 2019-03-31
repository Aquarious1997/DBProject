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
    public partial class Rubric_level_update : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public Rubric_level_update()
        {
            InitializeComponent();
        }
        public Rubric_level_update(int upId)
        {
            ID = upId;
            InitializeComponent();
        }

        private void Rubric_level_update_Load(object sender, EventArgs e)
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
            //comboBox1.Text = "Select Rubric ID";
            comboBox2.Text = " Select Mesurement Level";
            doit.Close();
            string query2 = "select * from RubricLevel";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            var reader = cmd2.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[2].ToString();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                string query = "update RubricLevel set RubricId=" + comboBox1.Text + ",Details='"+ textBox1.Text + "',MeasurementLevel="+comboBox2.Text+"  where Id=" + ID + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("RubricLevel successfully updated");
                textBox1.Text = "";
                comboBox1.Text = "Select Rubric ID";
                comboBox2.Text = " Select Mesurement Level";
            }
            else
            {
                MessageBox.Show("Error in  updated");

            }

            Rubric_level_detail frm = new Rubric_level_detail();
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

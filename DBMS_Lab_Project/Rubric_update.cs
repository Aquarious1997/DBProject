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
    public partial class Rubric_update : Form
    {
        public int ID;
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Rubric_update()
        {
            InitializeComponent();
        }
        public Rubric_update(int RubId)
        {
            ID = RubId;
            InitializeComponent();
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

        private void Rubric_update_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from Rubric where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[1].ToString();
            reader.Close();

            string query = "Select Id,Name from Clo";
            SqlCommand cmdd = new SqlCommand(query, con);
            SqlDataReader doit;
            doit = cmdd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Id", typeof(string));
            tb.Load(doit);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = tb;
            comboBox1.Text = "Select Clo";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "Select Id from Clo where name='" + comboBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            int getId = reader.GetInt32(0);
            reader.Close();
            string query2 = "Update Rubric set Details='" + textBox1.Text.ToString() + "',CloId='" + getId + "' where Id=" + ID + "";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Rubric Updated Successfully");
            textBox1.Text = " ";
            comboBox1.Text = "Select Clo";
            Rubric_detail frm = new Rubric_detail();
            frm.Show();
            this.Hide();
        }
    }
}

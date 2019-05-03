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
    public partial class Assessment_update : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public Assessment_update()
        {
            InitializeComponent();
        }
        public Assessment_update(int AID)
        {
            ID = AID;
            InitializeComponent();
        }

        private void Assessment_update_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "select * from Assessment where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[1].ToString();
            textBox2.Text = reader[3].ToString();
            textBox3.Text = reader[4].ToString();
            dateTimePicker1.Text= reader[2].ToString();

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

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update Assessment set Title ='" + textBox1.Text.ToString() + "' ,DateCreated= '" + Convert.ToDateTime(dateTimePicker1.Text) + "' , TotalMarks= " + textBox2.Text + " , TotalWeightage='" + textBox3.Text.ToString() + "'  where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Assessment Record Successfully Updated");
            textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " ";
            Assessment_detail frm = new Assessment_detail();
            frm.Show();
            this.Hide();
        }
    }
}

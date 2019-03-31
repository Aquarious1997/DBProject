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
    public partial class Add_Assessment : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Add_Assessment()
        {
            InitializeComponent();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Assessment_Load(object sender, EventArgs e)
        {
            button13.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "Insert into Assessment(Title,DateCreated,TotalMarks,TotalWeightage)values('" + textBox1.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "'," + textBox2.Text + "," + textBox3.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Assessment Set Successfully");
                textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " ";
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Error In connection");

            }
            button13.Visible = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add_Result frm = new Add_Result();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attendance frm = new Add_Attendance();
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Assessment_detail frm = new Assessment_detail();
            frm.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Add_assessment_comp frm = new Add_assessment_comp();
            frm.Show();
            this.Hide();
        }
    }
}







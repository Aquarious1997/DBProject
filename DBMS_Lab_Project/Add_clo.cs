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
    public partial class Add_clo : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public Add_clo()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
            if (con.State == ConnectionState.Open)
            {
                if (textBox1.Text != "")
                {
                    string s = " ";
                    string query = "INSERT INTO Clo(Name,DateCreated,DateUpdated) values ('" + textBox1.Text.ToString() + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + s + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("CLO successfully added");
                    textBox1.Text = " ";
                    dateTimePicker1.Value = DateTime.Now;

                }
                else
                {
                    MessageBox.Show("Please Fill all the requirements");

                }

            }
            else
            {
                MessageBox.Show("Error in Connection");

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Clo_detail frm = new Clo_detail();
            frm.Show();
            this.Hide();
        }
    }
}

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
    public partial class Add_Rubric : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public Add_Rubric()
        {
            InitializeComponent();
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
            if (textBox1.Text != "")
            {
                try
                {

                    string maxquery = "select max(Id)  from Rubric";
                    SqlCommand cmd1 = new SqlCommand(maxquery, con);
                    int maxId = int.Parse(cmd1.ExecuteScalar().ToString());
                    string query1 = "Insert into Rubric(Id,Details,CloId)values('" + (maxId + 1) + "','" + textBox1.Text.ToString() + "','" + comboBox1.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric successfully added");
                    textBox1.Text = " ";
                    comboBox1.Show();
                }
                catch
                {
                    string query1 = "Insert into Rubric(Id,Details,CloId)values('" + 1 + "','" + textBox1.Text.ToString() + "','" + comboBox1.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric successfully Added");
                    textBox1.Text = " ";
                    comboBox1.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Fill the Detail Box");

            }

        }

        private void Add_Rubric_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select Id,Name from Clo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader doit;
            doit = cmd.ExecuteReader();
            DataTable tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Id", typeof(string));
            tb.Load(doit);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = tb;
            comboBox1.Text = "Select CLOs";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Rubric_detail frm = new Rubric_detail();
            frm.Show();
            this.Hide();
        }
    }
}

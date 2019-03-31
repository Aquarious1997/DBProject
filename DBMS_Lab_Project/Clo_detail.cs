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
    public partial class Clo_detail : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        int r;
        SqlDataAdapter sda;
        DataTable dt;
        public Clo_detail()
        {
            InitializeComponent();
        }
        private void viewR(string q)
        {
            SqlConnection con = new SqlConnection(constr);
            sda = new SqlDataAdapter(q, con);
            DataSet s = new DataSet();
            sda.Fill(s);
            dataGridView1.DataSource = s.Tables[0];
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Add_clo frm = new Add_clo();
            frm.Show();
            this.Hide();
        }

        private void Clo_detail_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Select * from Clo", constr);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int var1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
                string query1 = "delete from Clo where Id=" + var1 + "";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                string q2 = "select * from Clo";
                viewR(q2);
                MessageBox.Show("Clo deleted successfully");
            }


            else
            {
                MessageBox.Show("Database not connected make sure your connection");
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            Clo_update frm = new Clo_update(ID);
            frm.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            View_clo frm = new View_clo(ID);
            frm.Show();
            this.Hide();
        }
    }
}

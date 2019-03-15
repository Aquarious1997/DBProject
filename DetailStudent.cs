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


namespace LabProject
{
    public partial class DetailStudent : Form
    {
        int r;
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public DetailStudent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This function view all the data again after being deleted
        /// </summary>
        /// <param name="q"> this create connection with databas </param>
        private void viewR(string q)
        {
            SqlConnection con = new SqlConnection(constr);
            sda = new SqlDataAdapter(q, con);
            DataSet s = new DataSet();
            sda.Fill(s);
            dataGridView1.DataSource = s.Tables[0];
            con.Close();
        }


        ///<remarks>
        /// This button take us to Student Add form where we add values to student form
        /// </remarks>
        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent frm = new AddStudent();
            frm.Show();
            this.Hide();
        }

        ///<remarks>
        /// This button take us to Home form/page
        /// </remarks>
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        ///<remarks>
        /// This following function select data from Student form and fill the gridview
        /// </remarks>
        private void DetailStudent_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Select * from Student", constr);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// This delete the data from database of Student data by getting id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int var1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
                string query1 = "delete from Student where Id=" + var1 + "";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                string q2 = "select * from Student";
                viewR(q2);
                MessageBox.Show("data deleted successfully");
 }


            else
            {
                MessageBox.Show("Some sort of error");
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        ///<remarks>
        /// This button take us to  single Student detail
        /// </remarks>
        private void button3_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            UpdateStudent frm = new UpdateStudent(ID);
            frm.Show();
            this.Hide();
        }

        ///<remarks>
        /// This button take us to  single Student detail
        /// </remarks>
        private void button4_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
            ViewStudent frm = new ViewStudent(ID);
            frm.Show();
            this.Hide();

        }
    }
}

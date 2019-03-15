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
    public partial class UpdateRub : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public int pro;
        public UpdateRub()
        {
            InitializeComponent();
        }
        public UpdateRub(int rubid)
        {
            ID = rubid;
            InitializeComponent();
        }

        private void UpdateRub_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from Rubric where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[1].ToString();
            comboBox1.Text = reader[2].ToString();
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





        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "Select * from Clo where name='" + comboBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            pro = reader.GetInt32(0);
            reader.Close();
            
            string query2 = "Update Rubric set Details='" + textBox1.Text.ToString() + "',CloId='" + pro + "' where Id=" + ID + "";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Rubric Updated Successfully");
            textBox1.Text = " ";
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubDetail frm = new RubDetail();
            frm.Show();
            this.Hide();
        }
    }
}

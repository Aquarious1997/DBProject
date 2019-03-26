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
    public partial class UpdateClo : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public UpdateClo()
        {
            InitializeComponent();
        }

        public UpdateClo(int CloId)
          
        {
            ID = CloId;
          InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DetailCLO frm = new DetailCLO();
            frm.Show();
            this.Hide();
        }

        private void UpdateClo_Load(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                string query1 = "select * from Clo where Id=" + ID + "";
                SqlCommand cmd = new SqlCommand(query1, con);
                var reader = cmd.ExecuteReader();
                reader.Read();

                textBox1.Text = reader[1].ToString();
                dateTimePicker1.Text = reader[2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                string query = "update Clo set Name='" + textBox1.Text.ToString() + "', DateUpdated='" + Convert.ToDateTime(dateTimePicker1.Text) + "' where Id=" + ID + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Clo successfully updated");
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Not successfully updated");

            }
        }
    }
}

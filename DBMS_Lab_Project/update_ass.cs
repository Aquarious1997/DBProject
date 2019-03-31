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
    
    public partial class update_ass : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public update_ass()
        {
            InitializeComponent();
        }
        public update_ass(int gh)
        {
            ID = gh;
            InitializeComponent();
        }

        private void update_ass_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query2 = "select * from Assessment";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            var reader = cmd2.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[1].ToString();
            textBox2.Text = reader[3].ToString();
            textBox3.Text = reader[4].ToString();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                string query = "update Assessment set Title='" + textBox1.Text + "',TotalMarks="+textBox2.Text+",TotalWeightage=" + textBox3.Text + "  where Id=" + ID + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Assessment successfully updated");
                
            }
            else
            {
                MessageBox.Show("Error in  updated");

            }

            detail_ass frm = new detail_ass();
            frm.Show();
            this.Hide();
        }
    }
}

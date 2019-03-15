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
    public partial class ViewStudent : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public ViewStudent()
        {
            InitializeComponent();
        }

        public ViewStudent(int StudentID)
        {
            ID = StudentID;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DetailStudent frm = new DetailStudent();
            frm.Show();
            this.Hide();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from student where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            label7.Text = reader[1].ToString();
            label8.Text = reader[2].ToString();
            label9.Text = reader[3].ToString();
            label10.Text = reader[4].ToString();
            label11.Text = reader[5].ToString();
           

        }
    }
}

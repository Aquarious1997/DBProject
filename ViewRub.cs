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
    public partial class ViewRub : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public ViewRub()
        {
            InitializeComponent();
        }

        public ViewRub(int rubid)
        {
            ID = rubid;
            InitializeComponent();
        }

        private void ViewRub_Load(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from Rubric where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            label4.Text = reader[1].ToString();
            label5.Text = reader[2].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RubDetail frm = new RubDetail();
            frm.Show();
            this.Hide();
        }
    }
}

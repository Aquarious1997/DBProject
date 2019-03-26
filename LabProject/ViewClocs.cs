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
    public partial class ViewClocs : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        public int ID;
        public ViewClocs()
        {
            InitializeComponent();
        }

        public ViewClocs(int cloid)
        {
            ID = cloid;
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DetailCLO frm = new DetailCLO();
            frm.Show();
            this.Hide();
                
        }

        private void ViewClocs_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "select * from Clo where Id=" + ID + "";
            SqlCommand cmd = new SqlCommand(query1, con);
            var reader = cmd.ExecuteReader();
            reader.Read();
            label5.Text = reader[1].ToString();
            label6.Text = reader[2].ToString();
            label7.Text = reader[3].ToString();
            
        }
    }
}

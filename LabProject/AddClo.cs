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
    public partial class AddClo : Form
    {
        public AddClo()
        {

            InitializeComponent();
//Comment
        }
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";

        private void AddClo_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("data not successfully added");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetailCLO frm = new DetailCLO();
            frm.Show();
            this.Hide();
        }
    }
}

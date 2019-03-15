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
    public partial class AddRub : Form
    {
        ///<remarks> This is the connection string which connects to database </remarks>
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        
        public AddRub()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RubDetail frm = new RubDetail();
            frm.Show();
            this.Hide();
        }

        private void AddRub_Load(object sender, EventArgs e)
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
            comboBox1.Text = "Choose CLOs From Here";
                }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
           if (textBox1.Text!="")
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
                    MessageBox.Show("Rubrics Not");
                    textBox1.Text = " ";
                    comboBox1.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Fill the Detail Box");

            }
            
           

        }
    }
}

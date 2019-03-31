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
    public partial class Add_Student : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";
        
        public Add_Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Student_detail frm = new Student_detail();
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

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
                {
                    ///<remarks> Following Query getting LookupId from Lookup table from database
                    /// & comparing Name to our combobox
                    ///  </remarks>
                    string query1 = "Select LookupId from Lookup where Name='" + comboBox1.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(query1, con);
                    var dt = cmd2.ExecuteReader();
                    dt.Read();
                    int stateId = (int)dt.GetValue(0);
                    dt.Close();
                    ///<remarks> Following Query inserting our textboxes and combobox data into Student Table 
                    ///  </remarks>
                    string query = "INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "', '" + textBox6.Text.ToString() + "' , '" + textBox5.Text.ToString() + "' ," + stateId + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student successfully added");
                    textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " "; textBox6.Text = " "; textBox5.Text = " "; comboBox1.Text = " ";

                }
                else
                {
                    MessageBox.Show("Please fill all the boxes");
                }

            }
            else
            {
                MessageBox.Show("Database not connected make sure your connection");
            }
        }
    }
}

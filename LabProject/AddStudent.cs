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
    public partial class AddStudent : Form
    {
      
        /// <summary>
        /// This is default constructor of AddStudent class
        /// </summary>
        public AddStudent()
        {
            InitializeComponent();
        }
        ///<remarks> This is the connection string which connects to database </remarks>
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True";

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This button first check and add the data into database and
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
        
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
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
                    string query = "INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "', '" + textBox4.Text.ToString() + "' , '" + textBox5.Text.ToString() + "' ," + stateId + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data successfully added");
                    textBox1.Text = " "; textBox2.Text = " "; textBox3.Text = " "; textBox4.Text = " "; textBox5.Text = " "; comboBox1.Text = " ";

                }
                else
                {
                    MessageBox.Show("Please fill all the boxes");
                }
                
            }
            else
            {
                MessageBox.Show("Some sort of error");
            }
        }

        ///<remarks>
        /// This button take us to Student Detail form
        /// </remarks>
        private void button2_Click(object sender, EventArgs e)
        {
            DetailStudent frm = new DetailStudent();
            frm.Show();
            this.Hide();

        }
    }
}

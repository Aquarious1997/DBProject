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
    public partial class Report : Form
    {
        public string constr = "Data Source=DESKTOP-5DTSEQD;Initial Catalog=ProjectB;Integrated Security=True ";
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;
        public Report()
        {
            InitializeComponent();
        }
        private void viewR(string q)
        {
            SqlConnection con = new SqlConnection(constr);
            sda = new SqlDataAdapter(q, con);
            DataSet s = new DataSet();
            sda.Fill(s);
            dataGridView1.DataSource = s.Tables[0];
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Add_Result frm = new Add_Result();
            frm.Show();
            this.Hide();
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

        private void Report_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter(@"Select AssessmentComponent.Name,Rubric.Details,AssessmentComponent.TotalMarks,RubricLevel.Details,(count (Rubric.Details)* AssessmentComponent.TotalMarks)/4 as Total From (((  StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId = AssessmentComponent.Id) inner join RubricLevel on StudentResult.RubricMeasurementId = RubricLevel.Id) inner join Rubric on StudentResult.RubricMeasurementId=RubricLevel.Id And RubricLevel.RubricId = Rubric.Id) Group by AssessmentComponent.Name,Rubric.Details,AssessmentComponent.TotalMarks,RubricLevel.Details", constr);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

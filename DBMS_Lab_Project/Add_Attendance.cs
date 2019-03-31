using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Lab_Project
{
    public partial class Add_Attendance : Form
    {
        public Add_Attendance()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_studentAtt frm = new Add_studentAtt();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Student frm = new Add_Student();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Rubric_Level frm = new Add_Rubric_Level();
            frm.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Assessment frm = new Add_Assessment();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add_Result frm = new Add_Result();
            frm.Show();
            this.Hide();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

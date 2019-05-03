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
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

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
            sda = new SqlDataAdapter(@"Select AssessmentComponent.Name as Component,Rubric.Details as Rubric,AssessmentComponent.TotalMarks,RubricLevel.Details as Student_Rubric_Level,(count (Rubric.Details)* AssessmentComponent.TotalMarks)/4 as Total From (((  StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId = AssessmentComponent.Id) inner join RubricLevel on StudentResult.RubricMeasurementId = RubricLevel.Id) inner join Rubric on StudentResult.RubricMeasurementId=RubricLevel.Id And RubricLevel.RubricId = Rubric.Id) Group by AssessmentComponent.Name,Rubric.Details,AssessmentComponent.TotalMarks,RubricLevel.Details", constr);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        Document document = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));
                        document.Open();
                        PdfPTable pdftable = new PdfPTable(dt.Columns.Count);
                        pdftable.WidthPercentage = 100;
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[k].ColumnName));

                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(218, 247, 166);

                            pdftable.AddCell(cell);
                        }

                        //Add values of DataTable in pdf file
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(dt.Rows[i][j].ToString()));

                                //Align the cell in the center
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                                pdftable.AddCell(cell);
                            }
                        }
                        document.Add(pdftable);
                        document.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }

            }
        }
}

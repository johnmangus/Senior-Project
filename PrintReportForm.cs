using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace CSC440Project
{
    public partial class PrintReportForm : Form
    {
        public PrintReportForm()
        {
            InitializeComponent();
        }
        //When user clicks back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //When user clicks the Print Report Card button
        private void btnPrintReportCard_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate Student ID
                if (!int.TryParse(txtStudentID.Text, out int studentID))
                {
                    MessageBox.Show("Invalid Student ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Load student data
                var student = new Student();
                student.LoadStudentData(studentID);

                //Display student name
                txtStudentName.Text = student.Name;

                //Generate report card
                var reportCard = new ReportCard { Student = student };
                reportCard.LoadGrades(studentID);

                //Clear and set up DataGridView
                dgvReportCard.Rows.Clear();
                dgvReportCard.Columns.Clear();

                dgvReportCard.Columns.Add("Course", "Course");
                dgvReportCard.Columns.Add("Grade", "Grade");
                dgvReportCard.Columns.Add("CreditHours", "Credit Hours");
                dgvReportCard.Columns.Add("Semester", "Semester");

                //Populate DataGridView with students grades
                foreach (var grade in reportCard.Grades)
                {
                    dgvReportCard.Rows.Add(
                        $"{grade.Course.CoursePrefix} {grade.Course.CourseNumber}",
                        grade.GradeValue,
                        grade.Course.CreditHours,
                        $"{grade.Semester.SemesterName}, {grade.Semester.Year}"
                    );
                }

                // Display GPA
                txtGPA.Text = reportCard.CalculateGPA().ToString("0.00");
                MessageBox.Show($"Report Card for {student.Name} (ID: {student.StudentID}) generated successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

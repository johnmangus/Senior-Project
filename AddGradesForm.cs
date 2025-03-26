using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace CSC440Project
{
    public partial class AddGradesForm : Form
    {
        public AddGradesForm()
        {
            InitializeComponent();
        }
        //When user clicks button to add grade to database
        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate inputs
                if (!int.TryParse(txtStudentID.Text, out int studentID))
                {
                    MessageBox.Show("Invalid Student ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Course Prefix
                string coursePrefix = txtCoursePrefix.Text.Trim();
                if (string.IsNullOrEmpty(coursePrefix) || coursePrefix.Length > 4)
                {
                    MessageBox.Show("Invalid Course Prefix. Please enter a valid prefix (e.g., CSC).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //CourseNum
                if (!int.TryParse(txtCourseNumber.Text, out int courseNumber))
                {
                    MessageBox.Show("Invalid Course Number. Please enter a valid number (e.g., 340).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Grade
                string gradeInput = txtGrade.Text.Trim().ToUpper();
                if (!new[] { "A", "B", "C", "D", "F" }.Contains(gradeInput))
                {
                    MessageBox.Show("Invalid Grade. Please enter one of: A, B, C, D, F.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Semester
                string semesterName = txtSemester.Text.Trim().ToLower(); 
                if (!new[] { "fall", "spring", "summer", "winter" }.Contains(semesterName))
                {
                    MessageBox.Show("Invalid Semester. Please enter a valid semester (e.g., Fall, Spring).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Year
                if (!int.TryParse(txtYear.Text, out int year) || year < 1950 || year > 2024)
                {
                    MessageBox.Show("Invalid Year. Please enter a valid year between 1950-Current Year.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //CreditHours
                if (!int.TryParse(txtCreditHours.Text, out int creditHours) || creditHours < 1 || creditHours > 5)
                {
                    MessageBox.Show("Invalid Credit Hours. Please enter a valid entry for credit hours (e.g. between 1-5).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Load database entities
                var student = new Student();
                student.LoadStudentData(studentID);

                var course = new Course();
                course.LoadCourseData(coursePrefix, courseNumber);

                course.CreditHours = creditHours;

                var semester = new Semester();
                semester.LoadSemester(year, semesterName);

                var grade = txtGrade.Text.Trim().ToUpper();

                //Create and save the Grade
                var newGrade = new Grade
                {
                    Student = student,
                    Course = course,
                    GradeValue = grade[0],
                    Semester = semester
                };

                newGrade.Save();

                //Add the Grade to the DataGridView
                dgvGrades.Rows.Add(
                    student.StudentID,
                    $"{course.CoursePrefix} {course.CourseNumber}", //Combine Prefix/Num
                    grade,
                    semester.SemesterName,
                    semester.Year,
                    course.CreditHours
                );

                //Success
                MessageBox.Show("Grade added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //Failure
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //When the user clicks the back button 
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtSearchStudentAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchStudentAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCoursePrefixAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCourseNumberAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGradeAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYearSemesterAdd_TextChanged(object sender, EventArgs e)
        {

        }
        //What happens when add grade form loads
        private void AddGradesForm_Load(object sender, EventArgs e)
        {
            // Clear existing columns in case they already exist
            dgvGrades.Columns.Clear();

            //Add columns to the DataGridView
            dgvGrades.Columns.Add("StudentID", "Student ID");
            dgvGrades.Columns.Add("Course", "Course"); 
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Semester", "Semester");
            dgvGrades.Columns.Add("Year", "Year");
            dgvGrades.Columns.Add("CreditHours", "Credit Hours");

            //Dgv properties 
            dgvGrades.ReadOnly = true; 
            dgvGrades.AllowUserToAddRows = false; 
            dgvGrades.AllowUserToDeleteRows = false; 
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

            //Font and styles
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrades.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrades.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }
    }
}


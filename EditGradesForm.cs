using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    public partial class EditGradesForm : Form
    {
        public EditGradesForm()
        {
            InitializeComponent();

        }
         //When the user clicks the back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //When the user searches for student
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //database connection string
                string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

                //Validate the Student ID input
                if (!int.TryParse(txtStudentID.Text, out int studentID))
                {
                    MessageBox.Show("Invalid Student ID. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Load student data
                var student = new Student();
                student.LoadStudentData(studentID);

                //Clear existing rows in DGV
                dgvGrades.Rows.Clear();
                dgvGrades.Columns.Clear();

                //DGV columns (keep enrollmentID hidden)
                dgvGrades.Columns.Add("EnrollmentID", "EnrollmentID");
                dgvGrades.Columns["EnrollmentID"].Visible = false;
                dgvGrades.Columns.Add("Course", "Course");
                dgvGrades.Columns.Add("Grade", "Grade");
                dgvGrades.Columns.Add("CreditHours", "Credit Hours");
                dgvGrades.Columns.Add("Semester", "Semester");

                //Load grades for the student
                student.Grades = new List<Grade>();
                using (var connection = new MySqlConnection(connectionString))
                {
                    //query to load grades from enrollments, courses, semesters based on studentid
                    connection.Open();
                    string query = @"
                        SELECT 
                            e.EnrollmentID,
                            e.SemesterID,
                            c.CoursePrefix,
                            c.CourseNumber,
                            c.CreditHours,
                            e.Grade,
                            sem.SemesterName,
                            sem.Year
                        FROM 
                            jllEnrollments e
                        JOIN 
                            jllCourses c ON e.CourseID = c.CourseID
                        JOIN 
                            jllSemesters sem ON e.SemesterID = sem.SemesterID
                        WHERE 
                            e.StudentID = @studentID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentID", studentID);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var grade = new Grade
                                {
                                    EnrollmentID = Convert.ToInt32(reader["EnrollmentID"]),
                                    SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                    GradeValue = Convert.ToChar(reader["Grade"]),
                                    Course = new Course
                                    {
                                        CoursePrefix = reader["CoursePrefix"].ToString(),
                                        CourseNumber = Convert.ToInt32(reader["CourseNumber"]),
                                        CreditHours = Convert.ToInt32(reader["CreditHours"])
                                    },
                                    Semester = new Semester
                                    {
                                        SemesterName = reader["SemesterName"].ToString(),
                                        Year = Convert.ToInt32(reader["Year"])
                                    }
                                };
                                
                                student.Grades.Add(grade);
                            }
                        }
                    }
                }

                //Populate the DataGridView with the student's grades
                foreach (var grade in student.Grades)
                {
                    dgvGrades.Rows.Add(
                        grade.EnrollmentID,
                        $"{grade.Course.CoursePrefix} {grade.Course.CourseNumber}",
                        grade.GradeValue,
                        grade.Course.CreditHours,
                        $"{grade.Semester.SemesterName} {grade.Semester.Year}"
                    );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //When the user clicks the delete grade button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate that a row in DGV is selected
                if (dgvGrades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a grade to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Get EnrollmentID from the selected row
                var selectedRow = dgvGrades.SelectedRows[0];
                if (selectedRow.Cells["EnrollmentID"].Value == null)
                {
                    MessageBox.Show("Cannot delete the grade. EnrollmentID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int enrollmentID = Convert.ToInt32(selectedRow.Cells["EnrollmentID"].Value);

                //Confirm deletion
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this grade?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    //Delete the grade from the database
                    var grade = new Grade();
                    grade.Delete(enrollmentID);

                    //Refresh the DataGridView
                    RefreshGrades(int.Parse(txtStudentID.Text));

                    MessageBox.Show("Grade deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //When the user clicks the change grade button after selecting new grade
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                //Ensure a row is selected
                if (dgvGrades.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a grade to change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Validate the new grade input
                string newGrade = txtNewGrade.Text.Trim().ToUpper();
                if (!new[] { "A", "B", "C", "D", "F" }.Contains(newGrade))
                {
                    MessageBox.Show("Invalid Grade. Please enter one of: A, B, C, D, F.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Get the selected row
                var selectedRow = dgvGrades.SelectedRows[0];

                //Extract enrollmentID course and semester from row
                int enrollmentID = Convert.ToInt32(selectedRow.Cells["EnrollmentID"].Value);
                string course = selectedRow.Cells["Course"].Value.ToString();
                string semesterValue = selectedRow.Cells["Semester"].Value.ToString();

                //Split course into prefix and number
                string[] courseParts = course.Split(' '); // "CSC 195" -> ["CSC", "195"]
                string coursePrefix = courseParts[0];
                int courseNumber = int.Parse(courseParts[1]);

                //Get the SemesterID
                int semesterID = Semester.GetSemesterID(semesterValue);

                //Load the Grade object
                var grade = new Grade
                {
                    EnrollmentID = enrollmentID,
                    SemesterID = semesterID,
                    Course = new Course
                    {
                        CoursePrefix = coursePrefix,
                        CourseNumber = courseNumber
                    },
                    GradeValue = newGrade[0],
                    Student = new Student
                    {
                        StudentID = int.Parse(txtStudentID.Text) 
                    }
                };

                //Update the grade in the database
                grade.Update();

                //Update the grade in the DataGridView
                selectedRow.Cells["Grade"].Value = newGrade;

                MessageBox.Show("Grade updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Refresh the grades
                RefreshGrades(int.Parse(txtStudentID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Method to refresh the grades in dgv
        private void RefreshGrades(int studentID) { 
            try
            {
                // Connection string
                string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

                // Clear existing rows in the DataGridView
                dgvGrades.Rows.Clear();

                // Fetch grades from the database
                using (var connection = new MySqlConnection(connectionString))
                {
                    //query to pull grades for student
                    connection.Open();
                    string query = @"
                        SELECT 
                            e.EnrollmentID,
                            c.CoursePrefix,
                            c.CourseNumber,
                            c.CreditHours,
                            e.Grade,
                            sem.SemesterName,
                            sem.Year
                        FROM 
                            jllEnrollments e
                        JOIN 
                            jllCourses c ON e.CourseID = c.CourseID
                        JOIN 
                            jllSemesters sem ON e.SemesterID = sem.SemesterID
                        WHERE 
                            e.StudentID = @studentID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentID", studentID);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvGrades.Rows.Add(
                                    reader["EnrollmentID"],
                                    $"{reader["CoursePrefix"]} {reader["CourseNumber"]}",
                                    reader["Grade"],
                                    reader["CreditHours"],
                                    $"{reader["SemesterName"]} {reader["Year"]}"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //What happens when the edit grade form comes up
        private void EditGradesForm_Load(object sender, EventArgs e)
        {
            //Clear anything in dgv
            dgvGrades.Columns.Clear();
            //Reestablish approriate columns
            dgvGrades.Columns.Add("CoursePrefix", "Course Prefix");
            dgvGrades.Columns.Add("CourseNumber", "Course Number");
            dgvGrades.Columns.Add("Grade", "Grade");
            dgvGrades.Columns.Add("Semester", "Semester");
            dgvGrades.Columns.Add("Year", "Year");
            dgvGrades.Columns.Add("EnrollmentID", "EnrollmentID");

            dgvGrades.ReadOnly = true;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrades.Columns["EnrollmentID"].Visible = false;
        }
    }
}

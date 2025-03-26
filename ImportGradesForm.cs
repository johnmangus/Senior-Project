using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using OfficeOpenXml;

namespace CSC440Project
{
    public partial class ImportGradesForm : Form
    {
        public ImportGradesForm()
        {
            InitializeComponent();
        }
        //What happens when user clicks back button
        private void btnBackImport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Keep folder path as string to pull data from
        private string selectedFolderPath;

        //What happens when user clicks the select folder button
        private void btnSelectFolderImport_Click(object sender, EventArgs e)
        {
            //Bring up folder dialog to allow user to select folder
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderDialog.SelectedPath;

                    //Parse Excel files and display in DataGridView
                    ParseExcelFiles();

                    MessageBox.Show($"Folder selected: {selectedFolderPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //Method to read excel file data
        private void ParseExcelFiles()
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("Please select a folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Extract year and semester from the folder name
            (int year, string semester) = ExtractYearAndSemester(selectedFolderPath);

            //Clear the DataGridView
            dgvImportedGrades.Rows.Clear();
            dgvImportedGrades.Columns.Clear();

            //Add columns to the DataGridView
            dgvImportedGrades.Columns.Add("StudentID", "Student ID");
            dgvImportedGrades.Columns.Add("StudentName", "Student Name");
            dgvImportedGrades.Columns.Add("CoursePrefix", "Course Prefix");
            dgvImportedGrades.Columns.Add("CourseNumber", "Course Number");
            dgvImportedGrades.Columns.Add("Grade", "Grade");
            dgvImportedGrades.Columns.Add("Year", "Year");
            dgvImportedGrades.Columns.Add("Semester", "Semester");


            //Set EPPlus Licensing
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            //Parse all Excel files in the selected folder
            var files = Directory.GetFiles(selectedFolderPath, "*.xlsx"); // Fetch all Excel files
            //Loop through files
            foreach (var file in files)
            {
                try
                {
                    //Extract course info from the file name
                    (string coursePrefix, int courseNumber) = ExtractCourseInfo(file);

                    //Read Excel file
                    using (var package = new ExcelPackage(new FileInfo(file)))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; 
                        int row = 2; //Start from the second row 

                        while (worksheet.Cells[row, 1].Value != null)
                        {
                            //Parse row data based on project description structure
                            int studentID = Convert.ToInt32(worksheet.Cells[row, 2].Value);
                            string studentName = worksheet.Cells[row, 1].Value.ToString();
                            char grade = Convert.ToChar(worksheet.Cells[row, 3].Value);

                            // Add to DataGridView
                            dgvImportedGrades.Rows.Add(
                                studentID,
                                studentName,
                                coursePrefix,
                                courseNumber,
                                grade,
                                year,
                                semester
                            );

                            row++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error parsing file '{file}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Excel files parsed and displayed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Method to get year and semester from the folder path
        private (int year, string semester) ExtractYearAndSemester(string folderPath)
        {
            string folderName = Path.GetFileName(folderPath); //Get the folder name from the path
            var parts = folderName.Split(' '); 

            if (parts.Length != 3 || parts[0] != "Grades")
                throw new Exception("Invalid folder name format. Expected format: 'Grades [Year] [Semester]'.");

            int year = int.Parse(parts[1]); //Extract year
            string semester = parts[2]; //Extract semester

            return (year, semester);
        }
        //Method to extract course info that returns info from file format
        private (string coursePrefix, int courseNumber) ExtractCourseInfo(string fileName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName); //Take off .xls
            var parts = nameWithoutExtension.Split(' '); //Split the file name

            if (parts.Length != 4)
                throw new Exception("Invalid file name format. Expected format: '[Course Prefix] [Number] [Year] [Semester]'.");

            string coursePrefix = parts[0]; //Extract course prefix
            int courseNumber = int.Parse(parts[1]); //Extract course number

            return (coursePrefix, courseNumber);
        }


        private void dataGridViewGradePreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //What happens when user commits to import grades
        private void btnSubmitGrades_Click(object sender, EventArgs e)
        {
            try
            {
                //Each row in dgv
                foreach (DataGridViewRow row in dgvImportedGrades.Rows)
                {
                    if (row.Cells["StudentID"].Value == null) continue;

                    //Get data from row
                    int studentID = Convert.ToInt32(row.Cells["StudentID"].Value);
                    string coursePrefix = row.Cells["CoursePrefix"].Value.ToString();
                    int courseNumber = Convert.ToInt32(row.Cells["CourseNumber"].Value);
                    char grade = Convert.ToChar(row.Cells["Grade"].Value);
                    int year = Convert.ToInt32(row.Cells["Year"].Value);
                    string semester = row.Cells["Semester"].Value.ToString();

                    //Load entities and save to database
                    var student = new Student();
                    student.LoadStudentData(studentID);

                    var course = new Course();
                    course.LoadCourseData(coursePrefix, courseNumber);

                    var semesterEntity = new Semester();
                    semesterEntity.LoadSemester(year, semester);

                    var gradeEntity = new Grade
                    {
                        Student = student,
                        Course = course,
                        GradeValue = grade,
                        Semester = semesterEntity
                    };
                    //Save the grade to the database
                    gradeEntity.Save(); 
                }

                MessageBox.Show("Grades submitted to the database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Connect progress bar to show update of excel data
        private void progressBarImport_Click(object sender, EventArgs e)
        {

        }
    }
}

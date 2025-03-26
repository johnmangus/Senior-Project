using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    internal class ReportCard
    {
       //Getters and setters for Report Card
        public Student Student { get; set; }
        public List<Grade> Grades { get; set; }

        //database connection string
        private string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

        //Method to load student grades based on studentID
        public void LoadGrades(int studentID)
        {
            Grades = new List<Grade>();

            using (var connection = new MySqlConnection(connectionString))
            {
                //query to pull grade info - enrollments, course info - courses, semesterinfo - semesters
                connection.Open();
                string query = @"
                    SELECT 
                        c.CoursePrefix, c.CourseNumber, c.CreditHours, 
                        e.Grade, sem.SemesterName, sem.Year
                        FROM 
                        jllEnrollments e
                        INNER JOIN 
                        jllCourses c ON e.CourseID = c.CourseID
                        INNER JOIN 
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
                            Grades.Add(new Grade
                            {
                                Course = new Course
                                {
                                    CoursePrefix = reader["CoursePrefix"].ToString(),
                                    CourseNumber = Convert.ToInt32(reader["CourseNumber"]),
                                    CreditHours = Convert.ToInt32(reader["CreditHours"])
                                },
                                GradeValue = Convert.ToChar(reader["Grade"]),
                                Semester = new Semester
                                {
                                    SemesterName = reader["SemesterName"].ToString(),
                                    Year = Convert.ToInt32(reader["Year"])
                                }
                            });
                        }
                    }
                }
            }
        }

        //Method to calculate GPA
        public double CalculateGPA()
        {
            if (Grades.Count == 0) return 0.0;

            double totalPoints = 0;
            int totalCredits = 0;

            foreach (var grade in Grades)
            {
                totalPoints += grade.GetGradePoints() * grade.Course.CreditHours;
                totalCredits += grade.Course.CreditHours;
            }

            return totalCredits > 0 ? totalPoints / totalCredits : 0.0;
        }

        //Method to generate the report card (probably not using)
        public string GenerateReport()
        {
            var report = new StringBuilder();

            report.AppendLine($"Report Card for {Student.Name} (ID: {Student.StudentID})");
            report.AppendLine($"Overall GPA: {CalculateGPA():0.00}");
            report.AppendLine();
            report.AppendLine("Courses:");
            report.AppendLine("-----------------------------------------------------");

            foreach (var grade in Grades)
            {
                report.AppendLine($"{grade.Course.CoursePrefix} {grade.Course.CourseNumber} - {grade.Course.Title} ({grade.Course.CreditHours} Credit Hours): {grade.GradeValue} ({grade.Semester.SemesterName}, {grade.Semester.Year})");
            }

            return report.ToString();
        }

    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    internal class Grade
    {
        //Getters and setters for Grade
        public Student Student { get; set; }
        public Course Course { get; set; }
        public char GradeValue { get; set; }
        public Semester Semester { get; set; }
        public int EnrollmentID { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public int SemesterID { get; set; }

        //Database connection string
        private string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";


        //Method to update grade
        public void Update()
        {
            try
            {
                //Debugging: Check if student/course/semesterID are null
                if (Student == null)
                    throw new NullReferenceException("Student is null.");
                if (Course == null)
                    throw new NullReferenceException("Course is null.");
                if (SemesterID == 0)
                    throw new NullReferenceException("SemesterID is missing or invalid.");

                

                //If all checks pass, update in database
                using (var connection = new MySqlConnection(connectionString))
                {
                    //query to update in database (both enrollments and courses)
                    connection.Open();
                    string query = @"
                    UPDATE jllEnrollments 
                    SET Grade = @grade 
                    WHERE StudentID = @studentID 
                    AND CourseID = (SELECT CourseID FROM jllCourses WHERE CoursePrefix = @coursePrefix AND CourseNumber = @courseNumber)
                    AND SemesterID = @semesterID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@grade", GradeValue);
                        command.Parameters.AddWithValue("@studentID", Student.StudentID);
                        command.Parameters.AddWithValue("@coursePrefix", Course.CoursePrefix);
                        command.Parameters.AddWithValue("@courseNumber", Course.CourseNumber);
                        command.Parameters.AddWithValue("@semesterID", SemesterID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update grade: {ex.Message}", ex);
            }
        }
         //Method to delete grade (remember to bring in enrollmentID)
        public void Delete(int enrollmentID)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    //query to delete from enrollments table
                    connection.Open();
                    string query = "DELETE FROM jllEnrollments WHERE enrollmentID = @enrollmentID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@enrollmentID", enrollmentID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete grade: {ex.Message}", ex);
            }
        }


        //Method to save in database
        public void Save()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //query that saves in enrollments, courses, and semesters tables
                connection.Open();
                string query = @"
                    INSERT INTO jllEnrollments (StudentID, CourseID, SemesterID, Grade) 
                    VALUES (@studentID, 
                    (SELECT CourseID FROM jllCourses WHERE CoursePrefix = @coursePrefix AND CourseNumber = @courseNumber), 
                    (SELECT SemesterID FROM jllSemesters WHERE SemesterName = @semester AND Year = @year), 
                    @grade)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", Student.StudentID);
                    command.Parameters.AddWithValue("@coursePrefix", Course.CoursePrefix);
                    command.Parameters.AddWithValue("@courseNumber", Course.CourseNumber);
                    command.Parameters.AddWithValue("@semester", Semester.SemesterName);
                    command.Parameters.AddWithValue("@year", Semester.Year);
                    command.Parameters.AddWithValue("@grade", GradeValue);

                    command.ExecuteNonQuery();
                }
            }
        }
        //Method to fetch student grades based on studentID
        public static List<Grade> FetchGradesForStudent(int studentID)
        {
            var grades = new List<Grade>();

            string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

            using (var connection = new MySqlConnection(connectionString))
            {
                //query that pulls student/course info from enrollments/courses/semesters
                connection.Open();
                string query = @"
                    SELECT e.Grade, c.CoursePrefix, c.CourseNumber, c.CreditHours, 
                           s.SemesterName, s.Year, c.CourseID, s.SemesterID
                    FROM jllEnrollments e
                    INNER JOIN jllCourses c ON e.CourseID = c.CourseID
                    INNER JOIN jllSemesters s ON e.SemesterID = s.SemesterID
                    WHERE e.StudentID = @studentID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", studentID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(new Grade
                            {
                                GradeValue = Convert.ToChar(reader["Grade"]),
                                Course = new Course
                                {
                                    CourseID = Convert.ToInt32(reader["CourseID"]),
                                    CoursePrefix = reader["CoursePrefix"].ToString(),
                                    CourseNumber = Convert.ToInt32(reader["CourseNumber"]),
                                    CreditHours = Convert.ToInt32(reader["CreditHours"])
                                },
                                Semester = new Semester
                                {
                                    SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                    SemesterName = reader["SemesterName"].ToString(),
                                    Year = Convert.ToInt32(reader["Year"])
                                },
                                Student = new Student
                                {
                                    StudentID = studentID
                                }
                            });
                        }
                    }
                }
            }

            return grades;
        }
        //Method to load grades into dgv
        public void LoadGrades(int studentID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //query to load student grades from enrollments table
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
                        Grades = new List<Grade>();
                        //Iterate through results and populate grade list
                        while (reader.Read())
                        {
                            var grade = new Grade
                            {
                                EnrollmentID = Convert.ToInt32(reader["EnrollmentID"]),
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
                            };
                            //call method to add grade
                            Grades.Add(grade);
                        }
                    }
                }
            }
        }

        //Method to get grade points for student to be used for GPA Calc
        public double GetGradePoints()
        {
            switch (GradeValue)
            {
                case 'A': return 4.0;
                case 'B': return 3.0;
                case 'C': return 2.0;
                case 'D': return 1.0;
                case 'F': return 0.0;
                default: return 0.0;
            }
        }
    }
}

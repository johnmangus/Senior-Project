using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    internal class Student
    {
        //Getter and setters for student
        public int StudentID { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();

        //Database connection string
        private string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

        //Method to load student data based on studentID
        public void LoadStudentData(int studentID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //Fetch student by studentID
                connection.Open();
                string query = "SELECT StudentID, Name FROM jllStudents WHERE StudentID = @studentID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", studentID);

                    using (var reader = command.ExecuteReader())
                    {
                        //If record found, populate studentID/Name
                        if (reader.Read())
                        {
                            this.StudentID = Convert.ToInt32(reader["StudentID"]);
                            this.Name = reader["Name"].ToString();
                            return;
                        }
                    }
                }

                //If no student found, add the student to the database
                MessageBox.Show($"Student with ID {studentID} not found. Adding the student...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Insert student query
                string insertQuery = "INSERT INTO jllStudents (StudentID, Name) VALUES (@studentID, @name)";
                using (var insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@studentID", studentID);
                    insertCommand.Parameters.AddWithValue("@name", $"Student {studentID}"); // Default name
                    insertCommand.ExecuteNonQuery();
                }

                //Reload the student data after insertion
                LoadStudentData(studentID);
            }
        }



        //Method to calculate students GPA
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
    }
}


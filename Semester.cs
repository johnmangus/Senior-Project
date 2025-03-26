using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    internal class Semester
    {
        //Getters and setters for Semester
        public int SemesterID { get; set; }
        public int Year { get; set; }
        public string SemesterName { get; set; }

        //Database connection string
        private static string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

        //Method to load the semester 
        public void LoadSemester(int year, string semesterName)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //query to load semester from semesters table
                connection.Open();
                string query = "SELECT SemesterID FROM jllSemesters WHERE Year = @year AND SemesterName = @semesterName";

                using (var command = new MySqlCommand(query, connection))
                {
                    //Bind parameters to prevent SQL injection attacks
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@semesterName", semesterName);

                    using (var reader = command.ExecuteReader())
                    {
                        //If mathing semester found
                        if (reader.Read())
                        {
                            //Get objects properties
                            this.SemesterID = Convert.ToInt32(reader["SemesterID"]);
                            this.Year = year;
                            this.SemesterName = semesterName;
                            return;
                        }
                    }
                }

                //If the semester does not exist, insert it
                string insertQuery = "INSERT INTO jllSemesters (Year, SemesterName) VALUES (@year, @semesterName)";
                using (var insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@year", year);
                    insertCommand.Parameters.AddWithValue("@semesterName", semesterName);
                    insertCommand.ExecuteNonQuery();
                }

                //Reload the semester after inserting
                LoadSemester(year, semesterName);
            }
        }

        //Method to GetSemesterID from Semester
        public static int GetSemesterID(string semester)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                //Split input string into parts
                string[] semesterParts = semester.Split(' ');
                string semesterName = semesterParts[0];
                int year = int.Parse(semesterParts[1]);
                //query to pull semester id from semesters table based on semester
                string query = "SELECT SemesterID FROM jllSemesters WHERE SemesterName = @semesterName AND Year = @year";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@semesterName", semesterName);
                    command.Parameters.AddWithValue("@year", year);

                    object result = command.ExecuteScalar();
                    //Return matching semesterid if not return 0
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

    }
}

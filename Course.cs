using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC440Project
{
    internal class Course
    {
        //Getters and setters for Course
        public int CourseID { get; set; }
        public string CoursePrefix { get; set; }
        public int CourseNumber { get; set; }
        public string Title { get; set; }
        public int CreditHours { get; set; }
        //Database connection string
        private string connectionString = "server=csitmariadb.eku.edu;port=3306;database=csc340_db;uid=student;pwd=Maroon@21?";

        //Method to load course data based on courseID
        public void LoadCourseData(int courseID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //query to get course info from courseID
                connection.Open();
                string query = "SELECT * FROM jllCourses WHERE courseID = @courseID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseID", courseID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.CourseID = courseID;
                            this.CoursePrefix = reader["coursePrefix"].ToString();
                            this.CourseNumber = Convert.ToInt32(reader["courseNumber"]);
                            this.Title = reader["courseTitle"].ToString();
                            this.CreditHours = Convert.ToInt32(reader["creditHours"]);
                        }
                    }
                }
            }
        }
        //Method to load courseData based on coursePrefix and Number
        public void LoadCourseData(string coursePrefix, int courseNumber)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT CourseID, CoursePrefix, CourseNumber, CreditHours 
                    FROM jllCourses 
                    WHERE CoursePrefix = @coursePrefix AND CourseNumber = @courseNumber";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                    command.Parameters.AddWithValue("@courseNumber", courseNumber);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Retrieve the data
                            this.CourseID = Convert.ToInt32(reader["CourseID"]);
                            this.CoursePrefix = reader["CoursePrefix"].ToString();
                            this.CourseNumber = Convert.ToInt32(reader["CourseNumber"]);
                            this.CreditHours = Convert.ToInt32(reader["CreditHours"]);
                            return;
                        }
                    }
                }

                //If the course does not exist, insert it into the database
                MessageBox.Show($"Course {coursePrefix} {courseNumber} not found. Adding the course...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string insertQuery = @"
            INSERT INTO jllCourses (CoursePrefix, CourseNumber, CreditHours) 
            VALUES (@coursePrefix, @courseNumber, @creditHours)";

                using (var insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@coursePrefix", coursePrefix);
                    insertCommand.Parameters.AddWithValue("@courseNumber", courseNumber);
                    insertCommand.Parameters.AddWithValue("@creditHours", this.CreditHours > 0 ? this.CreditHours : 3); // Use CreditHours or default to 3
                    insertCommand.ExecuteNonQuery();
                }

                // Reload the course data after insertion
                LoadCourseData(coursePrefix, courseNumber);
            }
        }

    }
}

namespace CSC440Project
{
    partial class AddGradesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubmitGradeAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtCoursePrefix = new System.Windows.Forms.TextBox();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.txtCourseNumber = new System.Windows.Forms.TextBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.lblMessageAddGrade = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreditHours = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmitGradeAdd
            // 
            this.btnSubmitGradeAdd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSubmitGradeAdd.Location = new System.Drawing.Point(365, 401);
            this.btnSubmitGradeAdd.Name = "btnSubmitGradeAdd";
            this.btnSubmitGradeAdd.Size = new System.Drawing.Size(140, 23);
            this.btnSubmitGradeAdd.TabIndex = 2;
            this.btnSubmitGradeAdd.Text = "Add Grade";
            this.btnSubmitGradeAdd.UseVisualStyleBackColor = true;
            this.btnSubmitGradeAdd.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(180, 65);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(98, 22);
            this.txtStudentID.TabIndex = 7;
            this.txtStudentID.TextChanged += new System.EventHandler(this.txtSearchStudentAdd_TextChanged);
            // 
            // txtCoursePrefix
            // 
            this.txtCoursePrefix.Location = new System.Drawing.Point(180, 108);
            this.txtCoursePrefix.Name = "txtCoursePrefix";
            this.txtCoursePrefix.Size = new System.Drawing.Size(100, 22);
            this.txtCoursePrefix.TabIndex = 9;
            this.txtCoursePrefix.TextChanged += new System.EventHandler(this.txtCoursePrefixAdd_TextChanged);
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.CoursePrefix,
            this.CourseNumber,
            this.Grade,
            this.Semester,
            this.Year});
            this.dgvGrades.Location = new System.Drawing.Point(295, 86);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 24;
            this.dgvGrades.Size = new System.Drawing.Size(493, 283);
            this.dgvGrades.TabIndex = 10;
            this.dgvGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellContentClick);
            // 
            // txtCourseNumber
            // 
            this.txtCourseNumber.Location = new System.Drawing.Point(180, 166);
            this.txtCourseNumber.Name = "txtCourseNumber";
            this.txtCourseNumber.Size = new System.Drawing.Size(100, 22);
            this.txtCourseNumber.TabIndex = 11;
            this.txtCourseNumber.TextChanged += new System.EventHandler(this.txtCourseNumberAdd_TextChanged);
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(180, 223);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(100, 22);
            this.txtGrade.TabIndex = 12;
            this.txtGrade.TextChanged += new System.EventHandler(this.txtGradeAdd_TextChanged);
            // 
            // txtSemester
            // 
            this.txtSemester.Location = new System.Drawing.Point(180, 281);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(100, 22);
            this.txtSemester.TabIndex = 13;
            this.txtSemester.TextChanged += new System.EventHandler(this.txtYearSemesterAdd_TextChanged);
            // 
            // lblMessageAddGrade
            // 
            this.lblMessageAddGrade.AutoSize = true;
            this.lblMessageAddGrade.Location = new System.Drawing.Point(212, 369);
            this.lblMessageAddGrade.Name = "lblMessageAddGrade";
            this.lblMessageAddGrade.Size = new System.Drawing.Size(0, 16);
            this.lblMessageAddGrade.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Student ID ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Course Number (e.g. 440)";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Semester (e.g. Fall, Spring)";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(180, 332);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 22);
            this.txtYear.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Year (e.g. 2024)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Course Prefix (e.g. CSC)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Grade (e.g. A,B,C...)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(166, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(427, 42);
            this.label9.TabIndex = 26;
            this.label9.Text = "ADD STUDENT GRADE";
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            this.StudentID.Width = 125;
            // 
            // CoursePrefix
            // 
            this.CoursePrefix.HeaderText = "Course Prefix";
            this.CoursePrefix.MinimumWidth = 6;
            this.CoursePrefix.Name = "CoursePrefix";
            this.CoursePrefix.Width = 125;
            // 
            // CourseNumber
            // 
            this.CourseNumber.HeaderText = "Course Number";
            this.CourseNumber.MinimumWidth = 6;
            this.CourseNumber.Name = "CourseNumber";
            this.CourseNumber.Width = 125;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.MinimumWidth = 6;
            this.Grade.Name = "Grade";
            this.Grade.Width = 125;
            // 
            // Semester
            // 
            this.Semester.HeaderText = "Semester";
            this.Semester.MinimumWidth = 6;
            this.Semester.Name = "Semester";
            this.Semester.Width = 125;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 125;
            // 
            // txtCreditHours
            // 
            this.txtCreditHours.Location = new System.Drawing.Point(180, 378);
            this.txtCreditHours.Name = "txtCreditHours";
            this.txtCreditHours.Size = new System.Drawing.Size(100, 22);
            this.txtCreditHours.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Credit Hours (e.g. 1,3,5)";
            // 
            // AddGradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCreditHours);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessageAddGrade);
            this.Controls.Add(this.txtSemester);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.txtCourseNumber);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.txtCoursePrefix);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmitGradeAdd);
            this.Name = "AddGradesForm";
            this.Text = "AddGradesForm";
            this.Load += new System.EventHandler(this.AddGradesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSubmitGradeAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtCoursePrefix;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.TextBox txtCourseNumber;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.Label lblMessageAddGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursePrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.TextBox txtCreditHours;
        private System.Windows.Forms.Label label10;
    }
}
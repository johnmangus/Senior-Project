using System;
using System.Windows.Forms;

namespace CSC440Project
{
    partial class EditGradesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtNewGrade = new System.Windows.Forms.TextBox();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblMessagedEditGrade = new System.Windows.Forms.Label();
            this.lblMessageEditGrade = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Student Grades";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(150, 56);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(100, 22);
            this.txtStudentID.TabIndex = 19;
            // 
            // txtNewGrade
            // 
            this.txtNewGrade.Location = new System.Drawing.Point(209, 354);
            this.txtNewGrade.Name = "txtNewGrade";
            this.txtNewGrade.Size = new System.Drawing.Size(100, 22);
            this.txtNewGrade.TabIndex = 17;
            // 
            // dgvGrades
            // 
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Location = new System.Drawing.Point(15, 106);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 24;
            this.dgvGrades.Size = new System.Drawing.Size(773, 234);
            this.dgvGrades.TabIndex = 5;
            this.dgvGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridStudents_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter Student ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter New Grade (A,B,C,D,F)";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(15, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblMessagedEditGrade
            // 
            this.lblMessagedEditGrade.AutoSize = true;
            this.lblMessagedEditGrade.Location = new System.Drawing.Point(464, 402);
            this.lblMessagedEditGrade.Name = "lblMessagedEditGrade";
            this.lblMessagedEditGrade.Size = new System.Drawing.Size(0, 16);
            this.lblMessagedEditGrade.TabIndex = 11;
            // 
            // lblMessageEditGrade
            // 
            this.lblMessageEditGrade.AutoSize = true;
            this.lblMessageEditGrade.Location = new System.Drawing.Point(15, 364);
            this.lblMessageEditGrade.Name = "lblMessageEditGrade";
            this.lblMessageEditGrade.Size = new System.Drawing.Size(0, 16);
            this.lblMessageEditGrade.TabIndex = 16;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(269, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search Student";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(680, 356);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 24);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete Grade";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(327, 344);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(101, 43);
            this.btnChange.TabIndex = 22;
            this.btnChange.Text = "Change Grade";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // EditGradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblMessageEditGrade);
            this.Controls.Add(this.lblMessagedEditGrade);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.txtNewGrade);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label1);
            this.Name = "EditGradesForm";
            this.Text = "EditGradesForm";
            this.Load += new System.EventHandler(this.EditGradesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtNewGrade;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblMessagedEditGrade;
        private Label lblMessageEditGrade;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnChange;
    }
}
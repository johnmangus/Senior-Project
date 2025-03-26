namespace CSC440Project
{
    partial class PrintReportForm
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
            this.btnPrintReportCard = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvReportCard = new System.Windows.Forms.DataGridView();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessagePrintReport = new System.Windows.Forms.Label();
            this.lblGPA = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportCard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintReportCard
            // 
            this.btnPrintReportCard.Location = new System.Drawing.Point(223, 49);
            this.btnPrintReportCard.Name = "btnPrintReportCard";
            this.btnPrintReportCard.Size = new System.Drawing.Size(131, 32);
            this.btnPrintReportCard.TabIndex = 9;
            this.btnPrintReportCard.Text = "Print Transcript";
            this.btnPrintReportCard.Click += new System.EventHandler(this.btnPrintReportCard_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(10, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvReportCard
            // 
            this.dgvReportCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportCard.ColumnHeadersHeight = 29;
            this.dgvReportCard.Location = new System.Drawing.Point(12, 101);
            this.dgvReportCard.Name = "dgvReportCard";
            this.dgvReportCard.RowHeadersVisible = false;
            this.dgvReportCard.RowHeadersWidth = 51;
            this.dgvReportCard.Size = new System.Drawing.Size(768, 319);
            this.dgvReportCard.TabIndex = 10;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(100, 54);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(95, 22);
            this.txtStudentID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID:";
            // 
            // lblMessagePrintReport
            // 
            this.lblMessagePrintReport.AutoSize = true;
            this.lblMessagePrintReport.Location = new System.Drawing.Point(85, 404);
            this.lblMessagePrintReport.Name = "lblMessagePrintReport";
            this.lblMessagePrintReport.Size = new System.Drawing.Size(0, 16);
            this.lblMessagePrintReport.TabIndex = 6;
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.Location = new System.Drawing.Point(628, 60);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(84, 16);
            this.lblGPA.TabIndex = 7;
            this.lblGPA.Text = "Overall GPA:";
            // 
            // txtGPA
            // 
            this.txtGPA.Location = new System.Drawing.Point(718, 57);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.ReadOnly = true;
            this.txtGPA.Size = new System.Drawing.Size(59, 22);
            this.txtGPA.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(482, 57);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(140, 22);
            this.txtStudentName.TabIndex = 12;
            // 
            // PrintReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGPA);
            this.Controls.Add(this.lblGPA);
            this.Controls.Add(this.lblMessagePrintReport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrintReportCard);
            this.Controls.Add(this.dgvReportCard);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label1);
            this.Name = "PrintReportForm";
            this.Text = "PrintReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrintReportCard;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvReportCard;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessagePrintReport;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentName;
    }
}
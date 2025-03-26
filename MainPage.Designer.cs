namespace CSC440Project
{
    partial class Form1
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
            this.btnAddGrade = new System.Windows.Forms.Button();
            this.btnEditGrade = new System.Windows.Forms.Button();
            this.btnPrintReportCard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportGrades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.Location = new System.Drawing.Point(197, 121);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(155, 51);
            this.btnAddGrade.TabIndex = 0;
            this.btnAddGrade.Text = "Add Grade";
            this.btnAddGrade.UseVisualStyleBackColor = true;
            this.btnAddGrade.Click += new System.EventHandler(this.btnAddGrade_Click);
            // 
            // btnEditGrade
            // 
            this.btnEditGrade.Location = new System.Drawing.Point(436, 121);
            this.btnEditGrade.Name = "btnEditGrade";
            this.btnEditGrade.Size = new System.Drawing.Size(145, 51);
            this.btnEditGrade.TabIndex = 1;
            this.btnEditGrade.Text = "Edit Grades";
            this.btnEditGrade.UseVisualStyleBackColor = true;
            this.btnEditGrade.Click += new System.EventHandler(this.btnEditGrade_Click);
            // 
            // btnPrintReportCard
            // 
            this.btnPrintReportCard.Location = new System.Drawing.Point(436, 245);
            this.btnPrintReportCard.Name = "btnPrintReportCard";
            this.btnPrintReportCard.Size = new System.Drawing.Size(248, 53);
            this.btnPrintReportCard.TabIndex = 2;
            this.btnPrintReportCard.Text = "Print Report Card/Transcript";
            this.btnPrintReportCard.UseVisualStyleBackColor = true;
            this.btnPrintReportCard.Click += new System.EventHandler(this.btnPrintReportCard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(741, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "EKU Registrar Grade Management System";
            // 
            // btnImportGrades
            // 
            this.btnImportGrades.Location = new System.Drawing.Point(199, 246);
            this.btnImportGrades.Name = "btnImportGrades";
            this.btnImportGrades.Size = new System.Drawing.Size(153, 51);
            this.btnImportGrades.TabIndex = 4;
            this.btnImportGrades.Text = "Import Grades";
            this.btnImportGrades.UseVisualStyleBackColor = true;
            this.btnImportGrades.Click += new System.EventHandler(this.btnImportGrades_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImportGrades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintReportCard);
            this.Controls.Add(this.btnEditGrade);
            this.Controls.Add(this.btnAddGrade);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddGrade;
        private System.Windows.Forms.Button btnEditGrade;
        private System.Windows.Forms.Button btnPrintReportCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportGrades;
    }
}


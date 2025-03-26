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
            this.btnAddGrades = new System.Windows.Forms.Button();
            this.btnEditGrades = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddGrades
            // 
            this.btnAddGrades.Location = new System.Drawing.Point(195, 93);
            this.btnAddGrades.Name = "btnAddGrades";
            this.btnAddGrades.Size = new System.Drawing.Size(116, 23);
            this.btnAddGrades.TabIndex = 0;
            this.btnAddGrades.Text = "Add Grades";
            this.btnAddGrades.UseVisualStyleBackColor = true;
            this.btnAddGrades.Click += new System.EventHandler(this.btnAddGrades_Click);
            // 
            // btnEditGrades
            // 
            this.btnEditGrades.Location = new System.Drawing.Point(257, 164);
            this.btnEditGrades.Name = "btnEditGrades";
            this.btnEditGrades.Size = new System.Drawing.Size(119, 23);
            this.btnEditGrades.TabIndex = 1;
            this.btnEditGrades.Text = "Edit Grades";
            this.btnEditGrades.UseVisualStyleBackColor = true;
            this.btnEditGrades.Click += new System.EventHandler(this.btnEditGrades_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(378, 111);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(120, 23);
            this.btnPrintReport.TabIndex = 2;
            this.btnPrintReport.Text = "Print Report Card/Transcript";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registrar Grade Management System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnEditGrades);
            this.Controls.Add(this.btnAddGrades);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddGrades;
        private System.Windows.Forms.Button btnEditGrades;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Label label1;
    }
}


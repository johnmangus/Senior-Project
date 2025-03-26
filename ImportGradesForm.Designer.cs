namespace CSC440Project
{
    partial class ImportGradesForm
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
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblMessageImport = new System.Windows.Forms.Label();
            this.dgvImportedGrades = new System.Windows.Forms.DataGridView();
            this.btnSubmitGrades = new System.Windows.Forms.Button();
            this.lblMessageImportGrades = new System.Windows.Forms.Label();
            this.btnBackImport = new System.Windows.Forms.Button();
            this.lblMessageImport1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(321, 70);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(138, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolderImport_Click);
            // 
            // lblMessageImport
            // 
            this.lblMessageImport.AutoSize = true;
            this.lblMessageImport.Location = new System.Drawing.Point(79, 85);
            this.lblMessageImport.Name = "lblMessageImport";
            this.lblMessageImport.Size = new System.Drawing.Size(0, 16);
            this.lblMessageImport.TabIndex = 1;
            // 
            // dgvImportedGrades
            // 
            this.dgvImportedGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImportedGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportedGrades.Location = new System.Drawing.Point(12, 104);
            this.dgvImportedGrades.Name = "dgvImportedGrades";
            this.dgvImportedGrades.RowHeadersVisible = false;
            this.dgvImportedGrades.RowHeadersWidth = 51;
            this.dgvImportedGrades.RowTemplate.Height = 24;
            this.dgvImportedGrades.Size = new System.Drawing.Size(776, 284);
            this.dgvImportedGrades.TabIndex = 3;
            this.dgvImportedGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGradePreview_CellContentClick);
            // 
            // btnSubmitGrades
            // 
            this.btnSubmitGrades.Location = new System.Drawing.Point(303, 394);
            this.btnSubmitGrades.Name = "btnSubmitGrades";
            this.btnSubmitGrades.Size = new System.Drawing.Size(167, 44);
            this.btnSubmitGrades.TabIndex = 4;
            this.btnSubmitGrades.Text = "Commit Changes";
            this.btnSubmitGrades.UseVisualStyleBackColor = true;
            this.btnSubmitGrades.Click += new System.EventHandler(this.btnSubmitGrades_Click);
            // 
            // lblMessageImportGrades
            // 
            this.lblMessageImportGrades.AutoSize = true;
            this.lblMessageImportGrades.Location = new System.Drawing.Point(164, 381);
            this.lblMessageImportGrades.Name = "lblMessageImportGrades";
            this.lblMessageImportGrades.Size = new System.Drawing.Size(0, 16);
            this.lblMessageImportGrades.TabIndex = 5;
            // 
            // btnBackImport
            // 
            this.btnBackImport.Location = new System.Drawing.Point(24, 12);
            this.btnBackImport.Name = "btnBackImport";
            this.btnBackImport.Size = new System.Drawing.Size(75, 23);
            this.btnBackImport.TabIndex = 6;
            this.btnBackImport.Text = "Back";
            this.btnBackImport.UseVisualStyleBackColor = true;
            this.btnBackImport.Click += new System.EventHandler(this.btnBackImport_Click);
            // 
            // lblMessageImport1
            // 
            this.lblMessageImport1.AutoSize = true;
            this.lblMessageImport1.Location = new System.Drawing.Point(235, 335);
            this.lblMessageImport1.Name = "lblMessageImport1";
            this.lblMessageImport1.Size = new System.Drawing.Size(0, 16);
            this.lblMessageImport1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "IMPORT STUDENT GRADES";
            // 
            // ImportGradesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessageImport1);
            this.Controls.Add(this.btnBackImport);
            this.Controls.Add(this.lblMessageImportGrades);
            this.Controls.Add(this.btnSubmitGrades);
            this.Controls.Add(this.dgvImportedGrades);
            this.Controls.Add(this.lblMessageImport);
            this.Controls.Add(this.btnSelectFolder);
            this.Name = "ImportGradesForm";
            this.Text = "ImportGradesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblMessageImport;
        private System.Windows.Forms.DataGridView dgvImportedGrades;
        private System.Windows.Forms.Button btnSubmitGrades;
        private System.Windows.Forms.Label lblMessageImportGrades;
        private System.Windows.Forms.Button btnBackImport;
        private System.Windows.Forms.Label lblMessageImport1;
        private System.Windows.Forms.Label label1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC440Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Add grades page
        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            AddGradesForm addGradesForm = new AddGradesForm();
            addGradesForm.Show();
        }

        //Edit grades page
        private void btnEditGrade_Click(object sender, EventArgs e)
        {
            EditGradesForm editGradeForm = new EditGradesForm();
            editGradeForm.Show();
        }

        //Print report card page
        private void btnPrintReportCard_Click(object sender, EventArgs e)
        {
            PrintReportForm printReportForm = new PrintReportForm();
            printReportForm.Show();
        }

        //Import grades page
        private void btnImportGrades_Click(object sender, EventArgs e)
        {
            var importGradesForm = new ImportGradesForm();
            importGradesForm.ShowDialog();
        }
    }
}

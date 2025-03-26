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

        private void btnAddGrades_Click(object sender, EventArgs e)
        {
            AddGradesForm addGradesForm = new AddGradesForm();
            addGradesForm.Show();
        }

        private void btnEditGrades_Click(object sender, EventArgs e)
        {
            EditGradesForm editGradesForm = new EditGradesForm();
            editGradesForm.Show();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            PrintReportForm printReportForm = new PrintReportForm();
            printReportForm.Show();
        }
    }
}

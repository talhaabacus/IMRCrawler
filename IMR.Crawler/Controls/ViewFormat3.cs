using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMR.Crawler.Helper;

namespace IMR.Crawler.Controls
{
    public partial class ViewFormat3 : UserControl
    {
        private int _treatmentID;
        public ViewFormat3()
        {
            InitializeComponent();
        }

        public void LoadData(int tID)
        {
            _treatmentID = tID;
            DBHelper helper = new DBHelper();
            Treatment treat = helper.GetTreatment(_treatmentID);
            Format3Detail det = helper.GetFormat3Detail(_treatmentID);
            if ((treat != null) && (det != null))
            {
                txtCaseNumber.Text = treat.CaseNumber;
                txtIMRIssues.Text = det.Rationales;
                txtIssueAtDispute.Text = det.IssueAtDispute;
                txtCaseSummary.Text = det.CaseSummary;
                txtDiagnosis.Text = det.Diagnosis;
                txtDocumentsReviewed.Text = det.DocumentsReviewed;
                txtGuidelines.Text = det.TreatmentGuidelines;
                txtReviewerQualification.Text = det.ReviewerQualifications;

                txtAge.Text = det.Age.ToString();
                txtGender.Text = det.Gender;


            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Could not load Data");
            }

        }
    }
}

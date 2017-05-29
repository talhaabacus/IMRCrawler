using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IMR.Crawler.Helper;

namespace IMR.Crawler.Controls
{
    public partial class ViewFormat2 : UserControl
    {
        private int _treatmentID;

        public ViewFormat2()
        {
            InitializeComponent();
        }


        public void LoadData(int tID)
        {
            _treatmentID = tID;
            DBHelper helper = new DBHelper();
            Treatment treat = helper.GetTreatment(_treatmentID);
            PDFDetail det = helper.GetPDFDetail(_treatmentID);
            if ((treat != null) && (det != null))
            {
                txtCaseNumber.Text = treat.CaseNumber;
                if (det.URDenialDate.HasValue)
                    txtURDenial.Text = det.URDenialDate.Value.ToString("MM/dd/yyyy");


                txtHowIMRDetermination.Text = det.HowIMRDetermination;
                txtClinicalCaseSummary.Text = det.ClinicalCaseSummary;
                txtIMRIssues.Text = det.IMRIssuesRationales;
                txtDocumentsReviewed.Text = det.DocumentsReviewed;



            }
            else
            {
                MessageBoxEx.Show("Could not load Data");
            }

        }
    }
}

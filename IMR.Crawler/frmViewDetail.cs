using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IMR.Crawler.Helper;

namespace IMR.Crawler
{
    public partial class frmViewDetail : Office2007Form
    {
        private int _treatmentID;
        private PDFFormatEnum _format;
        public frmViewDetail(int tID, PDFFormatEnum format)
        {
            InitializeComponent();
            _treatmentID = tID;
            _format = format;
        }

        public void LoadData()
        {
            if (_format == PDFFormatEnum.Format1)
            {
                tbFormat1.Visible = true;
                viewFormat11.Visible = true;
                viewFormat11.LoadData(_treatmentID);
                tbOther.Visible = false;
                tbFormat2.Visible = false;
                tbFormat3.Visible = false;
            }
            else if (_format == PDFFormatEnum.Format2)
            {
                tbFormat1.Visible = false;
                tbOther.Visible = false;
                tbFormat3.Visible = false;
                tbFormat2.Visible = true;
                viewFormat21.Visible = true;
                viewFormat21.LoadData(_treatmentID);
            }
            else if (_format == PDFFormatEnum.Format3)
            {
                tbFormat1.Visible = false;
                tbOther.Visible = false;
                tbFormat2.Visible = false;
                tbFormat3.Visible = true;
                viewFormat31.Visible = true;
                viewFormat31.LoadData(_treatmentID);
            }
            else
            {
                tbFormat1.Visible = false;
                tbFormat2.Visible = false;
                tbFormat3.Visible = false;
                DBHelper helper = new DBHelper();
                Treatment t = helper.GetTreatment(_treatmentID);

                tbOther.Visible = true;
                txtPDFtext.Text = t.PDFText;

            }

        }
    }
}

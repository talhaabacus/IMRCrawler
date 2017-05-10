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
using System.Diagnostics;

namespace IMR.Crawler
{
    public partial class DataSearch : UserControl
    {
        private int totalRecords;
        private const int pageSize = 10;
        private bool isDetail = false;
        public static event LoggingHandler LogHandler;


        public DataSearch()
        {
            InitializeComponent();



        }

        protected void Log(string message, MessageType messageType)
        {
            if (LogHandler != null)
                LogHandler(message, messageType);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try { 
            isDetail = false;
            grdResults.DataSource = null;
            grdResults.Rows.Clear();
            grdResults.Columns.Clear();
            IList<SearchCaseResult> res = null;
            DBHelper helper = new DBHelper();
            res = helper.SearchCase(txtSearch.Text, txtCaseNo.Text);
            if (res.Count > 0)
            {

                grdResults.DataSource = res;
                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.HeaderText = " ";
                bcol.Text = "View Details";
                bcol.Name = "btnDetails";
                bcol.UseColumnTextForButtonValue = true;
                grdResults.Columns.Add(bcol);

                DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                bcol1.HeaderText = " ";
                bcol1.Text = "View PDF";
                bcol1.Name = "btnView";
                bcol1.UseColumnTextForButtonValue = true;
                grdResults.Columns.Add(bcol1);
                grdResults.Columns[0].Visible = false;
                grdResults.Columns[10].Visible = false;
                grdResults.Columns[11].Visible = false;
                grdResults.Columns[12].Visible = false;
                    grdResults.Columns[1].HeaderText = "Case Number";
                    grdResults.Columns[2].HeaderText = "Case Outcome";
                    grdResults.Columns[3].HeaderText = "Decision Date";
                    grdResults.Columns[4].HeaderText = "Date of Injury";
                    grdResults.Columns[5].HeaderText = "Received Date";
                    grdResults.Columns[6].HeaderText = "IMRO Reviewer Specialty";
                    grdResults.Columns[7].HeaderText = "Request Category";
                    grdResults.Columns[8].HeaderText = "SubCategory/Drug";
                    grdResults.Columns[9].HeaderText = "Request Decision";

                }
                else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "No results found for the selected Search Criteria.", "No Results", MessageBoxButtons.OK);
            }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "Could not perform search" + "\n" + ex.Message, "Exception");
                Log("Could not perform search" + "\n" + ex.ToString(), MessageType.Exception);

            }
        }

        private void grdResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isDetail == false)
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex == 14))
                {
                    string pdfLoc = ((SearchCaseResult)grdResults.Rows[e.RowIndex].DataBoundItem).LocalPDFLoc;
                    if (System.IO.File.Exists(pdfLoc))
                        Process.Start(pdfLoc);
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("PDF does not exist.", "Message");
                }
                else if ((e.RowIndex >= 0) && (e.ColumnIndex == 13))
                {
                    SearchCaseResult res = ((SearchCaseResult)grdResults.Rows[e.RowIndex].DataBoundItem);
                    int tID = res.TreatmentID;
                    PDFFormatEnum f = PDFFormatEnum.Other;
                    if (res.PDFFormatID.HasValue)
                        f = (PDFFormatEnum)res.PDFFormatID.Value;
                    var frm = new frmViewDetail(tID, f);
                    frm.LoadData();
                    frm.ShowDialog();

                }
            }
            else
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex == 14))
                {
                    string pdfLoc = ((SearchCaseDetailResult)grdResults.Rows[e.RowIndex].DataBoundItem).LocalPDFLoc;
                    if (System.IO.File.Exists(pdfLoc))
                        Process.Start(pdfLoc);
                    else
                        DevComponents.DotNetBar.MessageBoxEx.Show("PDF does not exist.", "Message");
                
                }
                else if ((e.RowIndex >= 0) && (e.ColumnIndex == 13))
                {
                    SearchCaseDetailResult res = ((SearchCaseDetailResult)grdResults.Rows[e.RowIndex].DataBoundItem);
                    int tID = res.TreatmentID;
                    PDFFormatEnum f = PDFFormatEnum.Other;
                    if (res.PDFFormatID.HasValue)
                        f = (PDFFormatEnum)res.PDFFormatID.Value;
                    var frm = new frmViewDetail(tID, f);
                    frm.LoadData();
                    frm.ShowDialog();

                }
            }


        }

        private void grdResults_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (((e.ColumnIndex == 13) || (e.ColumnIndex == 14)) && (grdResults.Rows[e.RowIndex].Cells[12].Value != null))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtCaseNo.Text = "";

        }

        private void btnSearchSeparate_Click(object sender, EventArgs e)
        {
            try

            {
                isDetail = true;
                grdResults.DataSource = null;
                grdResults.Rows.Clear();
                grdResults.Columns.Clear();
                int age = 0;
                if (txtAge.Text != "")
                {
                    if (!int.TryParse(txtAge.Text, out age))
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(this, "Please enter numeric value for age");
                        txtAge.Focus();
                        txtAge.SelectAll();
                        return;
                    }
                }

                if( (txtGender.Text !="") &&  (!(System.Text.RegularExpressions.Regex.IsMatch(txtGender.Text, "^[a-zA-Z]+$"))))
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, "Please enter proper value for gender");
                    txtGender.Focus();
                    txtGender.SelectAll();
                    return;
                }
                IList<SearchCaseDetailResult> res = null;
                DBHelper helper = new DBHelper();
                res = helper.SearchCaseDetail(age, txtGender.Text, txtState.Text, txtSpecialty.Text, txtDiagnosis.Text);
                if (res.Count > 0)
                {

                    grdResults.DataSource = res;
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = " ";
                    bcol.Text = "View Details";
                    bcol.Name = "btnDetails";
                    bcol.UseColumnTextForButtonValue = true;
                    grdResults.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.HeaderText = " ";
                    bcol1.Text = "View PDF";
                    bcol1.Name = "btnView";
                    bcol1.UseColumnTextForButtonValue = true;
                    grdResults.Columns.Add(bcol1);
                    grdResults.Columns[0].Visible = false;
                    grdResults.Columns[10].Visible = false;
                    grdResults.Columns[11].Visible = false;
                    grdResults.Columns[12].Visible = false;

                    grdResults.Columns[1].HeaderText = "Case Number";
                    grdResults.Columns[2].HeaderText = "Case Outcome";
                    grdResults.Columns[3].HeaderText = "Decision Date";
                    grdResults.Columns[4].HeaderText = "Date of Injury";
                    grdResults.Columns[5].HeaderText = "Received Date";
                    grdResults.Columns[6].HeaderText = "IMRO Reviewer Specialty";
                    grdResults.Columns[7].HeaderText = "Request Category";
                    grdResults.Columns[8].HeaderText = "SubCategory/Drug";
                    grdResults.Columns[9].HeaderText = "Request Decision";




                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, "No results found for the selected Search Criteria.", "No Results", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "Could not perform search" + "\n" + ex.Message, "Exception");
                Log("Could not perform search" + "\n" + ex.ToString(), MessageType.Exception);

            }
        }

        private void btnClearSeparate_Click(object sender, EventArgs e)
        {
            txtAge.Text = "";
            txtDiagnosis.Text = "";
            txtGender.Text = "";
            txtSpecialty.Text = "";
            txtState.Text = "";
        }
    }
}

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
using IMR.Crawler.Model;
using HtmlAgilityPack;
using IMR.Crawler.Configuration;
using System.IO;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using org.apache.pdfbox.pdmodel.encryption;

namespace IMR.Crawler
{
    public enum SearchType
    {
        Case,
        Treatment

    }
    public partial class WebSearch : UserControl
    {
        private string _url = "https://www.dir.ca.gov/dwc/imr/IMRDecisionSearch.asp";
        private string _hostName = "www.dir.ca.gov";
        private string _origin = "https://www.dir.ca.gov";
        private int _currentPage = 1;
        BackgroundWorker worker1 = null;

        private SearchType _type;
        private bool _isNext;
        private bool _isPrevious;
        private int _toDownload;
        private int _downloaded;
        private int _success;
        private int _failed;
        private string _errorMessage;
        private int _totalpages;
        public static event LoggingHandler LogHandler;

        public WebSearch()
        {
            InitializeComponent();
        }
        protected void Log(string message, MessageType messageType)
        {
            if (LogHandler != null)
                LogHandler(message, messageType);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCaseNo.Text = "";
            dtInjuryStart.Text = "";
            dtInjuryEnd.Text = "";
            dtIMRStart.Text = "";
            dtIMREnd.Text = "";
            dtDecisionStart.Text = "";
            dtDecisionEnd.Text = "";
            cmbIMROut.SelectedIndex = -1;
            cmbSpeciality.SelectedIndex = -1;

        }

        private void btnTClear_Click(object sender, EventArgs e)
        {
            txtTCaseNo.Text = "";
            dtTInjuryStart.Text = "";
            dtTInjuryEnd.Text = "";
            dtTIMRStart.Text = "";
            dtTIMREnd.Text = "";
            dtTDecisionStart.Text = "";
            dtTDecisionEnd.Text = "";
            cmbTSpeciality.SelectedIndex = -1;
            cmbTOut.SelectedIndex = -1;
            cmbTSubCategory.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "";

            grdResults.DataSource = null;

            grdResults.Columns.Clear();
            txtPageNumber.Text = "";
            _type = SearchType.Case;
            _currentPage = 1;
            _totalpages = 0;
            LoadCaseData();

        }

        private void btnTSubmit_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "";

            grdResults.DataSource = null;

            grdResults.Columns.Clear();
            txtPageNumber.Text = "";
            _currentPage = 1;
            _type = SearchType.Treatment;
            _totalpages = 0;
            LoadTreatmentData();


        }

        private void LoadTreatmentData()
        {

            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            btnDownload.Enabled = false;
            btnDownloadExtract.Enabled = false;
            btnExtract.Enabled = false;
            btnSelectAll.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnGo.Enabled = false;
            txtPageNumber.Enabled = false;
            pb1.Visible = true;
            ribbonBar1.Refresh();
            string data = "";
            data += "Fname=Tx";
            data += "&Caseno=" + Uri.EscapeDataString(txtTCaseNo.Text);
            data += "&DoIStart=" + Uri.EscapeDataString(dtTInjuryStart.Text);
            data += "&DoIEnd=" + Uri.EscapeDataString(dtTInjuryEnd.Text);
            data += "&ReqStart=" + Uri.EscapeDataString(dtTIMRStart.Text);
            data += "&ReqEnd=" + Uri.EscapeDataString(dtTIMREnd.Text);
            data += "&DecStart=" + Uri.EscapeDataString(dtTDecisionStart.Text);
            data += "&DecEnd=" + Uri.EscapeDataString(dtTDecisionEnd.Text);
            if (cmbTSpeciality.SelectedIndex > 0)
            {
                data += "&SpecialtyV=" + Uri.EscapeDataString(((DevComponents.Editors.ComboItem)cmbTSpeciality.SelectedItem).Value.ToString());
            }
            else
                data += "&SpecialtyV=";
            if (cmbTOut.SelectedIndex > 0)
            {
                data += "&OutcomeV=" + Uri.EscapeDataString(((DevComponents.Editors.ComboItem)cmbTOut.SelectedItem).Value.ToString());
            }
            else
                data += "&OutcomeV=";

            if (cmbTSubCategory.SelectedIndex > 0)
            {
                data += "&SubCategoryV=" + Uri.EscapeDataString(((DevComponents.Editors.ComboItem)cmbTSubCategory.SelectedItem).Value.ToString());
            }
            else
                data += "&SubCategoryV=";


            if (_currentPage > 1)
            {
                data += "&newpageno=" + _currentPage + "&Submit=Next";
            }
            else
            {
                data += "&Submit=Submit";
            }


            List<SearchResult> treatments = new List<SearchResult>();
            worker1 = new BackgroundWorker { WorkerReportsProgress = true };

            DoWorkEventHandler doWork = (sender1, e1) =>
            {

                try
                {
                    CrawlerHelper ch = new CrawlerHelper();
                    string html = "";

                    html = ch.PostWebData(_url, _hostName, _origin, data);



                    if (html.Length > 0)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                        htmlDoc.OptionFixNestedTags = true;

                        htmlDoc.LoadHtml(html);

                        var xx = from x in htmlDoc.DocumentNode.Descendants()
                                 where x.Name == "table" && (x.Attributes["class"] != null && x.Attributes["class"].Value == "tabborder")
                                 select x;
                        HtmlNode tableNode = null;
                        if (xx.Count<HtmlAgilityPack.HtmlNode>() > 0)
                        {
                            tableNode = xx.First<HtmlAgilityPack.HtmlNode>();
                        }

                        var yy = from x in htmlDoc.DocumentNode.Descendants()
                                 where x.Name == "form" && (x.Attributes["name"] != null && x.Attributes["name"].Value == "Nextpage")
                                 select x;

                        HtmlNode nextPage = null;
                        if (yy.Count<HtmlAgilityPack.HtmlNode>() > 0)
                        {
                            nextPage = yy.First<HtmlAgilityPack.HtmlNode>();

                        }
                        if (nextPage != null)
                        {
                            btnNext.Enabled = true;
                        }
                        else
                        {
                            btnNext.Enabled = false;
                        }

                        if (tableNode != null)
                        {

                            string totresults = tableNode.NextSibling.NextSibling.SelectSingleNode(".//strong").InnerHtml;
                            var thNodes = tableNode.SelectNodes(".//tr");
                            int iii = 0;
                            string parentCaseNumber = "";
                            SearchResult parentTreat = null;
                            foreach (HtmlNode hnd in thNodes)
                            {
                                iii++;
                                if (iii > 1)
                                {
                                    SearchResult treat = new Model.SearchResult();
                                    treat.IsSelected = true;
                                    var tdNodes = hnd.SelectNodes(".//td");

                                    if ((tdNodes[0].Attributes["colspan"] != null) && (tdNodes[0].Attributes["colspan"].Value == "5"))
                                    {
                                        treat.RequestCategory = System.Web.HttpUtility.HtmlDecode(tdNodes[1].InnerHtml);
                                        treat.SubCategory = System.Web.HttpUtility.HtmlDecode(tdNodes[2].InnerHtml);
                                        treat.RequestDecision = System.Web.HttpUtility.HtmlDecode(tdNodes[3].InnerHtml);
                                        treat.ParentCaseNumber = parentCaseNumber;
                                        treat.CaseNumber = parentTreat.CaseNumber;
                                        treat.DecisionDate = parentTreat.DecisionDate;
                                        treat.DateOfInjury = parentTreat.DateOfInjury;
                                        treat.RecievedDate = parentTreat.RecievedDate;
                                        treat.IMROSpeciality = parentTreat.IMROSpeciality;


                                    }
                                    else
                                    {
                                        treat.PDFUrl = _origin + hnd.SelectSingleNode(".//td[1]/a").Attributes["href"].Value.ToString();
                                        treat.CaseNumber = hnd.SelectSingleNode(".//td[1]/a").InnerText;
                                        treat.DecisionDate = tdNodes[1].InnerHtml;
                                        treat.DateOfInjury = tdNodes[2].InnerHtml;
                                        treat.RecievedDate = tdNodes[3].InnerHtml;
                                        treat.IMROSpeciality = System.Web.HttpUtility.HtmlDecode(tdNodes[4].InnerHtml);
                                        treat.RequestCategory = System.Web.HttpUtility.HtmlDecode(tdNodes[5].InnerHtml);
                                        treat.SubCategory = System.Web.HttpUtility.HtmlDecode(tdNodes[6].InnerHtml);
                                        treat.RequestDecision = System.Web.HttpUtility.HtmlDecode(tdNodes[7].InnerHtml);
                                        parentCaseNumber = treat.CaseNumber;
                                        parentTreat = treat;
                                    }
                                    treatments.Add(treat);

                                }
                            }
                            _totalpages = (int)(Math.Ceiling((decimal.Parse(totresults) / 25)));
                            lblTotal.Text = "Total: " + totresults + " results." + "\n" + "Page: " + _currentPage + " of " + _totalpages;



                        }
                    }
                }
                catch (Exception ex)
                {
                    treatments = null;
                    throw ex;
                }
            };
            worker1.DoWork += doWork;
            RunWorkerCompletedEventHandler runcomplete = (sender4, e4) =>
            {

                if (e4.Error != null)
                {
                    Log(e4.Error.ToString(), MessageType.Error);

                    DevComponents.DotNetBar.MessageBoxEx.Show(this, e4.Error.ToString(), "Exception");
                }
                else
                {
                    if (treatments.Count > 0)
                    {

                        grdResults.DataSource = treatments;
                        grdResults.Columns[0].Width = 25;
                        grdResults.Columns[1].ReadOnly = true;
                        grdResults.Columns[2].ReadOnly = true;
                        grdResults.Columns[3].ReadOnly = true;
                        grdResults.Columns[4].ReadOnly = true;
                        grdResults.Columns[5].ReadOnly = true;
                        grdResults.Columns[6].ReadOnly = true;
                        grdResults.Columns[7].ReadOnly = true;
                        grdResults.Columns[8].ReadOnly = true;
                        grdResults.Columns[9].ReadOnly = true;

                        grdResults.Columns[1].Visible = false;
                        grdResults.Columns[11].Visible = false;
                        grdResults.Columns[3].Visible = false;
                        grdResults.Columns[12].Visible = false;
                        grdResults.Columns[13].Visible = false;

                        grdResults.Columns[0].HeaderText = "";
                        grdResults.Columns[2].HeaderText = "Case Number";
                        grdResults.Columns[4].HeaderText = "Decision Date";
                        grdResults.Columns[5].HeaderText = "Date of Injury";
                        grdResults.Columns[6].HeaderText = "Received Date";
                        grdResults.Columns[7].HeaderText = "IMRO Reviewer Specialty";
                        grdResults.Columns[8].HeaderText = "Request Category";
                        grdResults.Columns[9].HeaderText = "SubCategory/Drug";
                        grdResults.Columns[10].HeaderText = "Request Decision";



                    }

                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(this, "No results found for the selected Search Criteria.", "No Results", MessageBoxButtons.OK);
                    }


                    if (_currentPage > 1)
                    {
                        btnPrevious.Enabled = true;
                    }
                    else
                    {
                        btnPrevious.Enabled = false;
                    }

                    if ((_currentPage > 1) || (btnNext.Enabled))
                    {
                        btnGo.Enabled = true;
                        txtPageNumber.Enabled = true;
                    }

                }
                pb1.Visible = false;
                if (grdResults.Rows.Count > 0)
                {
                    btnDownload.Enabled = true;
                    btnDownloadExtract.Enabled = true;
                    btnExtract.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnSelectAll.Enabled = true;
                }
                ribbonBar1.Refresh();

            };

            worker1.RunWorkerCompleted += runcomplete;

            try
            {
                worker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                Log(string.Concat("Search loading exception " + ex.ToString()), MessageType.Error);
                DevComponents.DotNetBar.MessageBoxEx.Show(this, string.Concat("Search loading exception " + ex.ToString()), "Message");
            }


        }
        private void LoadCaseData()
        {

            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            btnDownload.Enabled = false;
            btnDownloadExtract.Enabled = false;
            btnExtract.Enabled = false;
            btnDeselectAll.Enabled = false;
            btnSelectAll.Enabled = false;
            txtPageNumber.Enabled = false;
            btnGo.Enabled = false;

            pb1.Visible = true;
            ribbonBar1.Refresh();
            string data = "";
            data += "Fname=Case";
            data += "&Caseno=" + Uri.EscapeDataString(txtCaseNo.Text);
            data += "&DoIStart=" + Uri.EscapeDataString(dtInjuryStart.Text);
            data += "&DoIEnd=" + Uri.EscapeDataString(dtInjuryEnd.Text);
            data += "&ReqStart=" + Uri.EscapeDataString(dtIMRStart.Text);
            data += "&ReqEnd=" + Uri.EscapeDataString(dtIMREnd.Text);
            data += "&DecStart=" + Uri.EscapeDataString(dtDecisionStart.Text);
            data += "&DecEnd=" + Uri.EscapeDataString(dtDecisionEnd.Text);
            if (cmbSpeciality.SelectedIndex > 0)
            {
                data += "&SpecialtyV=" + Uri.EscapeDataString(((DevComponents.Editors.ComboItem)cmbSpeciality.SelectedItem).Value.ToString());
            }
            else
                data += "&SpecialtyV=";
            if (cmbIMROut.SelectedIndex > 0)
            {
                data += "&CaseOutcomeV=" + Uri.EscapeDataString(((DevComponents.Editors.ComboItem)cmbIMROut.SelectedItem).Value.ToString());
            }
            else
                data += "&CaseOutcomeV=";
            if (_currentPage > 1)
            {
                data += "&newpageno=" + _currentPage + "&Submit=Next";
            }
            else
            {
                data += "&Submit=Submit";
            }


            List<SearchResult> cases = new List<SearchResult>();
            worker1 = new BackgroundWorker { WorkerReportsProgress = true };

            DoWorkEventHandler doWork = (sender1, e1) =>
            {

                try
                {
                    CrawlerHelper ch = new CrawlerHelper();
                    string html = "";

                    html = ch.PostWebData(_url, _hostName, _origin, data);



                    if (html.Length > 0)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                        htmlDoc.OptionFixNestedTags = true;

                        htmlDoc.LoadHtml(html);

                        var xx = from x in htmlDoc.DocumentNode.Descendants()
                                 where x.Name == "table" && (x.Attributes["class"] != null && x.Attributes["class"].Value == "tabborder")
                                 select x;
                        HtmlNode tableNode = null;
                        if (xx.Count<HtmlAgilityPack.HtmlNode>() > 0)
                        {
                            tableNode = xx.First<HtmlAgilityPack.HtmlNode>();
                        }

                        var yy = from x in htmlDoc.DocumentNode.Descendants()
                                 where x.Name == "form" && (x.Attributes["name"] != null && x.Attributes["name"].Value == "Nextpage")
                                 select x;

                        HtmlNode nextPage = null;
                        if (yy.Count<HtmlAgilityPack.HtmlNode>() > 0)
                        {
                            nextPage = yy.First<HtmlAgilityPack.HtmlNode>();

                        }
                        if (nextPage != null)
                        {
                            btnNext.Enabled = true;

                        }
                        else
                        {
                            btnNext.Enabled = false;
                        }


                        if (tableNode != null)
                        {

                            string totresults = tableNode.NextSibling.NextSibling.SelectSingleNode(".//strong").InnerHtml;
                            var thNodes = tableNode.SelectNodes(".//tr");
                            int iii = 0;
                            foreach (HtmlNode hnd in thNodes)
                            {
                                iii++;
                                if (iii > 1)
                                {
                                    SearchResult cs = new Model.SearchResult();
                                    var tdNodes = hnd.SelectNodes(".//td");
                                    cs.IsSelected = true;
                                    cs.PDFUrl = _origin + hnd.SelectSingleNode(".//td[1]/a").Attributes["href"].Value.ToString();
                                    if (hnd.SelectSingleNode(".//td[1]").InnerHtml.IndexOf("<strong>+</strong>") > 0)
                                        cs.hasMoreData = true;
                                    else
                                        cs.hasMoreData = false;
                                    cs.CaseNumber = hnd.SelectSingleNode(".//td[1]/a").InnerText;
                                    cs.CaseOutcome = tdNodes[1].InnerHtml;
                                    cs.DecisionDate = tdNodes[2].InnerHtml;
                                    cs.DateOfInjury = tdNodes[3].InnerHtml;
                                    cs.RecievedDate = tdNodes[4].InnerHtml;
                                    cs.IMROSpeciality = System.Web.HttpUtility.HtmlDecode(tdNodes[5].InnerHtml);
                                    cases.Add(cs);

                                }
                            }
                            _totalpages = (int)(Math.Ceiling((decimal.Parse(totresults) / 25)));
                            lblTotal.Text = "Total: " + totresults + " results." + "\n" + "Page: " + _currentPage + " of " + _totalpages; ;



                        }
                    }
                }
                catch (Exception ex)
                {
                    cases = null;
                    throw ex;
                }
            };
            worker1.DoWork += doWork;
            RunWorkerCompletedEventHandler runcomplete = (sender4, e4) =>
            {

                if (e4.Error != null)
                {
                    Log(e4.Error.ToString(), MessageType.Error);

                    DevComponents.DotNetBar.MessageBoxEx.Show(this, e4.Error.ToString(), "Exception");
                }
                else
                {
                    if (cases.Count > 0)
                    {

                        grdResults.DataSource = cases;
                        grdResults.Columns[0].Width = 25;
                        grdResults.Columns[1].ReadOnly = true;
                        grdResults.Columns[2].ReadOnly = true;
                        grdResults.Columns[3].ReadOnly = true;
                        grdResults.Columns[4].ReadOnly = true;
                        grdResults.Columns[5].ReadOnly = true;
                        grdResults.Columns[6].ReadOnly = true;
                        grdResults.Columns[7].ReadOnly = true;

                        grdResults.Columns[1].Visible = false;
                        grdResults.Columns[8].Visible = false;
                        grdResults.Columns[9].Visible = false;
                        grdResults.Columns[10].Visible = false;
                        grdResults.Columns[11].Visible = false;
                        grdResults.Columns[12].Visible = false;
                        grdResults.Columns[13].Visible = false;

                        grdResults.Columns[0].HeaderText = "";
                        grdResults.Columns[2].HeaderText = "Case Number";
                        grdResults.Columns[3].HeaderText = "Case Outcome";
                        grdResults.Columns[4].HeaderText = "Decision Date";
                        grdResults.Columns[5].HeaderText = "Date of Injury";
                        grdResults.Columns[6].HeaderText = "Received Date";
                        grdResults.Columns[7].HeaderText = "IMRO Reviewer Specialty";

                        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                        bcol.HeaderText = " ";
                        bcol.Text = "+";
                        bcol.Name = "btnDetails";
                        bcol.UseColumnTextForButtonValue = true;
                        bcol.Width = 25;
                        grdResults.Columns.Add(bcol);
                        grdResults.Columns[14].Width = 25;
                    }

                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(this, "No results found for the selected Search Criteria.", "No Results", MessageBoxButtons.OK);
                    }


                    if (_currentPage > 1)
                    {
                        btnPrevious.Enabled = true;
                    }
                    else
                    {
                        btnPrevious.Enabled = false;
                    }
                    if ((_currentPage > 1) || (btnNext.Enabled))
                    {
                        btnGo.Enabled = true;
                        txtPageNumber.Enabled = true;
                    }
                }
                pb1.Visible = false;

                if (grdResults.Rows.Count > 0)
                {
                    btnDownload.Enabled = true;
                    btnDownloadExtract.Enabled = true;
                    btnExtract.Enabled = true;
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                }
                ribbonBar1.Refresh();

            };

            worker1.RunWorkerCompleted += runcomplete;

            try
            {
                worker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                Log(string.Concat("Search loading exception " + ex.ToString()), MessageType.Error);
                DevComponents.DotNetBar.MessageBoxEx.Show(this, string.Concat("Search loading exception " + ex.ToString()), "Message");
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentPage -= 1;
            lblTotal.Text = "";
            txtPageNumber.Text = "";
            ribbonBar1.Refresh();
            grdResults.DataSource = null;

            grdResults.Columns.Clear();
            if (_type == SearchType.Case)
            {
                LoadCaseData();
            }
            else
            {
                LoadTreatmentData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage += 1;
            lblTotal.Text = "";
            txtPageNumber.Text = "";
            ribbonBar1.Refresh();
            grdResults.DataSource = null;

            grdResults.Columns.Clear();
            if (_type == SearchType.Case)
            {
                LoadCaseData();
            }
            else
            {
                LoadTreatmentData();
            }
        }

        private void grdResults_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if ((e.ColumnIndex == 0) && (grdResults.Rows[e.RowIndex].Cells[11].Value != null))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
                if (_type == SearchType.Case)
                {
                    if ((e.ColumnIndex == 14) && ((bool)grdResults.Rows[e.RowIndex].Cells[13].Value != true))
                    {
                        e.PaintBackground(e.ClipBounds, true);
                        e.Handled = true;
                    }
                }
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            grdResults.CancelEdit();
            grdResults.ClearSelection();
            foreach (DataGridViewRow r in grdResults.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                chk.Value = true;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            grdResults.CancelEdit();
            grdResults.ClearSelection();
            foreach (DataGridViewRow r in grdResults.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                chk.Value = chk.FalseValue;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            grdResults.EndEdit();
            if (AppConfig.PDFSaveLocation != "")
            {
                if (!Directory.Exists(AppConfig.PDFSaveLocation))
                    Directory.CreateDirectory(AppConfig.PDFSaveLocation);

                _errorMessage = "";
                List<SearchResult> treatments = new List<SearchResult>();
                foreach (DataGridViewRow r in grdResults.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                    if ((bool)chk.Value == true)
                    {
                        SearchResult t = (SearchResult)r.DataBoundItem;
                        if (t.PDFUrl != null)
                        {
                            t.RowIndex = r.Index;
                            treatments.Add(t);
                            bool hasChild = true;
                            int index = t.RowIndex + 1;

                            while (hasChild)
                            {
                                if (index < grdResults.RowCount)
                                {
                                    SearchResult childTreat = (SearchResult)grdResults.Rows[index].DataBoundItem;
                                    if (childTreat.ParentCaseNumber == t.CaseNumber)
                                    {
                                        childTreat.RowIndex = index;
                                        treatments.Add(childTreat);
                                        index++;
                                    }
                                    else
                                        hasChild = false;
                                }
                                else
                                    hasChild = false;
                            }
                        }
                    }
                }
                _toDownload = treatments.Count;
                pb1.Visible = true;
                pb1.Text = "Downloading files....";

                _isNext = btnNext.Enabled;
                _isPrevious = btnPrevious.Enabled;

                btnDownload.Enabled = false;
                btnExtract.Enabled = false;
                btnDownloadExtract.Enabled = false;
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSubmit.Enabled = false;
                btnTClear.Enabled = false;
                btnClear.Enabled = false;
                btnTSubmit.Enabled = false;
                ribbonBar1.Refresh();
                _downloaded = 0;
                _success = 0;
                _failed = 0;
                worker1 = new BackgroundWorker { WorkerReportsProgress = true };

                DoWorkEventHandler doWork = (sender1, e1) =>
                {

                    try
                    {
                        Parallel.ForEach(treatments, new ParallelOptions { MaxDegreeOfParallelism = 10 }, DownloadPDF);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };
                worker1.DoWork += doWork;
                RunWorkerCompletedEventHandler runcomplete = (sender4, e4) =>
                {

                    if (e4.Error != null)
                    {
                        Log(e4.Error.ToString(), MessageType.Error);

                        DevComponents.DotNetBar.MessageBoxEx.Show(this, e4.Error.ToString(), "Exception");
                    }
                    else
                    {
                        if (_errorMessage.Length > 0)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(this, _errorMessage, "Exception");
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(this, _success.ToString() + " records processed successfully", "Message");
                        }
                    }

                    pb1.Visible = false;

                    btnDownload.Enabled = true;
                    btnExtract.Enabled = true;
                    btnDownloadExtract.Enabled = true;
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnNext.Enabled = _isNext;
                    btnPrevious.Enabled = _isPrevious;
                    btnSubmit.Enabled = true;
                    btnTClear.Enabled = true;
                    btnClear.Enabled = true;
                    btnTSubmit.Enabled = true;

                    ribbonBar1.Refresh();
                };

                worker1.RunWorkerCompleted += runcomplete;

                try
                {
                    worker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {

                    Log(string.Concat("PDF Downloading Exception " + ex.ToString()), MessageType.Error);
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, string.Concat("PDF Downloading Exception " + ex.ToString()), "Message");
                }


            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "Please select PDF Save Location in Settings first.", "Message");
            }
        }

        private void DownloadPDF(SearchResult t)
        {
            try
            {


                grdResults.Rows[t.RowIndex].DefaultCellStyle.BackColor = Color.Moccasin;
                if (t.PDFUrl != null)
                {
                    string dest = AppConfig.PDFSaveLocation + "\\" + t.CaseNumber + ".pdf";
                    CrawlerHelper ch = new CrawlerHelper();
                    ch.DownloadFile(t.PDFUrl, dest);
                }
                grdResults.Rows[t.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                _success++;

            }
            catch (Exception ex)
            {
                Log(string.Concat("PDF Saving exception " + ex.ToString()), MessageType.Error);
                _errorMessage += "\n" + ex.ToString();
                grdResults.Rows[t.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                grdResults.Rows[t.RowIndex].ErrorText = ex.ToString();
                _failed++;
            }


        }

        private void btnDownloadExtract_Click(object sender, EventArgs e)
        {
            grdResults.EndEdit();
            if ((AppConfig.PDFSaveLocation != null) && (AppConfig.PDFSaveLocation != ""))
            {
                if (!Directory.Exists(AppConfig.PDFSaveLocation))
                    Directory.CreateDirectory(AppConfig.PDFSaveLocation);

                _errorMessage = "";
                List<SearchResult> treatments = new List<SearchResult>();
                foreach (DataGridViewRow r in grdResults.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)r.Cells[0];
                    if ((bool)chk.Value == true)
                    {
                        SearchResult t = (SearchResult)r.DataBoundItem;
                        if (t.ParentCaseNumber == null)
                        {
                            t.RowIndex = r.Index;
                            treatments.Add(t);
                            bool hasChild = true;
                            int index = t.RowIndex + 1;

                            while (hasChild)
                            {
                                if (index < grdResults.RowCount)
                                {
                                    SearchResult childTreat = (SearchResult)grdResults.Rows[index].DataBoundItem;
                                    if (childTreat.ParentCaseNumber == t.CaseNumber)
                                    {
                                        childTreat.RowIndex = index;
                                        treatments.Add(childTreat);
                                        index++;
                                    }
                                    else
                                        hasChild = false;
                                }
                                else
                                    hasChild = false;
                            }
                        }
                    }
                }
                _toDownload = treatments.Count;
                pb1.Visible = true;
                pb1.Text = "Downloading and Extracting files....";

                _isNext = btnNext.Enabled;
                _isPrevious = btnPrevious.Enabled;

                btnDownload.Enabled = false;
                btnExtract.Enabled = false;
                btnDownloadExtract.Enabled = false;
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnSubmit.Enabled = false;
                btnTClear.Enabled = false;
                btnClear.Enabled = false;
                btnTSubmit.Enabled = false;
                ribbonBar1.Refresh();
                _downloaded = 0;
                _success = 0;
                _failed = 0;
                worker1 = new BackgroundWorker { WorkerReportsProgress = true };

                DoWorkEventHandler doWork = (sender1, e1) =>
                {

                    try
                    {
                        Parallel.ForEach(treatments, new ParallelOptions { MaxDegreeOfParallelism = 10 }, DownloadandExtractPDF);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };
                worker1.DoWork += doWork;
                RunWorkerCompletedEventHandler runcomplete = (sender4, e4) =>
                {

                    if (e4.Error != null)
                    {
                        Log(e4.Error.ToString(), MessageType.Error);

                        DevComponents.DotNetBar.MessageBoxEx.Show(this, e4.Error.ToString(), "Exception");
                    }
                    else
                    {
                        if (_errorMessage.Length > 0)
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(this, _errorMessage, "Exception");
                        }
                        else
                        {
                            DevComponents.DotNetBar.MessageBoxEx.Show(this, _success.ToString() + " files downloaded and extracted successfully", "Message");
                        }
                    }

                    pb1.Visible = false;

                    btnDownload.Enabled = true;
                    btnExtract.Enabled = true;
                    btnDownloadExtract.Enabled = true;
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnNext.Enabled = _isNext;
                    btnPrevious.Enabled = _isPrevious;
                    btnSubmit.Enabled = true;
                    btnTClear.Enabled = true;
                    btnClear.Enabled = true;
                    btnTSubmit.Enabled = true;

                    ribbonBar1.Refresh();
                };

                worker1.RunWorkerCompleted += runcomplete;

                try
                {
                    worker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {

                    Log(string.Concat("PDF Downloading Exception " + ex.ToString()), MessageType.Error);
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, string.Concat("PDF Extraction Exception " + ex.ToString()), "Message");
                }


            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "Please select PDF Save Location in Settings first.", "Message");
            }
        }

        private void DownloadandExtractPDF(SearchResult t)
        {
            try
            {
                grdResults.Rows[t.RowIndex].DefaultCellStyle.BackColor = Color.Moccasin;
                if (t.PDFUrl != null)
                {
                    string dest = AppConfig.PDFSaveLocation + "\\" + t.CaseNumber + ".pdf";
                    string PDFText = "";
                    if (!File.Exists(dest))
                    {
                        CrawlerHelper ch = new CrawlerHelper();
                        ch.DownloadFile(t.PDFUrl, dest);
                    }

                    DBHelper db = new DBHelper();
                    PDDocument doc = null;

                    try
                    {
                        doc = PDDocument.load(dest);
                        doc.openProtection(new StandardDecryptionMaterial(""));
                        PDFTextStripper stripper = new PDFTextStripper();
                        PDFText = stripper.getText(doc);

                    }
                    finally
                    {
                        if (doc != null)
                        {
                            doc.close();
                        }
                    }

                    PDFParser parser = new PDFParser(PDFText);

                    int treatmentID = db.AddUpdateSearchResult(t, PDFText, parser.Format);

                    if (treatmentID > 0)
                    {
                        parser.TreatmentID = treatmentID;
                        parser.ParseText();

                    }

                }

                else
                {
                    DBHelper db = new DBHelper();
                    db.AddUpdateSearchResult(t, "", Helper.PDFFormatEnum.Other);
                }
                grdResults.Rows[t.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                _success++;

            }
            catch (Exception ex)
            {
                Log(string.Concat("PDF Extracting exception " + ex.ToString()), MessageType.Error);

                _errorMessage += "\n" + ex.ToString();
                _failed++;
            }


        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int val;
            if (int.TryParse(txtPageNumber.Text, out val))
            {
                if (val > _totalpages)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, "Page does not exist");

                }
                else
                {
                    _currentPage = val;
                    lblTotal.Text = "";
                    ribbonBar1.Refresh();
                    grdResults.DataSource = null;

                    grdResults.Columns.Clear();
                    if (_type == SearchType.Case)
                    {
                        LoadCaseData();
                    }
                    else
                    {
                        LoadTreatmentData();
                    }

                }
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "Please enter numeric value for page number");
            }

        }

        private void grdResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_type == SearchType.Case)
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex == 14))
                {
                    string caseNumber = ((SearchResult)grdResults.Rows[e.RowIndex].DataBoundItem).CaseNumber;
                    pb1.Visible = true;
                    ribbonBar1.Refresh();
                    var frm = new frmCaseDetails(caseNumber);

                    frm.LoadData();
                    pb1.Visible = false;
                    ribbonBar1.Refresh();
                    frm.ShowDialog();
                }
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}

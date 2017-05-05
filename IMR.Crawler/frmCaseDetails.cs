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
using IMR.Crawler.Model;
using IMR.Crawler.Helper;
using HtmlAgilityPack;


namespace IMR.Crawler
{
    public partial class frmCaseDetails : Office2007Form
    {
        private string _caseNumber;
        private string _url = "https://www.dir.ca.gov/dwc/imr/IMRDecisionSearch.asp";
        private string _hostName = "www.dir.ca.gov";
        private string _origin = "https://www.dir.ca.gov";

        public frmCaseDetails(string caseNumber)
        {
            _caseNumber = caseNumber;
            InitializeComponent();
            this.Text = "Details of: " + _caseNumber;
        }

        public void LoadData()
        {


            List<SearchResult> treatments = new List<SearchResult>();
            try
            {
                CrawlerHelper ch = new CrawlerHelper();
                string html = "";

                html = ch.GetWebData(_url + "?caseno=" + _caseNumber, _hostName, _origin);



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
                        grdResults.DataSource = treatments;
                        grdResults.Columns[0].Visible = false;
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
                }
            }

            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Could not load Details");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IMRWeb.Controllers
{
    public class SearchController : BaseController
    {

        public ActionResult Index()
        {

            return View();
        }


        public ActionResult SmartSearch()
        {
            return View();
        }

      
        [HttpPost]
        public JsonResult SimpleSearchQuery(bool any, string searchText, int current, int pagesize)
        {
            SearchService.SearchServiceSoapClient searchService = new SearchService.SearchServiceSoapClient();
            
            return Json(searchService.GetSimpleSearchResults(any, searchText, current, pagesize));
            
        }

      
        public ActionResult SmartSearchQuery(string criteria, int current, int pagesize)
        {

            SearchService.SearchServiceSoapClient searchService = new SearchService.SearchServiceSoapClient();

            return Json(searchService.GetSmartSearchResults(criteria, current, pagesize));
        }

      
        [HttpPost]
        public string SimpleSearchCount(bool any, string searchText)
        {
            SearchService.SearchServiceSoapClient searchService = new SearchService.SearchServiceSoapClient();
            int count = searchService.GetSimpleSearchResultCount(any, searchText);
            return "{\"count\":" + count.ToString() + "}";

        }

      
        public string SmartSearchCount(string criteria)
        {
            SearchService.SearchServiceSoapClient searchService = new SearchService.SearchServiceSoapClient();
            int count = searchService.GetSmartSearchResultCount(criteria);
            return "{\"count\":" + count.ToString() + "}";

        }


        public string GetPDFDetails(string caseNumber, int treatmentID, int formatID)
        {
            IMRWeb.Models.PDFDetailResult res = new Models.PDFDetailResult();
            PDFDetailService.PDFDetailServiceSoapClient pdfService = new PDFDetailService.PDFDetailServiceSoapClient();
            res.pdfDetail =   pdfService.GetPDFDetails(treatmentID);
            res.formatID = formatID;
            res.caseNumber = caseNumber;
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);

        }
    }
}
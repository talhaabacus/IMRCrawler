using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMR.Crawler.Model
{
   public class SearchResult
    {

        public bool IsSelected
        { get; set; }


        public string PDFUrl
        {
            get; set;
        }
        public string CaseNumber
        {
            get; set;
        }
        public string CaseOutcome
        {
            get; set;
        }

        public string DecisionDate
        {
            get;set;
        }

        public string DateOfInjury
        { get; set; }

        public string RecievedDate
        {
            get;set;
        }


        public string IMROSpeciality

        { get; set; }


        public string RequestCategory

        { get; set; }


        public string SubCategory

        { get; set; }

        public string RequestDecision

        { get; set; }


        public string ParentCaseNumber
        { get; set; }




        public int RowIndex
        {
            get;set;
        }

        public bool hasMoreData
        {
            get; set;
        }
    }
}

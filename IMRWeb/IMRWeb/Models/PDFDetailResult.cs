using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMRWeb.Models
{
    public class PDFDetailResult
    {
        public int formatID
        { get; set; }



        public string caseNumber
        { get; set; }

        public PDFDetailService.PDFDetail pdfDetail
        { get; set; }

    }
}
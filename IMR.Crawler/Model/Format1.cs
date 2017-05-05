using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMR.Crawler.Model
{
    public class Format1
    {
        public DateTime DateAssigned
        { get; set; }

        public DateTime URDenialDate
        { get; set; }

        public string HowIMRDetermination
        { get; set; }

        public string ClinicalCaseSummary
        { get; set; }

        public int Age
        { get; set; }

        public string Gender
        { get; set; }

        public string Diagnosis
        { get; set; }

        public string IMRIssuesRationales
        { get; set; }

        public string StateOfLincesure
        { get; set; }

        public string Certifications
        { get; set; }

    }
}

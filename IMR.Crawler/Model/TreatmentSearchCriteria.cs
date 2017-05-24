using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMR.Crawler.Model
{
    public class TreatmentSearchCriteria
    {
        public string Caseno
        { get; set; }

        public string DoIStart
        { get; set; }

        public string DoIEnd
        { get; set; }

        public string ReqStart
        { get; set; }

        public string ReqEnd
        { get; set; }

        public string DecStart
        { get; set; }

        public string DecEnd
        { get; set; }

        public string SpecialtyV
        { get; set; }

        public string OutcomeV
        { get; set; }

        public string SubCategoryV
        { get; set; }

    }
}

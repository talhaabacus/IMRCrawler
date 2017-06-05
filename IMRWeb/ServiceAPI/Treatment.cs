//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Treatment
    {
        public int TreatmentID { get; set; }
        public string PDFUrl { get; set; }
        public string CaseNumber { get; set; }
        public string CaseOutCome { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public Nullable<System.DateTime> DateOfInjury { get; set; }
        public Nullable<System.DateTime> RecievedDate { get; set; }
        public string IMROSpeciality { get; set; }
        public string RequestCategory { get; set; }
        public string SubCategory { get; set; }
        public string RequestDecision { get; set; }
        public string ParentCaseNumber { get; set; }
        public string PDFText { get; set; }
        public string LocalPDFLoc { get; set; }
        public Nullable<int> PDFFormatID { get; set; }
    
        public virtual PDFDetail PDFDetail { get; set; }
        public virtual PDFFormat PDFFormat { get; set; }
    }
}

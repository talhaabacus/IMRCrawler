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
    
    public partial class PDFDetail
    {
        public int TreatmentID { get; set; }
        public Nullable<System.DateTime> DateAssigned { get; set; }
        public Nullable<System.DateTime> URDenialDate { get; set; }
        public string HowIMRDetermination { get; set; }
        public string ClinicalCaseSummary { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        public string IMRIssuesRationales { get; set; }
        public string StateofLicensure { get; set; }
        public string Certifications { get; set; }
        public string DocumentsReviewed { get; set; }
        public string IssueAtDispute { get; set; }
        public string TreatmentGuidelines { get; set; }
        public string ReviewerQualifications { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMR.Crawler.Model;

namespace IMR.Crawler.Helper
{
    public class DBHelper
    {
        public int AddUpdateSearchResult(Model.SearchResult res, string PDFText, PDFFormatEnum format)
        {

            IMRDataContext context = new IMRDataContext();

            Treatment treat = null;
            bool insert = false;
            if ((res.ParentCaseNumber != null) && (res.ParentCaseNumber.Length > 0))
            {
                if (context.Treatments.Where(t => t.RequestCategory == res.RequestCategory && t.SubCategory == res.SubCategory && t.RequestDecision == res.RequestDecision && t.ParentCaseNumber == res.ParentCaseNumber).Any())
                {

                    treat = context.Treatments.Single(t => t.RequestCategory == res.RequestCategory && t.SubCategory == res.SubCategory && t.RequestDecision == res.RequestDecision && t.ParentCaseNumber == res.ParentCaseNumber);
                }
            }
            else
            {
                if (context.Treatments.Where(t => t.CaseNumber == res.CaseNumber && t.ParentCaseNumber == null).Any())
                {

                    treat = context.Treatments.Single(t => t.CaseNumber == res.CaseNumber && t.ParentCaseNumber == null);
                    if ((res.RequestCategory != null) || (res.RequestDecision != null) || (res.SubCategory != null))
                    {
                        if ((treat.RequestCategory != null) || (treat.RequestDecision != null) || (treat.SubCategory != null))
                        {
                            if ((treat.SubCategory != res.SubCategory) || (treat.RequestDecision != res.RequestDecision) || (treat.RequestCategory != res.RequestCategory))
                            {
                                treat = null;
                                res.ParentCaseNumber = res.CaseNumber;
                            }
                        }
                    }
                }
            }
            if (treat == null)
            {

                treat = new Treatment();
                insert = true;
            }

            treat.CaseNumber = res.CaseNumber;
            treat.CaseOutCome = res.CaseOutcome;
            treat.DateOfInjury = DateTime.Parse(res.DateOfInjury);
            treat.DecisionDate = DateTime.Parse(res.DecisionDate);
            treat.IMROSpeciality = res.IMROSpeciality;
            treat.ParentCaseNumber = res.ParentCaseNumber;
            treat.PDFText = PDFText;
            treat.PDFUrl = res.PDFUrl;
            treat.RecievedDate = DateTime.Parse(res.RecievedDate);
            treat.RequestCategory = res.RequestCategory;
            treat.RequestDecision = res.RequestDecision;
            treat.SubCategory = res.SubCategory;
            treat.PDFFormatID = Convert.ToInt32(format);
            treat.LocalPDFLoc = IMR.Crawler.Configuration.AppConfig.PDFSaveLocation + "\\" + res.CaseNumber + ".pdf";
            if (insert)
                context.Treatments.InsertOnSubmit(treat);
            context.SubmitChanges();

            context.Connection.Close();
            context.Dispose();
            context = null;
            return treat.TreatmentID;

        }

        public IList<SearchCaseResult> SearchCase(string seacrhText, string caseNumber)
        {

            IMRDataContext context = new IMRDataContext();
            if (seacrhText.Length == 0)
                seacrhText = null;

            if (caseNumber.Length == 0)
                caseNumber = null;

            return context.SearchCase(seacrhText, caseNumber).ToList();

        }

        public IList<SearchCaseDetailResult> SearchCaseDetail(int age, string gender, string state, string certifications, string diagnosis)
        {

            IMRDataContext context = new IMRDataContext();
            
            if (gender.Length == 0)
                gender = null;

            if (state.Length == 0)
                state = null;

            if (certifications.Length == 0)
                certifications = null;

            if (diagnosis.Length == 0)
                diagnosis = null;
            if (age == 0)
                return context.SearchCaseDetail(null, gender, state, certifications, diagnosis).ToList();
            else
                return context.SearchCaseDetail(age, gender, state, certifications, diagnosis).ToList();
        }

        public Format1Detail GetFormat1Detail(int tID)
        {
            IMRDataContext context = new IMRDataContext();
            if (context.Format1Details.Where(det => det.TreatmentID == tID).Any())
            {
                return context.Format1Details.Single(det => det.TreatmentID == tID);
            }
            else
            {
                return null;
            }


        }

        public Format2Detail GetFormat2Detail(int tID)
        {
            using (IMRDataContext context = new IMRDataContext())
            {
                if (context.Format2Details.Where(det => det.TreatmentID == tID).Any())
                {
                    return context.Format2Details.Single(det => det.TreatmentID == tID);
                }
                else
                {
                    return null;
                }
            }

        }

        public Format3Detail GetFormat3Detail(int tID)
        {
            using (IMRDataContext context = new IMRDataContext())
            {
                if (context.Format3Details.Where(det => det.TreatmentID == tID).Any())
                {
                    return context.Format3Details.Single(det => det.TreatmentID == tID);
                }
                else
                {
                    return null;
                }

            }
        }
        public int AddUpdateFormat1Detail(int tID, Format1 det )
        {
            IMRDataContext context = new IMRDataContext();
            Format1Detail pdfDetails = null;
            bool addNew = false;
            if (context.Format1Details.Where(fdet => fdet.TreatmentID == tID).Any())
            {
                pdfDetails =  context.Format1Details.Single(fdet => fdet.TreatmentID == tID);
            }

            if(pdfDetails == null)
            {
                addNew = true;
                pdfDetails = new Format1Detail();
            }

            pdfDetails.Age = det.Age;
            pdfDetails.Certifications = det.Certifications;
            pdfDetails.ClinicalCaseSummary = det.ClinicalCaseSummary;
            pdfDetails.DateAssigned = det.DateAssigned;
            pdfDetails.Diagnosis = det.Diagnosis;
            pdfDetails.Gender = det.Gender;
            pdfDetails.HowIMRDetermination = det.HowIMRDetermination;
            pdfDetails.IMRIssuesRationales = det.IMRIssuesRationales;
            pdfDetails.StateofLicensure = det.StateOfLincesure;
            pdfDetails.URDenialDate = det.URDenialDate;
            pdfDetails.TreatmentID = tID;
            if (addNew)
                context.Format1Details.InsertOnSubmit(pdfDetails);
            context.SubmitChanges();
            context.Connection.Close();
            context.Dispose();
            context = null;
            return 0;
        }

        public int AddUpdateFormat2Detail(int tID, Format2 det)
        {
            IMRDataContext context = new IMRDataContext();
            Format2Detail pdfDetails = null;
            bool addNew = false;
            if (context.Format2Details.Where(fdet => fdet.TreatmentID == tID).Any())
            {
                pdfDetails = context.Format2Details.Single(fdet => fdet.TreatmentID == tID);
            }

            if (pdfDetails == null)
            {
                addNew = true;
                pdfDetails = new Format2Detail();
            }

          
          
            pdfDetails.ClinicalCaseSummary = det.ClinicalCaseSummary;
            pdfDetails.DocumentsReviewed = det.DocumentsReviewed;
           pdfDetails.HowIMRDetermination = det.HowIMRDetermination;
            pdfDetails.IMRIssuesRationales = det.IMRIssuesRationales;
            pdfDetails.URDenialDate = det.URDenialDate;
            pdfDetails.TreatmentID = tID;
            if (addNew)
                context.Format2Details.InsertOnSubmit(pdfDetails);
            context.SubmitChanges();
            context.Connection.Close();
            context.Dispose();
            context = null;
            return 0;
        }

        public int AddUpdateFormat3Detail(int tID, Format3 det)
        {
            IMRDataContext context = new IMRDataContext();
            Format3Detail pdfDetails = null;
            bool addNew = false;
            if (context.Format3Details.Where(fdet => fdet.TreatmentID == tID).Any())
            {
                pdfDetails = context.Format3Details.Single(fdet => fdet.TreatmentID == tID);
            }

            if (pdfDetails == null)
            {
                addNew = true;
                pdfDetails = new Format3Detail();
            }

            pdfDetails.CaseSummary = det.CaseSummary;
            pdfDetails.Age = det.Age;
            pdfDetails.DocumentsReviewed = det.DocumentsReviewed;
            pdfDetails.Diagnosis = det.Diagnosis;
            pdfDetails.Gender = det.Gender;
            pdfDetails.IssueAtDispute = det.IssueAtDispute;
            pdfDetails.Rationales = det.Rationales;
            pdfDetails.ReviewerQualifications = det.ReviewerQualifications;
            pdfDetails.TreatmentGuidelines = det.TreatmentGuidelines;
            pdfDetails.TreatmentID = tID;
            if (addNew)
                context.Format3Details.InsertOnSubmit(pdfDetails);
            context.SubmitChanges();
            context.Connection.Close();
            context.Dispose();
            context = null;
            return 0;
        }

        public  Treatment GetTreatment(int tID)
        {
            using (IMRDataContext context = new IMRDataContext())
            {
                if (context.Treatments.Where(det => det.TreatmentID == tID).Any())
                {
                    return context.Treatments.Single(det => det.TreatmentID == tID);
                }
                else
                {
                    return null;
                }
            }
           
        }
    }
}

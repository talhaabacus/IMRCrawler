using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMR.Crawler.Model;

namespace IMR.Crawler.Helper
{
    public enum PDFFormatEnum
    {
        Format1 = 1,
        Format2 = 2,
        Format3 = 3,
        Other = 4
    }
    public class PDFParser
    {
        private string _text;
        private PDFFormatEnum _format;
        private int _treatmentID;
        public PDFParser(string text)
        {
            _text = text;
            _text.TrimStart('\n');
            _text.TrimStart('\r');
            if (_text.StartsWith(" Case Number:"))
                _format = PDFFormatEnum.Format1;

            else if (_text.StartsWith("MAXIMUS FEDERAL SERVICES, INC. \r\nIndependent Medical Review "))
                _format = PDFFormatEnum.Format2;
            else if (_text.StartsWith("\r\nMEDICAL PROFESSIONAL REVIEW"))
                _format = PDFFormatEnum.Format3;
            else
                _format = PDFFormatEnum.Other;
        }
        public PDFFormatEnum Format
        {
            get { return _format; }
        }

        public int TreatmentID
        {
            get { return _treatmentID; }
            set { _treatmentID = value; }
        }

        public void ParseText()
        {
            if (_format == PDFFormatEnum.Format1)
                ParseFormat1Text();
            else if (_format == PDFFormatEnum.Format2)
                ParseFormat2Text();
            else if (_format == PDFFormatEnum.Format3)
                ParseFormat3Text();

        }


        private void ParseFormat1Text()
        {
            try
            {
                Format1 f = new Format1();

                string dateAssigned = _text.Substring(_text.IndexOf("Date Assigned: ") + 15, 10);
                f.DateAssigned = DateTime.Parse(dateAssigned);

                string urDenial = "";
                urDenial = _text.Substring(_text.IndexOf("UR Denial Date:  ") + 17, 10);
                f.URDenialDate = DateTime.Parse(urDenial);

                int imrindex = _text.IndexOf("HOW THE IMR FINAL DETERMINATION WAS MADE");
                int caseindex = _text.IndexOf("CLINICAL CASE SUMMARY");
                int issueindex = _text.IndexOf("IMR ISSUES, DECISIONS AND RATIONALES ");

                f.HowIMRDetermination = _text.Substring(imrindex + 40, caseindex - imrindex - 40);
                f.ClinicalCaseSummary = _text.Substring(caseindex + 21, issueindex - caseindex - 21);
                f.IMRIssuesRationales = _text.Substring(issueindex + 36);
                string diagnosisPart = "";
                if (_text.IndexOf(" year old") != -1)
                {
                    string text = _text.Substring(0, _text.IndexOf(" year old"));
                    string a = text.Substring(text.LastIndexOf(' ')).Trim();
                    try
                    {
                        f.Age = Int32.Parse(a);
                    }
                    catch (Exception)
                    {
                        f.Age = 0;
                    }

                    text = _text.Substring(_text.IndexOf(" year old") + 9).Trim();
                    diagnosisPart = text;
                    a = text.Substring(0, text.IndexOf(' ')).Trim();
                    f.Gender = a.Replace(',', ' ').Trim();

                    if((f.Gender.ToLower() != "male") && (f.Gender.ToLower() != "female"))
                    {
                        if (_text.IndexOf(" female ") > 0)
                            f.Gender = "female";
                        else if (_text.IndexOf(" male ") > 0)
                            f.Gender = "male";

                    }
                }
                else if (_text.IndexOf("-year-old") != -1)
                {
                    string text = _text.Substring(0, _text.IndexOf("-year-old"));
                    string a = text.Substring(text.LastIndexOf(' ')).Trim();
                    try
                    {
                        f.Age = Int32.Parse(a);
                    }
                    catch (Exception)
                    {
                        f.Age = 0;
                    }
                    text = _text.Substring(_text.IndexOf("-year-old") + 9).Trim();
                    diagnosisPart = text;
                    a = text.Substring(0, text.IndexOf(' ')).Trim();

                    f.Gender = a.Replace(',', ' ').Trim();
                    if ((f.Gender.ToLower() != "male") && (f.Gender.ToLower() != "female"))
                    {
                        if (_text.IndexOf(" female ") > 0)
                            f.Gender = "female";
                        else if (_text.IndexOf(" male ") > 0)
                            f.Gender = "male";

                    }
                }
                if (diagnosisPart.Length == 0)
                    diagnosisPart = f.ClinicalCaseSummary;
                diagnosisPart = diagnosisPart.Substring(diagnosisPart.IndexOf(".") + 1).Trim();

                if (diagnosisPart.ToLower().IndexOf("diagnosis") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosis"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else if (diagnosisPart.ToLower().IndexOf("diagnosed") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosed"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else if (diagnosisPart.ToLower().IndexOf("diagnoses") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnoses"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
               else if (diagnosisPart.ToLower().IndexOf("diagnosistic") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosistic"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else
                {
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));
                }
                int licenseIndex = _text.IndexOf("State(s) of Licensure:");
                if (licenseIndex != -1)
                {
                    licenseIndex = licenseIndex + 22;
                    string licensureText = _text.Substring(licenseIndex, _text.IndexOf("\r\n", licenseIndex) - licenseIndex);
                    f.StateOfLincesure = licensureText.Trim();

                }

                int certificationIndex = _text.IndexOf("Certification(s)/Specialty:");
                if (certificationIndex != -1)
                {
                    certificationIndex = certificationIndex + 27;
                    string certs = _text.Substring(certificationIndex, _text.IndexOf("\r\n", certificationIndex) - certificationIndex);
                    f.Certifications = certs.Trim();

                }

                DBHelper helper = new DBHelper();
                helper.AddUpdateFormat1Detail(_treatmentID, f);
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse PDF ", e);

            }

        }
        private void ParseFormat2Text()
        {
            try
            {
                Format2 f = new Format2();

                string urDenial = "";
                urDenial = _text.Substring(_text.IndexOf("UR Denial Date:  ") + 17, 10);
                f.URDenialDate = DateTime.Parse(urDenial);

                int imrindex = _text.IndexOf("HOW THE IMR FINAL DETERMINATION WAS MADE");
                int documentsindex = _text.IndexOf("DOCUMENTS REVIEWED");
                int caseindex = _text.IndexOf("CLINICAL CASE SUMMARY");
                int issueindex = _text.IndexOf("IMR DECISION(S) AND RATIONALE(S)");

                f.HowIMRDetermination = _text.Substring(imrindex + 40, documentsindex - imrindex - 40).Trim();
                f.DocumentsReviewed = _text.Substring(documentsindex + 18, caseindex - documentsindex - 18).Trim();
                f.ClinicalCaseSummary = _text.Substring(caseindex + 21, issueindex - caseindex - 21).Trim();
                f.IMRIssuesRationales = _text.Substring(issueindex + 32).Trim();

                DBHelper helper = new DBHelper();
                helper.AddUpdateFormat2Detail(_treatmentID, f);
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse PDF ", e);

            }





        }

        private void ParseFormat3Text()
        {
            try
            {
                Format3 f = new Format3();


                int issueindex = _text.IndexOf("ISSUE AT DISPUTE:");
                int caseindex = _text.IndexOf("CASE SUMMARY:");
                int reviewedindex = _text.IndexOf("DOCUMENTS REVIEWED FOR DETERMINATION:");
                int guidelineindex = _text.IndexOf("MEDICAL TREATMENT GUIDELINE(S) RELIED UPON BY PROFESSIONAL \r\nREVIEWER AND WHY:");
                int rationaleindex = _text.IndexOf("RATIONALE FOR WHY THE REQUESTED TREATMENT/SERVICE IS/WAS NOT \r\nMEDICALLY NECESSARY:");
                int qualificationindex = _text.IndexOf("MEDICAL REVIEWER QUALIFICATIONS:");

                f.IssueAtDispute = _text.Substring(issueindex + 17, caseindex - issueindex - 17).Trim();
                f.CaseSummary = _text.Substring(caseindex + 13, reviewedindex - caseindex - 13).Trim();
                f.DocumentsReviewed = _text.Substring(reviewedindex + 37, guidelineindex - reviewedindex - 37).Trim();
                f.TreatmentGuidelines = _text.Substring(guidelineindex + 80, rationaleindex - guidelineindex - 80).Trim();
                f.Rationales = _text.Substring(rationaleindex + 85, qualificationindex - rationaleindex - 85).Trim();
                f.ReviewerQualifications = _text.Substring(qualificationindex + 32).Trim();

                string diagnosisPart = "";
                if (_text.IndexOf(" year old") != -1)
                {
                    string text = _text.Substring(0, _text.IndexOf(" year old"));
                    string a = text.Substring(text.LastIndexOf(' ')).Trim();
                    try
                    {
                        f.Age = Int32.Parse(a);
                    }
                    catch (Exception)
                    {
                        f.Age = 0;
                    }

                    text = _text.Substring(_text.IndexOf(" year old ") + 9).Trim();
                    diagnosisPart = text;
                    a = text.Substring(0, text.IndexOf(' ')).Trim();
                    f.Gender = a.Replace(',', ' ').Trim();
                    if ((f.Gender.ToLower() != "male") && (f.Gender.ToLower() != "female"))
                    {
                        if (_text.IndexOf(" female ") > 0)
                            f.Gender = "female";
                        else if (_text.IndexOf(" male ") > 0)
                            f.Gender = "male";

                    }
                }
                else if (_text.IndexOf("-year-old") != -1)
                {
                    string text = _text.Substring(0, _text.IndexOf("-year-old"));
                    string a = text.Substring(text.LastIndexOf(' ')).Trim();
                    try
                    {
                        f.Age = Int32.Parse(a);
                    }
                    catch (Exception)
                    {
                        f.Age = 0;
                    }
                    text = _text.Substring(_text.IndexOf("-year-old") + 9).Trim();
                    diagnosisPart = text;
                    a = text.Substring(0, text.IndexOf(' ')).Trim();

                    f.Gender = a.Replace(',', ' ').Trim();
                    if ((f.Gender.ToLower() != "male") && (f.Gender.ToLower() != "female"))
                    {
                        if (_text.IndexOf(" female ") > 0)
                            f.Gender = "female";
                        else if (_text.IndexOf(" male ") > 0)
                            f.Gender = "male";

                    }
                }

                diagnosisPart = diagnosisPart.Substring(diagnosisPart.IndexOf(".") + 1).Trim();

                if (diagnosisPart.ToLower().IndexOf("diagnosis") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosis"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf(".")).Trim();

                }
                else if (diagnosisPart.ToLower().IndexOf("diagnosed") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosed"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else if (diagnosisPart.ToLower().IndexOf("diagnoses") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnoses"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else if (diagnosisPart.ToLower().IndexOf("diagnosistic") != -1)
                {
                    diagnosisPart = diagnosisPart.Substring(diagnosisPart.ToLower().IndexOf("diagnosistic"));
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf("."));

                }
                else
                {
                    f.Diagnosis = diagnosisPart.Substring(0, diagnosisPart.IndexOf(".")).Trim();
                }

                DBHelper helper = new DBHelper();
                helper.AddUpdateFormat3Detail(_treatmentID, f);

            }
            catch (Exception e)
            {
                throw new Exception("Could not parse PDF ", e);

            }

        }
    }
}

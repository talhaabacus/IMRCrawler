using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceAPI
{
    /// <summary>
    /// Summary description for PDFDetail1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PDFDetailService : System.Web.Services.WebService
    {
        public PDFDetailService()
        {

        }


        [WebMethod]
        public PDFDetail  GetPDFDetails(int treatmentID)
        {
            using (IMRCrawlerEntities db = new IMRCrawlerEntities())
            {
                PDFDetail det = db.PDFDetails.Where((x) => x.TreatmentID == treatmentID).FirstOrDefault();

                return det;
            }
        }
    }
}


using System;
using System.Web;
using System.Web.Script.Services;
using System.Xml.Serialization;
using System.Web.Services;
using System.Configuration;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Mvc;
namespace ServiceAPI
{
/// <summary>
/// Summary description for SEC_UserService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
// [System.Web.Script.Services.ScriptService]
public class SearchService: System.Web.Services.WebService
{
public SearchService()
{

}
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IMRConnectionString"].ConnectionString;
        }

        [WebMethod]
        public int GetSimpleSearchResultCount(Boolean any, string searchString)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                connection.Open();
                string sqlStatement = "simpleSearchCount";
                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@SearchString", searchString));
                if (any)
                    sqlCmd.Parameters.Add(new SqlParameter("@Any", 1));
                else
                    sqlCmd.Parameters.Add(new SqlParameter("@Any", 0));
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt16(dt.Rows[0][0].ToString());
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
        [WebMethod]
     
        public  string GetSimpleSearchResults(Boolean any, string searchString, int current, int pageSize)
        {
           
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                int startIndex = ((current -1) * pageSize);
                connection.Open();
                string sqlStatement = "simpleSearch";
                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@SearchString", searchString));
                if (any)
                    sqlCmd.Parameters.Add(new SqlParameter("@Any", 1));
                else
                    sqlCmd.Parameters.Add(new SqlParameter("@Any", 0));

                sqlCmd.Parameters.Add(new SqlParameter("@MaxRows", pageSize));
                sqlCmd.Parameters.Add(new SqlParameter("@StartIndex", startIndex));

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "[{}]";
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }

        }


        [WebMethod]
        public int GetSmartSearchResultCount( string searchCriteria)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                connection.Open();
                string sqlStatement = "SMARTSearchCount";
                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Criteria", searchCriteria));
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt16(dt.Rows[0][0].ToString());
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
        [WebMethod]

        public string GetSmartSearchResults(string searchCriteria, int current, int pageSize)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(GetConnectionString());

            try
            {
                int startIndex = ((current - 1) * pageSize);
                connection.Open();
                string sqlStatement = "SMARTSearch";
                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@Criteria", searchCriteria));
                sqlCmd.Parameters.Add(new SqlParameter("@MaxRows", pageSize));
                sqlCmd.Parameters.Add(new SqlParameter("@StartIndex", startIndex));

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "[{}]";
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Fetch Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                connection.Close();
            }

        }


    }
}
/*****************************************************************************************************************/


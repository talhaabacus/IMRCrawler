using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;




namespace IMR.Crawler.Helper
{
    public class CrawlerHelper
    {


        CookieContainer cookies = new CookieContainer();
        ProxyHelper proxyHelper = new ProxyHelper();

        public string GetWebData(string url, string hostName, string origin)
        {



            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.KeepAlive = false;

                    request.Proxy = proxyHelper.Proxy;
                   
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            req.Abort();
            response = null;
            req = null;
            return retStr;

        }
        public string GetWebDataXml(string url, string hostName, string origin)
        {

            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.Accept = "*/*";
                    request.KeepAlive = false;
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.CookieContainer = cookies;

                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                    request.Proxy = proxyHelper.Proxy;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.Accept = "*/*";
                    request.KeepAlive = false;
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.CookieContainer = cookies;

                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    req = request;

                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            req.Abort();
            response = null;
            req = null;
            return retStr;

        }
        public byte[] GetWebDataBytes(string url, string hostName, string origin)
        {

            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                    request.Proxy = proxyHelper.Proxy;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }


            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            MemoryStream memoryStream = new MemoryStream(0x10000);
            byte[] buffer = new byte[0x1000];
            int bytes;
            while ((bytes = receiveStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, bytes);
            }

            response.Close();
            response = null;
            req.Abort();
            req = null;
            return memoryStream.ToArray();

        }
        public string PostWebData(string url, string hostName, string origin, string referer, string data)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.KeepAlive = false;
                    request.Referer = referer;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = proxyHelper.Proxy;
                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; InfoPath.2; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public string PostWebData(string url, string hostName, string origin, string data)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;

                    req = request;
                    request.ContentLength = data.Length;
                    request.Proxy = proxyHelper.Proxy;

                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                   
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 2; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }


            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public string PostWebDataRetUrl(string url, string hostName, string origin, string data, out string retUrl)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;

                    req = request;
                    request.ContentLength = data.Length;
                    request.Proxy = proxyHelper.Proxy;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                   
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 2; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }


            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            retUrl = response.ResponseUri.ToString();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public string PostWebData(string url, string hostName, string origin, string data, out string cntx)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;

                    request.Proxy = proxyHelper.Proxy;
                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.KeepAlive = false;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            cntx = response.ResponseUri.Query.Replace("?l=EN&CNTX=", "");

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public string PostWebDataXml(string url, string hostName, string origin, string data)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = proxyHelper.Proxy;
                    req = request;
                    request.ContentLength = data.Length;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                  

                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public string PostWebDataXml(string url, string hostName, string origin, string data, string referrel)
        {
            HttpWebResponse response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Referer = referrel;
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = proxyHelper.Proxy;
                    req = request;
                    request.ContentLength = data.Length;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    

                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 900000;
                    request.ReadWriteTimeout = 900000;
                    request.Host = hostName;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.Accept = "application/json, text/javascript, */*; q=0.01";
                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.CookieContainer = cookies;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Referer = referrel;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            response.Close();
            response = null;
            req.Abort();
            req = null;
            return retStr;
        }
        public static string CleanHtml(string html)
        {
            html = html.Replace("&nbsp;", "");

            html = html.Replace("\n", "");
            html = Regex.Replace(html, "<!--(?!<!)[^\\[>].*?-->", "");
            html = Regex.Replace(html, "<.*?>", "");
            return html;
        }
        public string GetWebData(string url, string hostName, string origin, string referer, string cookieString, out HttpWebResponse response)
        {



            response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Credentials = CredentialCache.DefaultCredentials;


                    request.Proxy = proxyHelper.Proxy;

                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.Credentials = CredentialCache.DefaultCredentials;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            // response.Close();
            req.Abort();
            // response = null;
            req = null;
            return retStr;

        }
        public string GetWebDataWithNoRedirect(string url, string hostName, string origin, string referer, string cookieString, out HttpWebResponse response)
        {



            response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.AllowAutoRedirect = false;       

                    request.Proxy = proxyHelper.Proxy;

                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;
                    request.AllowAutoRedirect = false;       
                    request.Credentials = CredentialCache.DefaultCredentials;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
           // response.Close();
            req.Abort();
           // response = null;
            req = null;
            return retStr;

        }
        public string GetWebData(Uri url, string hostName, string origin, string referer, string cookieString, out HttpWebResponse response)
        {



            response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Credentials = CredentialCache.DefaultCredentials;


                    request.Proxy = proxyHelper.Proxy;

                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.Headers.Add("Origin", origin);
                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    request.Referer = referer;
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    request.Credentials = CredentialCache.DefaultCredentials;
                    req = request;
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
            // response.Close();
            req.Abort();
            // response = null;
            req = null;
            return retStr;

        }
        public string PostWebDataWithNoRedirect(string url, string hostName, string origin, string referer, string data, string cookieString, out HttpWebResponse response)
        {
            response = null;
            HttpWebRequest req = null;
            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                for (int i = 0; i < total; i++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
              
                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.ContentType = "application/x-www-form-urlencoded";

                    request.Method = "POST";
                    request.AllowAutoRedirect = false;
                    
                    request.Referer = referer;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    
                    request.Proxy = proxyHelper.Proxy;
                    request.ContentLength = data.Length;
                    req = request;
                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();




                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout))
                    {
                        proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Host = hostName;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
                    request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");

                    request.Headers.Set(HttpRequestHeader.Cookie, cookieString);
                    request.KeepAlive = true;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.AllowAutoRedirect = false;

                    request.Referer = referer;
                    request.Method = "POST";
                    request.AllowAutoRedirect = false;
                    request.KeepAlive = true;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = HttpWebRequest.DefaultWebProxy;

                    byte[] byteArray = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = byteArray.Length;
                    req = request;
                   
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();



                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (Exception ex)
                    {

                    }
                    if ((response == null) || (response.StatusCode == HttpStatusCode.InternalServerError) || (response.StatusCode == HttpStatusCode.GatewayTimeout) || (response.StatusCode == HttpStatusCode.BadGateway))
                    {

                        if (ii == 2)
                            throw new Exception("Error getting data from " + url);
                    }
                    else
                    {
                        break;
                    }

                }
            }

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


            string retStr = readStream.ReadToEnd();
            readStream.Close();
          //  response.Close();
            //response = null;
            req.Abort();
            req = null;
            return retStr;
        }

       
        public void DownloadFile(string url, string dest)
        {

            if (proxyHelper.TotalProxies > 0)
            {

                int total = 10;
                if (proxyHelper.TotalProxies < 10)
                    total = proxyHelper.TotalProxies;
                bool success = true;
                for (int i = 0; i < total; i++)
                {

                    WebClient wc = new WebClient();
                    wc.Proxy = proxyHelper.Proxy;
                    try
                    {
                        wc.DownloadFile(new Uri(url), dest);
                    }
                    catch (WebException ex)
                    {
                        if((ex.Status == WebExceptionStatus.ProxyNameResolutionFailure) || (ex.Status == WebExceptionStatus.Timeout) || (ex.Status == WebExceptionStatus.NameResolutionFailure) || (ex.Status == WebExceptionStatus.NameResolutionFailure))
                            proxyHelper.ChangeProxy();
                        if (i == total)
                            throw new Exception("Invalid proxy");
                        success = false;
                    }
                    if (success)
                        break;
                }
            }
            else
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(new Uri(url), dest);
            }
        }

        public void ClearCookies()
        {
            cookies = null;
        }

    }
}

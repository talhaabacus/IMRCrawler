using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMR.Crawler.Configuration;
using System.Collections;
using System.IO;
using System.Net;



namespace IMR.Crawler.Helper
{
    public class ProxyHelper
    {
        private Queue Proxies = new Queue();
        int proxiesCount = 0;
        WebProxy _proxy = null;
        public WebProxy Proxy
        {
            get
            {
                return _proxy;
            }
        }

        public ProxyHelper()
        {
            LoadProxies();
        }

        public int TotalProxies
        {
            get
            {
                return proxiesCount;
            }
        }
        private bool LoadProxies()
        {
            bool res = false;
            Random rnd = new Random();
            Proxies.Clear();
            proxiesCount = 0;

            if (!string.IsNullOrEmpty(AppConfig.ProxyFilePath) && (File.Exists(AppConfig.ProxyFilePath)))
            {

                try
                {
                    using (StreamReader sr = new StreamReader(AppConfig.ProxyFilePath))
                    {
                        string proxy = string.Empty;
                        while ((proxy = sr.ReadLine()) != null)
                        {
                            try
                            {
                                Proxies.Enqueue(proxy);
                            }
                            catch { }

                            for (int k = 0; k < rnd.Next(0, Proxies.Count); k++)
                            {
                                
                                string p = (string)Proxies.Dequeue();
                                Proxies.Enqueue(p);
                            }
                        }

                        res = Proxies.Count > 0;
                    }
                }
                catch (Exception ex) { proxiesCount = (Proxies.Count / 5) - 1;  throw new Exception("Error loading proxies", ex);}
            }
            if (res)
            {

                proxiesCount = Proxies.Count;
                ChangeProxy();

            }
            return res;
        }

        public void ChangeProxy()
        {
            if (this.Proxies != null && this.Proxies.Count > 0)
            {
                string p = (string)this.Proxies.Dequeue();
                this.Proxies.Enqueue(p);
               
                //this.Proxy = new WebProxy(p);
                SetActiveProxy(p);
            }
        }
        private void SetActiveProxy(string proxy)
        {
            if (proxy != null && proxy.Length > 0)
            {
                if (proxy.IndexOf('(') > 0) // 111.111.111.111:1111 (username:password)
                {
                    string[] proxyParts = proxy.Split(new char[] { '(' }, StringSplitOptions.None);
                    this._proxy = new WebProxy(proxyParts[0].Trim());
                    string s = proxyParts[1].Trim();
                    int i = s.IndexOf(':');
                    if (i > 0)
                    {
                        string userName = s.Substring(0, i);
                        string password = s.Substring(i + 1).Trim();
                        password = password.Substring(0, password.Length - 1); // remove ending ')'
                        this._proxy.Credentials = new NetworkCredential(userName, password);
                    }
                }
                else // proxy without password
                {
                    this._proxy = new WebProxy(proxy);
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Configuration;


namespace IMR.Crawler.Configuration
{
    public class ConfigSettings
    {
        public ConfigSettings() { }

        public static string ReadSetting(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            return value;
 
        }

        public static void WriteSetting(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = LoadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", value);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(GetConfigFilePath());
                ConfigurationManager.RefreshSection("configuration");
            }
            catch
            {
                throw;
            }
            File.Copy(Path.Combine(AppConfig.MainPath, "IMR.Crawler.exe.config"), Path.Combine(AppConfig.IMRAppSettingsPath, AppConfig.IMRAppAppFileName), true);
        }

        public static void RemoveSetting(string key)
        {
            // load config document for current assembly
            XmlDocument doc = LoadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    doc.Save(GetConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
            }
            File.Copy(Path.Combine(AppConfig.MainPath, "IMR.Crawler.exe.config"), Path.Combine(AppConfig.IMRAppSettingsPath, AppConfig.IMRAppSettingsPath), true);

        }

        private static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private static string GetConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }


        public static void MergeRequiredSettings(string sourceConfigPath, string destinationConfigPath)
        {
            XElement sourceElem = XElement.Load(sourceConfigPath);
            XElement destinationElem = XElement.Load(destinationConfigPath);
            bool dif = false;

            // Merge system.serviceModel
            XElement sourceService = null;
            XElement destService = null;

            var s = from el in sourceElem.Descendants("system.serviceModel")
                    select el;
            if (s.Count() > 0) sourceService = s.First();

            s = from el in destinationElem.Descendants("system.serviceModel")
                select el;
            if (s.Count() > 0) destService = s.First();

            if (sourceService != null)
            {
                if (!XElement.DeepEquals(sourceService, destService))
                {
                    if (destService == null)
                    {
                        destinationElem.Add(new XElement("system.serviceModel", sourceService.Elements()));
                    }
                    else
                    {
                        destService.RemoveNodes();
                        destService.Add(sourceService.Elements());
                    }
                    dif = true;
                }
            }

            // Save destination config
            if (dif)
                destinationElem.Save(destinationConfigPath);
        }

        public static string ReadSettingDirectly(string key)
        {
            string res = string.Empty;
            XmlDocument doc = LoadConfigDocument();
            XmlNode node = doc.SelectSingleNode("//appSettings");

            if (node != null)
            {
                try
                {
                    // select the 'add' element that contains the key
                    XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                    if (elem != null)
                        res = elem.GetAttribute("value");
                }
                catch { }
            }

            return res;
        }

        public static void Refresh()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
            config.Save();
            ConfigurationManager.RefreshSection("configuration");
        }
    }

}

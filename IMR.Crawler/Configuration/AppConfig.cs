using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

using System.Data;

namespace IMR.Crawler.Configuration
{
    public static class AppConfig
    {


        private const string PDFSaveLocationSettingName = "PDFSaveLocation";
        private const string LogFileLocationName = "LogFileLocation";
        private const string ProxyFilePathName = "ProxyFilePath";

        public static string MainPath = Application.StartupPath;

        public static string IMRAppSettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"IMR.Crawler\Settings");
        public static string IMRAppAppFileName = "IMR.Crawler.config";


        private static string _pDFSaveLocation;
        private static string _logFileLocation;
        private static string _proxyFilePath;


        public static string PDFSaveLocation
        {
            get { return _pDFSaveLocation; }
            set {
                _pDFSaveLocation = value;
                ConfigSettings.WriteSetting(PDFSaveLocationSettingName, value); }
        }


        public static string LogFileLocation
        {
            get { return _logFileLocation; }
            set {
                _logFileLocation = value;
                ConfigSettings.WriteSetting(LogFileLocationName, value); }
        }

        public static string ProxyFilePath
        {
            get { return _proxyFilePath; }
            set {
                _proxyFilePath = value;
                ConfigSettings.WriteSetting(ProxyFilePathName, value); }
        }


        public static void LoadSettings()
        {
            _pDFSaveLocation = ConfigSettings.ReadSetting(PDFSaveLocationSettingName);
            _logFileLocation = ConfigSettings.ReadSetting(LogFileLocationName);
            _proxyFilePath = ConfigSettings.ReadSetting(ProxyFilePathName);

        }

        public static bool NeedsConfigSetup
        {
            get
            {
                LoadSettings();

                bool needsConfig = false;

                if (string.IsNullOrEmpty(PDFSaveLocation)) needsConfig = true;
                return needsConfig;
            }
        }

        public static bool NeedsConfig_ReadDirectly
        {
            get
            {
                return string.IsNullOrEmpty(ConfigSettings.ReadSettingDirectly(AppConfig.PDFSaveLocationSettingName));
            }
        }

        /// <summary>
        /// Create and clean all nessary directories.
        /// </summary>
        public static void DirectoryCheck()
        {
            if (!Directory.Exists(IMRAppSettingsPath))
                Directory.CreateDirectory(IMRAppSettingsPath);

        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMR.Crawler.Configuration;
using System.IO;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace IMR.Crawler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SetupConfig();

            if (AppConfig.NeedsConfigSetup)
            {
                int i = 1;
            }
            #region Setup Logger

            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            #region File Log

            FileTarget fileTarget;

            if (!string.IsNullOrEmpty(AppConfig.LogFileLocation))
            {
                fileTarget = new FileTarget
                {
                    ArchiveAboveSize = 1048576,
                    AutoFlush = true,
                    MaxArchiveFiles = 10,
                    CreateDirs = true,
                    EnableFileDelete = true,
                    Header =
                        "\n${date:format=HH\\:mm\\:ss}\nLog file for IMR Crawler Application\n===============================\n",
                    Footer = "===============================\nEnd Log - ${date:format=HH\\:mm\\:ss}",
                    FileName = AppConfig.LogFileLocation + "\\${shortdate}.log",
                    Layout =
                        "${date:format=HH\\:mm\\:ss} ${logger} : ${level:uppercase=true} : ${message} ${exception:format=message}"
                };
            }
            else
            {
                if (!Directory.Exists("C:\\Logs"))
                    Directory.CreateDirectory("C:\\Logs");
                fileTarget = new FileTarget
                {
                    ArchiveAboveSize = 1048576,
                    AutoFlush = true,
                    MaxArchiveFiles = 10,
                    CreateDirs = true,
                    EnableFileDelete = true,
                    Header =
                        "\n${date:format=HH\\:mm\\:ss}\nLog file for IMR Crawler Application\n===============================\n",
                    Footer = "===============================\nEnd Log - ${date:format=HH\\:mm\\:ss}",
                    FileName = "C:\\Logs\\${shortdate}.log",
                    Layout =
                        "${date:format=HH\\:mm\\:ss} ${logger} : ${level:uppercase=true} : ${message} ${exception:format=message}"
                };
            }

            config.AddTarget("file", fileTarget);

            #endregion

            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration 
            LogManager.Configuration = config;

            #endregion


            Application.Run(new frmMain());
        }

        private static void SetupConfig()
        {
            string path = Application.StartupPath;
            string settingsPath = AppConfig.IMRAppSettingsPath;

            AppConfig.DirectoryCheck();

            string configFile = Path.Combine(settingsPath, AppConfig.IMRAppAppFileName);
            string file = Path.Combine(path, "IMR.Crawler.exe.config");

            if (File.Exists(configFile))
            {
                try
                {
                    if (File.Exists(file))
                    {
                        // in case we have changed system configurations
                        ConfigSettings.MergeRequiredSettings(file, configFile);
                    }
                    File.Copy(configFile, file, true);
                }
                catch { }
            }


            ConfigSettings.Refresh();
        }
    }
}

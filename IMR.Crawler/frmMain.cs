using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using IMR.Crawler.Helper;
using NLog;
using NLog.Config;
using NLog.Targets;
namespace IMR.Crawler

{
    public delegate void LoggingHandler(string output, MessageType type);


    public enum MessageType
    {
        General,
        Error,
        Exception,
        Info,
        Warning

    }
    public partial class frmMain : Office2007Form
    {
        #region .. code for Flucuring ..
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        private object lockObject = new object();
        static readonly Logger Logger = LogManager.GetLogger("MainViewer");
        public frmMain()
        {
            InitializeComponent();
            //UIHandler.SetDoubleBuffered(tblSearch);

            WebSearch.LogHandler += new LoggingHandler(Search_LogHandler);
            DataSearch.LogHandler += new LoggingHandler(Search_LogHandler);
        }
        private void btSearch_Click(object sender, EventArgs e)
        {

            tbMain.SelectedTab = tbWebSearch;


        }
        public void Search_LogHandler(string message, MessageType type)
        {
            lock (lockObject)
            {
                switch (type)
                {
                    case MessageType.General:
                    case MessageType.Info:
                        Logger.Info(message);
                        break;
                    case MessageType.Error:
                    case MessageType.Exception:
                        Logger.Error(message);
                        break;
                    case MessageType.Warning:
                        Logger.Warn(message);
                        break;

                }
            }
        }

        private void btSearchLocal_Click(object sender, EventArgs e)
        {

            tbMain.SelectedTab = tbDataSearch;

        }

        private void btSettings_Click(object sender, EventArgs e)
        {

            var frm = new frmSettings();
            frm.ShowDialog();

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
           
        }
    }
}

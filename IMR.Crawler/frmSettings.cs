using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMR.Crawler
{
    public partial class frmSettings : DevComponents.DotNetBar.Office2007Form
    {
        public frmSettings()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            txtPDFLocation.Text = Configuration.AppConfig.PDFSaveLocation;
            txtLog.Text = Configuration.AppConfig.LogFileLocation;
            txtProxyFileLocation.Text = Configuration.AppConfig.ProxyFilePath;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {

                    txtPDFLocation.Text = folderBrowserDialog1.SelectedPath;

                }


            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void btnBrowseLog_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {

                    this.txtLog.Text = folderBrowserDialog1.SelectedPath;

                }


            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }

        }

        private void btnBrowseProxy_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {

                    this.txtProxyFileLocation.Text = openFileDialog1.FileName;

                }


            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void btnProxyClear_Click(object sender, EventArgs e)
        {
            txtProxyFileLocation.Text = "";
        }
        private bool ValidateData()
        {
            if (this.txtPDFLocation.TextLength == 0)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Please select PDF File Save Location");
                return false;
            }


            return true;

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Configuration.AppConfig.PDFSaveLocation = txtPDFLocation.Text;
                Configuration.AppConfig.ProxyFilePath = txtProxyFileLocation.Text;
                Configuration.AppConfig.LogFileLocation = txtLog.Text;
                this.Close();
            }

            DevComponents.DotNetBar.MessageBoxEx.Show("Any changes in settings will be applicable after restart.", "Message");
        }
    }
}

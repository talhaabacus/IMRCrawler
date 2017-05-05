namespace IMR.Crawler
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClearLog = new DevComponents.DotNetBar.ButtonX();
            this.btnProxyClear = new DevComponents.DotNetBar.ButtonX();
            this.btnBrowseProxy = new DevComponents.DotNetBar.ButtonX();
            this.txtProxyFileLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.btnBrowseLog = new DevComponents.DotNetBar.ButtonX();
            this.txtLog = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnBrowse = new DevComponents.DotNetBar.ButtonX();
            this.txtPDFLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btSave = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ribbonBar1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 320);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSave});
            this.ribbonBar1.Location = new System.Drawing.Point(4, 4);
            this.ribbonBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(993, 72);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 1;
            this.ribbonBar1.Text = "ribbonBar1";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            // 
            // panel1
            // 
            this.panel1.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.btnClearLog);
            this.panel1.Controls.Add(this.btnProxyClear);
            this.panel1.Controls.Add(this.btnBrowseProxy);
            this.panel1.Controls.Add(this.txtProxyFileLocation);
            this.panel1.Controls.Add(this.labelX13);
            this.panel1.Controls.Add(this.btnBrowseLog);
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Controls.Add(this.labelX12);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtPDFLocation);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 232);
            this.panel1.Style.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.TabIndex = 0;
            // 
            // btnClearLog
            // 
            this.btnClearLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearLog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearLog.Location = new System.Drawing.Point(691, 84);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 28);
            this.btnClearLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearLog.TabIndex = 4;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnProxyClear
            // 
            this.btnProxyClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnProxyClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnProxyClear.Location = new System.Drawing.Point(691, 119);
            this.btnProxyClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProxyClear.Name = "btnProxyClear";
            this.btnProxyClear.Size = new System.Drawing.Size(100, 28);
            this.btnProxyClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnProxyClear.TabIndex = 7;
            this.btnProxyClear.Text = "Clear";
            this.btnProxyClear.Click += new System.EventHandler(this.btnProxyClear_Click);
            // 
            // btnBrowseProxy
            // 
            this.btnBrowseProxy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBrowseProxy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBrowseProxy.Location = new System.Drawing.Point(565, 119);
            this.btnBrowseProxy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseProxy.Name = "btnBrowseProxy";
            this.btnBrowseProxy.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseProxy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBrowseProxy.TabIndex = 6;
            this.btnBrowseProxy.Text = "Browse";
            this.btnBrowseProxy.Click += new System.EventHandler(this.btnBrowseProxy_Click);
            // 
            // txtProxyFileLocation
            // 
            // 
            // 
            // 
            this.txtProxyFileLocation.Border.Class = "TextBoxBorder";
            this.txtProxyFileLocation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProxyFileLocation.ButtonCustom.Tooltip = "";
            this.txtProxyFileLocation.ButtonCustom2.Tooltip = "";
            this.txtProxyFileLocation.Location = new System.Drawing.Point(284, 118);
            this.txtProxyFileLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProxyFileLocation.Name = "txtProxyFileLocation";
            this.txtProxyFileLocation.ReadOnly = true;
            this.txtProxyFileLocation.Size = new System.Drawing.Size(260, 22);
            this.txtProxyFileLocation.TabIndex = 5;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(73, 114);
            this.labelX13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(145, 28);
            this.labelX13.TabIndex = 55;
            this.labelX13.Text = "Proxy File Path";
            // 
            // btnBrowseLog
            // 
            this.btnBrowseLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBrowseLog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBrowseLog.Location = new System.Drawing.Point(565, 84);
            this.btnBrowseLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseLog.Name = "btnBrowseLog";
            this.btnBrowseLog.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBrowseLog.TabIndex = 3;
            this.btnBrowseLog.Text = "Browse";
            this.btnBrowseLog.Click += new System.EventHandler(this.btnBrowseLog_Click);
            // 
            // txtLog
            // 
            // 
            // 
            // 
            this.txtLog.Border.Class = "TextBoxBorder";
            this.txtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLog.ButtonCustom.Tooltip = "";
            this.txtLog.ButtonCustom2.Tooltip = "";
            this.txtLog.Location = new System.Drawing.Point(284, 87);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(260, 22);
            this.txtLog.TabIndex = 2;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(73, 82);
            this.labelX12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(145, 28);
            this.labelX12.TabIndex = 52;
            this.labelX12.Text = "Log File Location";
            // 
            // btnBrowse
            // 
            this.btnBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBrowse.Location = new System.Drawing.Point(565, 48);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnBrowse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPDFLocation
            // 
            // 
            // 
            // 
            this.txtPDFLocation.Border.Class = "TextBoxBorder";
            this.txtPDFLocation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPDFLocation.ButtonCustom.Tooltip = "";
            this.txtPDFLocation.ButtonCustom2.Tooltip = "";
            this.txtPDFLocation.Location = new System.Drawing.Point(284, 50);
            this.txtPDFLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPDFLocation.Name = "txtPDFLocation";
            this.txtPDFLocation.ReadOnly = true;
            this.txtPDFLocation.Size = new System.Drawing.Size(260, 22);
            this.txtPDFLocation.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(73, 47);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(145, 28);
            this.labelX2.TabIndex = 46;
            this.labelX2.Text = "PDF Save Location";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files|*.txt";
            // 
            // btSave
            // 
            this.btSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btSave.Image = global::IMR.Crawler.Properties.Resources.save;
            this.btSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btSave.Name = "btSave";
            this.btSave.Stretch = true;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btSave;
        private DevComponents.DotNetBar.PanelEx panel1;
        private DevComponents.DotNetBar.ButtonX btnClearLog;
        private DevComponents.DotNetBar.ButtonX btnProxyClear;
        private DevComponents.DotNetBar.ButtonX btnBrowseProxy;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProxyFileLocation;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.ButtonX btnBrowseLog;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLog;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btnBrowse;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPDFLocation;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
namespace IMR.Crawler
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbMain = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tbWebSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tbDataSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.menuBar = new DevComponents.DotNetBar.Bar();
            this.btSettings = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.webSearch1 = new IMR.Crawler.WebSearch();
            this.dataSearch1 = new IMR.Crawler.DataSearch();
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).BeginInit();
            this.tbMain.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuBar)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tbMain.CanReorderTabs = true;
            this.tbMain.Controls.Add(this.tabControlPanel1);
            this.tbMain.Controls.Add(this.tabControlPanel2);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.tbMain.SelectedTabIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1363, 717);
            this.tbMain.TabIndex = 0;
            this.tbMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tbMain.Tabs.Add(this.tbWebSearch);
            this.tbMain.Tabs.Add(this.tbDataSearch);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.webSearch1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1363, 691);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tbWebSearch;
            // 
            // tbWebSearch
            // 
            this.tbWebSearch.AttachedControl = this.tabControlPanel1;
            this.tbWebSearch.Name = "tbWebSearch";
            this.tbWebSearch.Text = "Crawling";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dataSearch1);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1363, 691);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tbDataSearch;
            // 
            // tbDataSearch
            // 
            this.tbDataSearch.AttachedControl = this.tabControlPanel2;
            this.tbDataSearch.Name = "tbDataSearch";
            this.tbDataSearch.Text = "Data Searching";
            // 
            // menuBar
            // 
            this.menuBar.AccessibleDescription = "DotNetBar Bar (menuBar)";
            this.menuBar.AccessibleName = "DotNetBar Bar";
            this.menuBar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.menuBar.AntiAlias = true;
            this.menuBar.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.menuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btSettings});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menuBar.MenuBar = true;
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1363, 24);
            this.menuBar.Stretch = true;
            this.menuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.menuBar.TabIndex = 1;
            this.menuBar.TabStop = false;
            // 
            // btSettings
            // 
            this.btSettings.Name = "btSettings";
            this.btSettings.Text = "Settings";
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tbMain);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 24);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1363, 717);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            this.panelEx1.Text = "panelEx1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // webSearch1
            // 
            this.webSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSearch1.Location = new System.Drawing.Point(1, 1);
            this.webSearch1.Margin = new System.Windows.Forms.Padding(5);
            this.webSearch1.Name = "webSearch1";
            this.webSearch1.Size = new System.Drawing.Size(1361, 689);
            this.webSearch1.TabIndex = 0;
            // 
            // dataSearch1
            // 
            this.dataSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSearch1.Location = new System.Drawing.Point(1, 1);
            this.dataSearch1.Margin = new System.Windows.Forms.Padding(5);
            this.dataSearch1.Name = "dataSearch1";
            this.dataSearch1.Size = new System.Drawing.Size(1361, 689);
            this.dataSearch1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 741);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuBar);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMR Crawler";
            this.TitleText = "IMRCrawler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).EndInit();
            this.tbMain.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuBar)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tbMain;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tbWebSearch;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tbDataSearch;
        private DevComponents.DotNetBar.Bar menuBar;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonItem btSettings;
        private WebSearch webSearch1;
        private DataSearch dataSearch1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
    }
}


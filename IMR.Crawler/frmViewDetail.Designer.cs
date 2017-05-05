namespace IMR.Crawler
{
    partial class frmViewDetail
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
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tbFormat1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tbFormat3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tbFormat2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.txtPDFtext = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbOther = new DevComponents.DotNetBar.TabItem(this.components);
            this.viewFormat11 = new IMR.Crawler.Controls.ViewFormat1();
            this.viewFormat31 = new IMR.Crawler.Controls.ViewFormat3();
            this.viewFormat21 = new IMR.Crawler.Controls.ViewFormat2();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(1111, 748);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tbFormat1);
            this.tabControl1.Tabs.Add(this.tbFormat2);
            this.tabControl1.Tabs.Add(this.tbFormat3);
            this.tabControl1.Tabs.Add(this.tbOther);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.AutoScroll = true;
            this.tabControlPanel1.AutoScrollMinSize = new System.Drawing.Size(400, 800);
            this.tabControlPanel1.Controls.Add(this.viewFormat11);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1111, 722);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tbFormat1;
            // 
            // tbFormat1
            // 
            this.tbFormat1.AttachedControl = this.tabControlPanel1;
            this.tbFormat1.Name = "tbFormat1";
            this.tbFormat1.Text = "Details";
            this.tbFormat1.Visible = false;
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.AutoScroll = true;
            this.tabControlPanel3.AutoScrollMinSize = new System.Drawing.Size(400, 1000);
            this.tabControlPanel3.Controls.Add(this.viewFormat31);
            this.tabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(1111, 722);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tbFormat3;
            // 
            // tbFormat3
            // 
            this.tbFormat3.AttachedControl = this.tabControlPanel3;
            this.tbFormat3.Name = "tbFormat3";
            this.tbFormat3.Text = "Details";
            this.tbFormat3.Visible = false;
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.AutoScroll = true;
            this.tabControlPanel2.AutoScrollMinSize = new System.Drawing.Size(400, 800);
            this.tabControlPanel2.Controls.Add(this.viewFormat21);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1111, 722);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tbFormat2;
            // 
            // tbFormat2
            // 
            this.tbFormat2.AttachedControl = this.tabControlPanel2;
            this.tbFormat2.Name = "tbFormat2";
            this.tbFormat2.Text = "Details";
            this.tbFormat2.Visible = false;
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.txtPDFtext);
            this.tabControlPanel4.Controls.Add(this.labelX6);
            this.tabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(1111, 722);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tbOther;
            // 
            // txtPDFtext
            // 
            // 
            // 
            // 
            this.txtPDFtext.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPDFtext.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPDFtext.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPDFtext.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtPDFtext.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPDFtext.ButtonCustom.Tooltip = "";
            this.txtPDFtext.ButtonCustom2.Tooltip = "";
            this.txtPDFtext.Location = new System.Drawing.Point(99, 9);
            this.txtPDFtext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPDFtext.Multiline = true;
            this.txtPDFtext.Name = "txtPDFtext";
            this.txtPDFtext.PreventEnterBeep = true;
            this.txtPDFtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPDFtext.Size = new System.Drawing.Size(996, 377);
            this.txtPDFtext.TabIndex = 57;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(16, 5);
            this.labelX6.Margin = new System.Windows.Forms.Padding(4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(171, 50);
            this.labelX6.TabIndex = 58;
            this.labelX6.Text = "PDF Text";
            this.labelX6.WordWrap = true;
            // 
            // tbOther
            // 
            this.tbOther.AttachedControl = this.tabControlPanel4;
            this.tbOther.Name = "tbOther";
            this.tbOther.Text = "Details";
            this.tbOther.Visible = false;
            // 
            // viewFormat11
            // 
            this.viewFormat11.AutoScroll = true;
            this.viewFormat11.BackColor = System.Drawing.SystemColors.Control;
            this.viewFormat11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewFormat11.Location = new System.Drawing.Point(1, 1);
            this.viewFormat11.Margin = new System.Windows.Forms.Padding(5);
            this.viewFormat11.Name = "viewFormat11";
            this.viewFormat11.Size = new System.Drawing.Size(1088, 800);
            this.viewFormat11.TabIndex = 0;
            // 
            // viewFormat31
            // 
            this.viewFormat31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewFormat31.Location = new System.Drawing.Point(1, 1);
            this.viewFormat31.Margin = new System.Windows.Forms.Padding(5);
            this.viewFormat31.Name = "viewFormat31";
            this.viewFormat31.Size = new System.Drawing.Size(1088, 1000);
            this.viewFormat31.TabIndex = 0;
            // 
            // viewFormat21
            // 
            this.viewFormat21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewFormat21.Location = new System.Drawing.Point(1, 1);
            this.viewFormat21.Margin = new System.Windows.Forms.Padding(4);
            this.viewFormat21.Name = "viewFormat21";
            this.viewFormat21.Size = new System.Drawing.Size(1088, 800);
            this.viewFormat21.TabIndex = 0;
            // 
            // frmViewDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 748);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmViewDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Detail";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tbFormat1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tbOther;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tbFormat3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tbFormat2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPDFtext;
        private DevComponents.DotNetBar.LabelX labelX6;
        private Controls.ViewFormat3 viewFormat31;
        private Controls.ViewFormat2 viewFormat21;
        private Controls.ViewFormat1 viewFormat11;
    }
}
namespace BEC3
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recieptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despatchPickListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recieptReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1StatusBar1 = new C1.Win.C1Ribbon.C1StatusBar();
            this.ribbonLabel1 = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.ribbonLabel2 = new C1.Win.C1Ribbon.RibbonLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // TransactionsToolStripMenuItem
            // 
            this.TransactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recieptToolStripMenuItem,
            this.despatchPickListToolStripMenuItem});
            this.TransactionsToolStripMenuItem.Name = "TransactionsToolStripMenuItem";
            this.TransactionsToolStripMenuItem.Size = new System.Drawing.Size(86, 19);
            this.TransactionsToolStripMenuItem.Text = "Transactions";
            // 
            // recieptToolStripMenuItem
            // 
            this.recieptToolStripMenuItem.Name = "recieptToolStripMenuItem";
            this.recieptToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.recieptToolStripMenuItem.Text = "Reciept";
            this.recieptToolStripMenuItem.Click += new System.EventHandler(this.recieptToolStripMenuItem_Click);
            // 
            // despatchPickListToolStripMenuItem
            // 
            this.despatchPickListToolStripMenuItem.Name = "despatchPickListToolStripMenuItem";
            this.despatchPickListToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.despatchPickListToolStripMenuItem.Text = "Despatch PickList";
            this.despatchPickListToolStripMenuItem.Click += new System.EventHandler(this.despatchPickListToolStripMenuItem_Click);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.TransactionsToolStripMenuItem,
            this.ReportsToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.MenuStrip1.Size = new System.Drawing.Size(883, 25);
            this.MenuStrip1.TabIndex = 12;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMasterToolStripMenuItem,
            this.customerMasterToolStripMenuItem,
            this.supToolStripMenuItem,
            this.userMasterToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.itemMasterToolStripMenuItem.Text = "Item Master";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // customerMasterToolStripMenuItem
            // 
            this.customerMasterToolStripMenuItem.Name = "customerMasterToolStripMenuItem";
            this.customerMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.customerMasterToolStripMenuItem.Text = "Customer Master";
            this.customerMasterToolStripMenuItem.Click += new System.EventHandler(this.customerMasterToolStripMenuItem_Click);
            // 
            // supToolStripMenuItem
            // 
            this.supToolStripMenuItem.Name = "supToolStripMenuItem";
            this.supToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.supToolStripMenuItem.Text = "Supplier Master";
            this.supToolStripMenuItem.Click += new System.EventHandler(this.supToolStripMenuItem_Click);
            // 
            // userMasterToolStripMenuItem
            // 
            this.userMasterToolStripMenuItem.Name = "userMasterToolStripMenuItem";
            this.userMasterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.userMasterToolStripMenuItem.Text = "User Master";
            this.userMasterToolStripMenuItem.Click += new System.EventHandler(this.userMasterToolStripMenuItem_Click);
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recieptReportToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(59, 19);
            this.ReportsToolStripMenuItem.Text = "Reports";
            // 
            // recieptReportToolStripMenuItem
            // 
            this.recieptReportToolStripMenuItem.Name = "recieptReportToolStripMenuItem";
            this.recieptReportToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.recieptReportToolStripMenuItem.Text = "Reciept Report";
            this.recieptReportToolStripMenuItem.Click += new System.EventHandler(this.recieptReportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Despatch Report";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // c1StatusBar1
            // 
            this.c1StatusBar1.Location = new System.Drawing.Point(0, 491);
            this.c1StatusBar1.Name = "c1StatusBar1";
            this.c1StatusBar1.RightPaneItems.Add(this.ribbonLabel1);
            this.c1StatusBar1.RightPaneItems.Add(this.ribbonSeparator1);
            this.c1StatusBar1.RightPaneItems.Add(this.ribbonLabel2);
            this.c1StatusBar1.Size = new System.Drawing.Size(883, 22);
            this.c1ThemeController1.SetTheme(this.c1StatusBar1, "(default)");
            this.c1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Custom;
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Name = "ribbonLabel1";
            this.ribbonLabel1.Text = "Label";
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "Label";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            this.utilitiesToolStripMenuItem.Visible = false;
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 513);
            this.Controls.Add(this.c1StatusBar1);
            this.Controls.Add(this.MenuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "BEC";
            this.c1ThemeController1.SetTheme(this, "(default)");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1StatusBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripMenuItem TransactionsToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        internal System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.ToolStripMenuItem recieptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despatchPickListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recieptReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userMasterToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private C1.Win.C1Ribbon.C1StatusBar c1StatusBar1;
        public C1.Win.C1Ribbon.RibbonLabel ribbonLabel1;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private C1.Win.C1Ribbon.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;

    }
}


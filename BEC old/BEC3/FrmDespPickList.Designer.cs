namespace BEC3
{
    partial class FrmDespPickList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespPickList));
            this.cmdSave = new C1.Win.C1Input.C1Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbComp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dteToday = new System.Windows.Forms.DateTimePicker();
            this.cmdSupp = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.cmdClearAll = new C1.Win.C1Input.C1Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdClear = new C1.Win.C1Input.C1Button();
            this.cmdAdd = new C1.Win.C1Input.C1Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdClose = new C1.Win.C1Input.C1Button();
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClearAll)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(89, 519);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(186, 37);
            this.cmdSave.TabIndex = 28;
            this.cmdSave.Text = "Save && Print";
            this.c1ThemeController1.SetTheme(this.cmdSave, "(default)");
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbComp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dteToday);
            this.panel1.Controls.Add(this.cmdSupp);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRef);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRec);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 78);
            this.panel1.TabIndex = 26;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // cmbComp
            // 
            this.cmbComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComp.BackColor = System.Drawing.Color.White;
            this.cmbComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComp.ForeColor = System.Drawing.Color.Black;
            this.cmbComp.FormattingEnabled = true;
            this.cmbComp.Location = new System.Drawing.Point(97, 45);
            this.cmbComp.Name = "cmbComp";
            this.cmbComp.Size = new System.Drawing.Size(236, 23);
            this.cmbComp.TabIndex = 4;
            this.c1ThemeController1.SetTheme(this.cmbComp, "(default)");
            this.cmbComp.SelectedIndexChanged += new System.EventHandler(this.cmbComp_SelectedIndexChanged);
            this.cmbComp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbComp_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Company :";
            this.c1ThemeController1.SetTheme(this.label3, "(default)");
            // 
            // dteToday
            // 
            this.dteToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteToday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteToday.Location = new System.Drawing.Point(623, 11);
            this.dteToday.Name = "dteToday";
            this.dteToday.Size = new System.Drawing.Size(114, 21);
            this.dteToday.TabIndex = 3;
            // 
            // cmdSupp
            // 
            this.cmdSupp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmdSupp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdSupp.BackColor = System.Drawing.Color.White;
            this.cmdSupp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSupp.ForeColor = System.Drawing.Color.Black;
            this.cmdSupp.FormattingEnabled = true;
            this.cmdSupp.Location = new System.Drawing.Point(456, 45);
            this.cmdSupp.Name = "cmdSupp";
            this.cmdSupp.Size = new System.Drawing.Size(281, 23);
            this.cmdSupp.TabIndex = 5;
            this.c1ThemeController1.SetTheme(this.cmdSupp, "(default)");
            this.cmdSupp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdSupp_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(530, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Desp Date :";
            this.c1ThemeController1.SetTheme(this.label10, "(default)");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(369, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Customer :";
            this.c1ThemeController1.SetTheme(this.label5, "(default)");
            // 
            // txtRef
            // 
            this.txtRef.BackColor = System.Drawing.Color.White;
            this.txtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.ForeColor = System.Drawing.Color.Black;
            this.txtRef.Location = new System.Drawing.Point(348, 11);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(96, 21);
            this.txtRef.TabIndex = 2;
            this.c1ThemeController1.SetTheme(this.txtRef, "(default)");
            this.txtRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRef_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(281, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ref No :";
            this.c1ThemeController1.SetTheme(this.label2, "(default)");
            // 
            // txtRec
            // 
            this.txtRec.BackColor = System.Drawing.Color.White;
            this.txtRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRec.ForeColor = System.Drawing.Color.Black;
            this.txtRec.Location = new System.Drawing.Point(97, 11);
            this.txtRec.Name = "txtRec";
            this.txtRec.ReadOnly = true;
            this.txtRec.Size = new System.Drawing.Size(100, 21);
            this.txtRec.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.txtRec, "(default)");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desp No :";
            this.c1ThemeController1.SetTheme(this.label1, "(default)");
            // 
            // cmdClearAll
            // 
            this.cmdClearAll.Location = new System.Drawing.Point(300, 519);
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.Size = new System.Drawing.Size(173, 37);
            this.cmdClearAll.TabIndex = 29;
            this.cmdClearAll.Text = "Clear";
            this.c1ThemeController1.SetTheme(this.cmdClearAll, "(default)");
            this.cmdClearAll.UseVisualStyleBackColor = true;
            this.cmdClearAll.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdClear);
            this.panel2.Controls.Add(this.cmdAdd);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbProd);
            this.panel2.Controls.Add(this.label6);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(8, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 107);
            this.panel2.TabIndex = 27;
            this.c1ThemeController1.SetTheme(this.panel2, "(default)");
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(617, 58);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(120, 37);
            this.cmdClear.TabIndex = 8;
            this.cmdClear.Text = "Clear";
            this.c1ThemeController1.SetTheme(this.cmdClear, "Windows8Gray");
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(617, 11);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(120, 37);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "Add";
            this.c1ThemeController1.SetTheme(this.cmdAdd, "Windows8Gray");
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.Black;
            this.txtQty.Location = new System.Drawing.Point(97, 56);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(162, 21);
            this.txtQty.TabIndex = 6;
            this.c1ThemeController1.SetTheme(this.txtQty, "(default)");
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(56, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Qty :";
            this.c1ThemeController1.SetTheme(this.label8, "(default)");
            // 
            // cmbProd
            // 
            this.cmbProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProd.BackColor = System.Drawing.Color.White;
            this.cmbProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProd.ForeColor = System.Drawing.Color.Black;
            this.cmbProd.FormattingEnabled = true;
            this.cmbProd.Location = new System.Drawing.Point(97, 11);
            this.cmbProd.Name = "cmbProd";
            this.cmbProd.Size = new System.Drawing.Size(501, 23);
            this.cmbProd.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.cmbProd, "(default)");
            this.cmbProd.SelectedValueChanged += new System.EventHandler(this.cmbProd_SelectedValueChanged);
            this.cmbProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProd_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Item Name :";
            this.c1ThemeController1.SetTheme(this.label6, "(default)");
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(498, 519);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(173, 37);
            this.cmdClose.TabIndex = 30;
            this.cmdClose.Text = "Close";
            this.c1ThemeController1.SetTheme(this.cmdClose, "(default)");
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.c1TrueDBGrid1.EmptyRows = true;
            this.c1TrueDBGrid1.ExtendRightColumn = true;
            this.c1TrueDBGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1TrueDBGrid1.ForeColor = System.Drawing.Color.Black;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(8, 210);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RowDivider.Color = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.c1TrueDBGrid1.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
            this.c1TrueDBGrid1.RowHeight = 20;
            this.c1TrueDBGrid1.RowSubDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(743, 300);
            this.c1TrueDBGrid1.TabIndex = 25;
            this.c1ThemeController1.SetTheme(this.c1TrueDBGrid1, "(default)");
            this.c1TrueDBGrid1.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.c1TrueDBGrid1_BeforeColEdit);
            this.c1TrueDBGrid1.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.c1TrueDBGrid1_AfterColEdit);
            this.c1TrueDBGrid1.AfterUpdate += new System.EventHandler(this.c1TrueDBGrid1_AfterUpdate);
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // FrmDespPickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 564);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdClearAll);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.c1TrueDBGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmDespPickList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despatch PickList";
            this.Load += new System.EventHandler(this.FrmDespPickList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClearAll)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1Button cmdSave;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dteToday;
        private System.Windows.Forms.ComboBox cmdSupp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRec;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button cmdClearAll;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1Button cmdClear;
        private C1.Win.C1Input.C1Button cmdAdd;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbProd;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button cmdClose;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private System.Windows.Forms.ComboBox cmbComp;
        private System.Windows.Forms.Label label3;

    }
}
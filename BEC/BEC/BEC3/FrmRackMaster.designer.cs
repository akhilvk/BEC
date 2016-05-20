namespace BEC3
{
    partial class FrmRackMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRackMaster));
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1Button4 = new C1.Win.C1Input.C1Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.c1DockingTabPage1 = new C1.Win.C1Command.C1DockingTabPage();
            this.DgvProduct = new System.Windows.Forms.DataGridView();
            this.Rack_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rack_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1DockingTabPage2 = new C1.Win.C1Command.C1DockingTabPage();
            this.c1Button3 = new C1.Win.C1Input.C1Button();
            this.c1Button2 = new C1.Win.C1Input.C1Button();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrackNo = new System.Windows.Forms.TextBox();
            this.txtRackId = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.c1Button5 = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.c1DockingTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduct)).BeginInit();
            this.c1DockingTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button5)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Button4
            // 
            this.c1Button4.Location = new System.Drawing.Point(331, 356);
            this.c1Button4.Name = "c1Button4";
            this.c1Button4.Size = new System.Drawing.Size(68, 24);
            this.c1Button4.TabIndex = 4;
            this.c1Button4.Text = "Clear";
            this.c1ThemeController1.SetTheme(this.c1Button4, "(default)");
            this.c1Button4.UseVisualStyleBackColor = true;
            this.c1Button4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button4.Click += new System.EventHandler(this.c1Button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(158, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 20);
            this.textBox1.TabIndex = 2;
            this.c1ThemeController1.SetTheme(this.textBox1, "(default)");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rack No :";
            this.c1ThemeController1.SetTheme(this.label1, "(default)");
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage1);
            this.c1DockingTab1.Controls.Add(this.c1DockingTabPage2);
            this.c1DockingTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1DockingTab1.Location = new System.Drawing.Point(1, -1);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.SelectedIndex = 2;
            this.c1DockingTab1.Size = new System.Drawing.Size(564, 430);
            this.c1DockingTab1.TabIndex = 2;
            this.c1DockingTab1.TabsSpacing = 7;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.c1ThemeController1.SetTheme(this.c1DockingTab1, "(default)");
            // 
            // c1DockingTabPage1
            // 
            this.c1DockingTabPage1.Controls.Add(this.DgvProduct);
            this.c1DockingTabPage1.Controls.Add(this.textBox1);
            this.c1DockingTabPage1.Controls.Add(this.label1);
            this.c1DockingTabPage1.Location = new System.Drawing.Point(1, 24);
            this.c1DockingTabPage1.Name = "c1DockingTabPage1";
            this.c1DockingTabPage1.Size = new System.Drawing.Size(562, 405);
            this.c1DockingTabPage1.TabIndex = 0;
            this.c1DockingTabPage1.Text = "Rack Master";
            this.c1DockingTabPage1.Click += new System.EventHandler(this.c1DockingTabPage1_Click);
            // 
            // DgvProduct
            // 
            this.DgvProduct.AllowUserToAddRows = false;
            this.DgvProduct.AllowUserToDeleteRows = false;
            this.DgvProduct.AllowUserToResizeColumns = false;
            this.DgvProduct.AllowUserToResizeRows = false;
            this.DgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.DgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rack_id,
            this.Rack_no});
            this.DgvProduct.Location = new System.Drawing.Point(29, 77);
            this.DgvProduct.Name = "DgvProduct";
            this.DgvProduct.ReadOnly = true;
            this.DgvProduct.RowHeadersVisible = false;
            this.DgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProduct.Size = new System.Drawing.Size(499, 272);
            this.DgvProduct.TabIndex = 8;
            this.DgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProduct_CellDoubleClick);
            // 
            // Rack_id
            // 
            this.Rack_id.DataPropertyName = "Rack_id";
            this.Rack_id.FillWeight = 80F;
            this.Rack_id.HeaderText = "Rack Id";
            this.Rack_id.Name = "Rack_id";
            this.Rack_id.ReadOnly = true;
            // 
            // Rack_no
            // 
            this.Rack_no.DataPropertyName = "Rack_no";
            this.Rack_no.HeaderText = "Rack No";
            this.Rack_no.Name = "Rack_no";
            this.Rack_no.ReadOnly = true;
            // 
            // c1DockingTabPage2
            // 
            this.c1DockingTabPage2.Controls.Add(this.c1Button5);
            this.c1DockingTabPage2.Controls.Add(this.c1Button4);
            this.c1DockingTabPage2.Controls.Add(this.c1Button3);
            this.c1DockingTabPage2.Controls.Add(this.c1Button2);
            this.c1DockingTabPage2.Controls.Add(this.c1Button1);
            this.c1DockingTabPage2.Controls.Add(this.panel1);
            this.c1DockingTabPage2.Location = new System.Drawing.Point(1, 24);
            this.c1DockingTabPage2.Name = "c1DockingTabPage2";
            this.c1DockingTabPage2.Size = new System.Drawing.Size(562, 405);
            this.c1DockingTabPage2.TabIndex = 1;
            this.c1DockingTabPage2.Text = "Add New Item";
            // 
            // c1Button3
            // 
            this.c1Button3.Location = new System.Drawing.Point(415, 356);
            this.c1Button3.Name = "c1Button3";
            this.c1Button3.Size = new System.Drawing.Size(68, 24);
            this.c1Button3.TabIndex = 3;
            this.c1Button3.Text = "Close";
            this.c1ThemeController1.SetTheme(this.c1Button3, "(default)");
            this.c1Button3.UseVisualStyleBackColor = true;
            this.c1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button3.Click += new System.EventHandler(this.c1Button3_Click);
            // 
            // c1Button2
            // 
            this.c1Button2.Location = new System.Drawing.Point(247, 356);
            this.c1Button2.Name = "c1Button2";
            this.c1Button2.Size = new System.Drawing.Size(68, 24);
            this.c1Button2.TabIndex = 2;
            this.c1Button2.Text = "Delete";
            this.c1ThemeController1.SetTheme(this.c1Button2, "(default)");
            this.c1Button2.UseVisualStyleBackColor = true;
            this.c1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button2.Click += new System.EventHandler(this.c1Button2_Click);
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(163, 356);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(68, 24);
            this.c1Button1.TabIndex = 1;
            this.c1Button1.Text = "Save";
            this.c1ThemeController1.SetTheme(this.c1Button1, "(default)");
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtrackNo);
            this.panel1.Controls.Add(this.txtRackId);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(28, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 321);
            this.panel1.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.panel1, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(83, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rack No :";
            this.c1ThemeController1.SetTheme(this.label3, "(default)");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(83, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rack Id :";
            this.c1ThemeController1.SetTheme(this.label2, "(default)");
            // 
            // txtrackNo
            // 
            this.txtrackNo.BackColor = System.Drawing.Color.White;
            this.txtrackNo.ForeColor = System.Drawing.Color.Black;
            this.txtrackNo.Location = new System.Drawing.Point(208, 174);
            this.txtrackNo.Name = "txtrackNo";
            this.txtrackNo.Size = new System.Drawing.Size(213, 20);
            this.txtrackNo.TabIndex = 1;
            this.c1ThemeController1.SetTheme(this.txtrackNo, "(default)");
            // 
            // txtRackId
            // 
            this.txtRackId.BackColor = System.Drawing.Color.White;
            this.txtRackId.Enabled = false;
            this.txtRackId.ForeColor = System.Drawing.Color.Black;
            this.txtRackId.Location = new System.Drawing.Point(208, 124);
            this.txtRackId.Name = "txtRackId";
            this.txtRackId.Size = new System.Drawing.Size(213, 20);
            this.txtRackId.TabIndex = 0;
            this.c1ThemeController1.SetTheme(this.txtRackId, "(default)");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // c1Button5
            // 
            this.c1Button5.Location = new System.Drawing.Point(79, 356);
            this.c1Button5.Name = "c1Button5";
            this.c1Button5.Size = new System.Drawing.Size(68, 24);
            this.c1Button5.TabIndex = 5;
            this.c1Button5.Text = "Print";
            this.c1ThemeController1.SetTheme(this.c1Button5, "(default)");
            this.c1Button5.UseVisualStyleBackColor = true;
            this.c1Button5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button5.Click += new System.EventHandler(this.c1Button5_Click);
            // 
            // FrmRackMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 429);
            this.Controls.Add(this.c1DockingTab1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRackMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rack Master";
            this.Load += new System.EventHandler(this.FrmSuppMast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.c1DockingTabPage1.ResumeLayout(false);
            this.c1DockingTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProduct)).EndInit();
            this.c1DockingTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Input.C1Button c1Button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage1;
        private C1.Win.C1Command.C1DockingTabPage c1DockingTabPage2;
        private C1.Win.C1Input.C1Button c1Button3;
        private C1.Win.C1Input.C1Button c1Button2;
        private C1.Win.C1Input.C1Button c1Button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtrackNo;
        private System.Windows.Forms.TextBox txtRackId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView DgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rack_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rack_no;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private C1.Win.C1Input.C1Button c1Button5;
    }
}
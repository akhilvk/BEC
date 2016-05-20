namespace BEC3.Reports
{
    partial class FrmDespatchPicklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespatchPicklist));
            this.c1Button3 = new C1.Win.C1Input.C1Button();
            this.c1Button2 = new C1.Win.C1Input.C1Button();
            this.cmbProd = new System.Windows.Forms.ComboBox();
            this.c1ThemeController1 = new C1.Win.C1Themes.C1ThemeController();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Button3
            // 
            this.c1Button3.Location = new System.Drawing.Point(96, 201);
            this.c1Button3.Name = "c1Button3";
            this.c1Button3.Size = new System.Drawing.Size(115, 35);
            this.c1Button3.TabIndex = 19;
            this.c1Button3.Text = "Show";
            this.c1ThemeController1.SetTheme(this.c1Button3, "(default)");
            this.c1Button3.UseVisualStyleBackColor = true;
            this.c1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button3.Click += new System.EventHandler(this.c1Button3_Click);
            // 
            // c1Button2
            // 
            this.c1Button2.Location = new System.Drawing.Point(217, 201);
            this.c1Button2.Name = "c1Button2";
            this.c1Button2.Size = new System.Drawing.Size(115, 35);
            this.c1Button2.TabIndex = 18;
            this.c1Button2.Text = "Exit";
            this.c1ThemeController1.SetTheme(this.c1Button2, "(default)");
            this.c1Button2.UseVisualStyleBackColor = true;
            this.c1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1Button2.Click += new System.EventHandler(this.c1Button2_Click);
            // 
            // cmbProd
            // 
            this.cmbProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProd.BackColor = System.Drawing.Color.White;
            this.cmbProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProd.ForeColor = System.Drawing.Color.Black;
            this.cmbProd.FormattingEnabled = true;
            this.cmbProd.Location = new System.Drawing.Point(121, 76);
            this.cmbProd.Name = "cmbProd";
            this.cmbProd.Size = new System.Drawing.Size(291, 23);
            this.cmbProd.TabIndex = 16;
            this.c1ThemeController1.SetTheme(this.cmbProd, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(239)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Despatch No :";
            this.c1ThemeController1.SetTheme(this.label3, "(default)");
            // 
            // FrmDespatchPicklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 255);
            this.Controls.Add(this.c1Button3);
            this.Controls.Add(this.c1Button2);
            this.Controls.Add(this.cmbProd);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmDespatchPicklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despatch Picklist";
            this.Load += new System.EventHandler(this.FrmDespatchRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button c1Button3;
        private C1.Win.C1Themes.C1ThemeController c1ThemeController1;
        private C1.Win.C1Input.C1Button c1Button2;
        private System.Windows.Forms.ComboBox cmbProd;
        private System.Windows.Forms.Label label3;
    }
}
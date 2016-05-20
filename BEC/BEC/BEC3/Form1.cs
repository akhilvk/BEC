using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BALayer;
using BELayer;
using BEC3.Reports;

namespace BEC3
{
    public partial class FrmMain : Form
    {
        public string server;
        public string User;
        public string Password;
        public string database;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmItemMast();
            myform.MdiParent = this;
            myform.Show();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var myform = new FrmCustMast();
            myform.MdiParent = this;
            myform.Show();
        }

        private void supToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmSuppMast();
            myform.MdiParent = this;
            myform.Show();
        }

        private void recieptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmReciept();
            myform.MdiParent = this;
            myform.Show();
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new frmUserMaster();
            myform.MdiParent = this;
            myform.Show();
        }

        private void despatchPickListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmDespPickList();
            myform.MdiParent = this;
            myform.Show();
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.rsz_81754359;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ribbonLabel2.Text = DateTime.Now.ToString();
        }

        private void recieptReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmRecieptRep();
            myform.MdiParent = this;
            myform.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var myform = new FrmDespatchRep();
            myform.MdiParent = this;
            myform.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rackMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmRackMaster ();
            myform.MdiParent = this;
            myform.Show();

        }

        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmCategoryMaster ();
            myform.MdiParent = this;
            myform.Show();
        }

        private void despaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmDespatchPicklist ();
            myform.MdiParent = this;
            myform.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmStockReport ();
            myform.MdiParent = this;
            myform.Show();
        }

        private void physicalVerificationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myform = new FrmPhyVerRep();
            myform.MdiParent = this;
            myform.Show();
        }

    }
}

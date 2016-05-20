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

namespace BEC3.Reports
{
    public partial class FrmDespatchPicklist : Form
    {
        public FrmDespatchPicklist()
        {
            InitializeComponent();
        }
        private void c1Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDespatchRep_Load(object sender, EventArgs e)
        {
            BALItem baobj = new BALItem();
            DataTable da = new DataTable();
            DataSet ds = new DataSet();
            ClsBllRack objbll = new ClsBllRack();
            DataTable dt = objbll.ReturningDataByQ("select distinct Desp_no ,Desp_no  from dbo.tbl_desp_barcode");
            cmbProd.DataSource = dt;
            cmbProd.DisplayMember = "Desp_no";
            cmbProd.ValueMember = "Desp_no";
            cmbProd.SelectedIndex = -1;
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            ClsBllRack objbll = new ClsBllRack();
            DataTable da = new DataTable();
            string a = "";
            a = "EXEC dbo.Picklist @despno=@dno";
            a = a.Replace("@dno", cmbProd.Text );
            da=objbll.ReturningDataByQ (a);
                RptPickList rpt = new RptPickList();
                rpt.SetDataSource(da);
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();

           
        }
    }
}

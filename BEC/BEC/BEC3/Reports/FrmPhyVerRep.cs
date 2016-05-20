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
    public partial class FrmPhyVerRep : Form
    {
        public FrmPhyVerRep()
        {
            InitializeComponent();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BALPhyRep baobj = new BALPhyRep();
            BELPhyRep beobj = new BELPhyRep();
            beobj._from = dteFrom.Value;
            beobj._to = dteTo.Value;
            DataTable dt=new DataTable();
            dt.Load(baobj.PhyRep(beobj));
            if (dt.Rows.Count > 0)
            {
                CrptPhyVer rpt = new CrptPhyVer();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("fromdt", beobj._from.ToString("dd/MM/yyyy"));
                rpt.SetParameterValue("todt", beobj._to.ToString("dd/MM/yyyy"));
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();
            }

        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

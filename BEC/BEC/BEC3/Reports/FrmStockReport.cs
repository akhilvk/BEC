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
    public partial class FrmStockReport : Form
    {
        public FrmStockReport()
        {
            InitializeComponent();
        }
        private void c1Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        BALItem baobj = new BALItem();
        DataTable da = new DataTable();
        DataSet ds = new DataSet();
        ClsBllRack objbll = new ClsBllRack();
        string COMP = "";
        public void setValues()
        {
            objbll.Fdate = dteToday.Value;
            objbll.Tdate = dateTimePicker1.Value;
            if (cmbProd.Text == "")
            {
                objbll.prodid = "";
            }
            else
                objbll.prodid = cmbProd.Text;
          
            if (RdbBEC.Checked == true)
            {
                objbll .company = RdbBEC.Text;
                COMP = "BEC HEALTH CARE INDIA PVT.";
            }
            else
            { objbll.company = RdbBIO.Text; COMP = "BIO MEDICAL ENGINEERING COMPANY"; }

        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
            setValues();
            DataTable dtreport = objbll.Report(1);
            if (dtreport.Rows.Count > 0)
            {
                CrptSockSum rpt = new CrptSockSum();
                rpt.SetDataSource(dtreport);
                rpt.SetParameterValue("@Comp1", COMP);
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();
            }
            else { MessageBox.Show("No Report Within given Criteria"); }

        }

        private void FrmStockReport_Load(object sender, EventArgs e)
        {
            da.Load(baobj.ItemSelect());
            if (da.Rows.Count > 0)
            {
                ds.Tables.Add(da);
                cmbProd.DisplayMember = "Item_name";
                cmbProd.ValueMember = "Item_id";
                cmbProd.DataSource = ds.Tables[0];
                cmbProd.SelectedIndex = -1;
            }
        }
    }
}

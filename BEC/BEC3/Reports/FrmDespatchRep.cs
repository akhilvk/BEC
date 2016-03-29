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
    public partial class FrmDespatchRep : Form
    {
        public FrmDespatchRep()
        {
            InitializeComponent();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BELDespRep beobj = new BELDespRep();
            BALDespRep baobj = new BALDespRep();
            beobj._name = cmbProd.Text;
            beobj._from = dteToday.Value;
            beobj._to = dateTimePicker1.Value;
            DataTable dt = new DataTable();
            dt.Load(baobj.DespRep(beobj));
            if (dt.Rows.Count > 0)
            {
                RptDespSumm rpt = new RptDespSumm();
                rpt.SetDataSource(dt);
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();
            }
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
             BELDespRep beobj = new BELDespRep();
            BALDespRep baobj = new BALDespRep();
            beobj._name = cmbProd.Text;
            beobj._from = dteToday.Value;
            beobj._to = dateTimePicker1.Value;
            DataTable dt = new DataTable();
            dt.Load(baobj.DespRep(beobj));
            if (dt.Rows.Count > 0)
            {
                string serial = "";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    DataRow dr;
                    dr = dt.Rows[i];
                    serial = dr["Serial_no"].ToString() + "," + serial;

                }

                RptDespDet rpt = new RptDespDet();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("Serial", serial);
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();
            }
            else { MessageBox.Show("No Report Within given Criteria"); }

        


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
            da.Load(baobj.ItemSelect());
            if (da.Rows.Count > 0)
            {
                ds.Tables.Add(da);
                cmbProd.DisplayMember = "Item_name";
                cmbProd.ValueMember = "Item_id";
                cmbProd.DataSource = ds.Tables[0];
                cmbProd.SelectedIndex = -1;
            }
            else { MessageBox.Show("No Report Within given Criteria"); }
        }
    }
}

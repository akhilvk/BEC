using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BELayer;
using BALayer;
using BEC3.Reports;

namespace BEC3
{
    public partial class FrmRecieptRep : Form
    {
        public FrmRecieptRep()
        {
            InitializeComponent();
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BELRecRep beobj=new BELRecRep();
            BALRecRep  baobj=new BALRecRep();
            beobj._name = cmbProd.Text;
            beobj._from = dteToday.Value;
            beobj._to = dateTimePicker1.Value;
            DataTable dt=new DataTable();
            dt.Load(baobj.RecRep(beobj));
            if (dt.Rows.Count > 0)
            {
                RptRecSumm rpt = new RptRecSumm();
                rpt.SetDataSource(dt);
                FrmReportview rptview = new FrmReportview();
                rptview.MdiParent = this.MdiParent;
                rptview.crystalReportViewer1.ReportSource = rpt;
                rptview.Show();
            }
            else { MessageBox.Show("No Report Within given Criteria"); }
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            BELRecRep beobj = new BELRecRep();
            BALRecRep baobj = new BALRecRep();
            beobj._name = cmbProd.Text;
            beobj._from = dteToday.Value;
            beobj._to = dateTimePicker1.Value;
            DataTable dt = new DataTable();
            dt.Load(baobj.RecRep(beobj));
            if (dt.Rows.Count > 0)
            {
                string serial="";
               
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                   
                    DataRow dr;
                    dr = dt.Rows[i];
                    serial = dr["Serial_no"].ToString() + "," + serial;
                                
                }

                RptRecDet rpt = new RptRecDet();
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

        private void FrmRecieptRep_Load(object sender, EventArgs e)
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
        }

       
    }
}

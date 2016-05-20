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
    public partial class FrmDespPickList : Form
    {
        public int introw;
        public double availQty;
        public bool formload;
        public FrmDespPickList()
        {
            InitializeComponent();
        }

        private void FrmDespPickList_Load(object sender, EventArgs e)
        {
            formload = true;
            BALItem baobj = new BALItem();
            BAL bacust = new BAL();
            BALDesp badesp = new BALDesp();
            DataSet ds = new DataSet();
            DataTable da = new DataTable();
            da.Load(baobj.ItemSelect());
            if (da.Rows.Count > 0)
            {
                ds.Tables.Add(da);
                cmbProd.DisplayMember = "Item_name";
                cmbProd.ValueMember = "Item_id";
                cmbProd.DataSource = ds.Tables[0];
                cmbProd.SelectedIndex = -1;
            }
            //da.Rows.Clear();
            DataSet ds1 = new DataSet();
            DataTable da1 = new DataTable();
            da1.Load(bacust.custSelect());
            if (da1.Rows.Count > 0)
            {
                ds1.Tables.Add(da1);
                cmdSupp.DisplayMember = "Cust_name";
                cmdSupp.ValueMember = "Cust_id";
                cmdSupp.DataSource = ds1.Tables[0];
                cmdSupp.SelectedIndex = -1;
            }
            dteToday.Value = DateTime.Now;
            
            txtRec.Text = Convert.ToString(badesp.Getserial());
            cmbComp.Items.Add("BEC");
            cmbComp.Items.Add("BIO");
            c1TrueDBGrid1.SetDataBinding();
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            c1TrueDBGrid1.Splits[0].DisplayColumns[3].Visible = false;
            txtRef.Focus();
            formload = false;
            SendKeys.Send("\t");
            SendKeys.Send("\t");
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cmdSupp.SelectedValue != null && cmbComp.Text != null)
            {
                if (cmbProd.Text != "" && txtQty.Text != "")
                {
                    if (txtQty.Text == "0")
                    {
                        MessageBox.Show("Zero Qty not Allowed");
                    }
                    else
                    {
                        if (Convert.ToDouble(txtQty.Text) <= availQty)
                        {
                            if (c1TrueDBGrid1.Rows.Count != 0)
                            {
                                for (int i = 0; i <= c1TrueDBGrid1.Rows.Count - 1; i++)
                                {
                                    if (Convert.ToInt32(c1TrueDBGrid1[i, 0]) == (int)cmbProd.SelectedValue)
                                    {
                                        MessageBox.Show("Item Already Added!");
                                        return;
                                    }
                                }
                            }
                            c1TrueDBGrid1.Rows.Add();
                            c1TrueDBGrid1[introw, 0] = (int)cmbProd.SelectedValue;
                            c1TrueDBGrid1[introw, 1] = cmbProd.Text;
                            c1TrueDBGrid1[introw, 2] = txtQty.Text;
                            BELItem beitem = new BELItem();
                            BALItem baitem = new BALItem();
                            beitem._id = cmbProd.SelectedValue.ToString();
                            c1TrueDBGrid1[introw, 3] = baitem.ItemExpEnabled(beitem);
                            clearPanel2();
                            introw += 1;
                        }
                        else { MessageBox.Show("Quantity Not Available for this item"); }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Details Incomplete!");
                }
            }

            else { MessageBox.Show("Enter Despatch Details"); }
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            c1TrueDBGrid1.Splits[0].DisplayColumns[3].Visible = false;
        }
        public void clearPanel2()
        {
            cmbProd.SelectedIndex = -1;
            txtQty.Text = "";
            cmbProd.Focus();
        }
        public void clearAll()
        {
            BALDesp barec = new BALDesp();
            clearPanel2();
            availQty = 0.0;
            introw = 0;
            dteToday.Value = DateTime.Now;
            txtRec.Text = Convert.ToString(barec.Getserial());
            txtRef.Text = "";
            cmbComp.SelectedIndex = -1;
            cmdSupp.SelectedIndex = -1;
            c1TrueDBGrid1.Rows.Clear();
            c1TrueDBGrid1.SetDataBinding();
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            c1TrueDBGrid1.Splits[0].DisplayColumns[3].Visible = false;
            this.BackColor = Color.FromArgb(235, 237, 239);
            panel1.BackColor = Color.FromArgb(235, 237, 239);
            panel2.BackColor = Color.FromArgb(235, 237, 239);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cmdSupp.SelectedValue != null && cmbComp.Text != null)
            {
                if (c1TrueDBGrid1.Rows.Count != 0)
                {
                    string str;
                    BELDesp beobj = new BELDesp();
                    BALDesp baobj = new BALDesp();
                    List<string> lstitems = new List<string>();
                    beobj._Desno = txtRec.Text;
                    beobj._DesDate= dteToday.Value.ToString("MM/dd/yyyy");
                    beobj._Refno = txtRef.Text;
                    beobj._Cust = Convert.ToInt32(cmdSupp.SelectedValue);
                    beobj._Compname = cmbComp.Text;
                    for (int i = 0; i <= c1TrueDBGrid1.Rows.Count - 1; i++)
                    {
                        str = c1TrueDBGrid1[i, 0] + "|" + c1TrueDBGrid1[i, 1] + "|" + c1TrueDBGrid1[i, 2] + "|" + c1TrueDBGrid1[i, 3];
                        lstitems.Add(str);
                    }
                    beobj._lstItems = lstitems;
                    if (baobj.Insertdesp(beobj) == false)
                    {
                        MessageBox.Show("Despatch Save Failed");
                    }
                    else
                    {
                        MessageBox.Show("Picklist Successfully Saved");
                        DialogResult dialogResult = MessageBox.Show("Do You Want To Print Picklist?", "Confirm", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DataTable da = new DataTable();
                            da.Load(baobj.picklistprint(beobj));
                            if (da.Rows.Count != 0)
                            {
                                RptPickList rpt=new RptPickList();
                                rpt.SetDataSource(da);
                                FrmReportview rptview = new FrmReportview();
                                rptview.MdiParent = this.MdiParent;
                                rptview.crystalReportViewer1.ReportSource = rpt;
                                rptview.Show();
                                
                            }
                            
                           
                        }
                        clearAll();
                        txtRef.Focus();
                        return;
                    }
                }
              
                {
                    MessageBox.Show("Item Details Not Entered!");
                }

            }
            else { MessageBox.Show("Enter Despatch Details"); }
        }

        private void cmbProd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (formload == false && cmbProd.SelectedValue!=null) 
            {
                BELDesp beobj = new BELDesp();
                
                BALDesp baobj = new BALDesp();
                beobj._ItemCode = (int)cmbProd.SelectedValue;
                beobj._Compname = cmbComp.Text;
                availQty = baobj.Itemstock(beobj);

                
            }
            
            //formload = false;
        }

        private void c1TrueDBGrid1_BeforeColEdit(object sender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs e)
        {
            
        }

        private void c1TrueDBGrid1_AfterUpdate(object sender, EventArgs e)
        {

        }

        private void c1TrueDBGrid1_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            if (c1TrueDBGrid1.Col == 2)
            {
                BELDesp beobj = new BELDesp();
                BALDesp baobj = new BALDesp();
                beobj._ItemCode = Convert.ToInt32(c1TrueDBGrid1.Columns[0].Text);
                beobj._Compname = cmbComp.Text;
                availQty = baobj.Itemstock(beobj);
                if (availQty <= Convert.ToDouble(c1TrueDBGrid1.Columns[2].Text))
                {
                    MessageBox.Show("Quantity Not available.Available qauntity added");
                    c1TrueDBGrid1.Columns[2].Text = availQty.ToString();
                }
            }
        }

        private void cmdSupp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProd.Focus();
            }
        }

        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clearPanel2();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComp.SelectedIndex == 0)
            {
                this.BackColor = Color.FromArgb(235, 237, 239);
                panel1.BackColor = Color.FromArgb(235, 237, 239);
                panel2.BackColor = Color.FromArgb(235, 237, 239);

            }
            else
            {
                this.BackColor = Color.Pink;
                panel1.BackColor = Color.Pink;
                panel2.BackColor = Color.Pink;
            }
        }
    }

}

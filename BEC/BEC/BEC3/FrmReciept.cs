using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using BALayer;
using BELayer;
namespace BEC3
{
    public partial class FrmReciept : Form
    {
        public int introw;
        public Boolean boolload;
        public FrmReciept()
        {
            InitializeComponent();
            
        }

        private void FrmReciept_Load(object sender, EventArgs e)
        {
            boolload = true;
            BALItem baobj = new BALItem();
            BALSupp basupp = new BALSupp();
            BALRec barec = new BALRec();
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
            boolload = false;
            //da.Rows.Clear();
            DataSet ds1 = new DataSet();
            DataTable da1 = new DataTable();
            da1.Load(basupp.SuppSelect());
            if (da1.Rows.Count > 0)
            {
                ds1.Tables.Add(da1);
                cmdSupp.DisplayMember = "Supp_name";
                cmdSupp.ValueMember = "Supp_id";
                cmdSupp.DataSource = ds1.Tables[0];
                cmdSupp.SelectedIndex = -1;
            }
            dteToday.Value = DateTime.Now;
            dteExpiry.Value = DateTime.Now;
            txtRec.Text = Convert.ToString(barec.Getserial());
            cmbComp.Items.Add("BEC");
            cmbComp.Items.Add("BIO");
            c1TrueDBGrid1.SetDataBinding();
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            txtRef.Focus();
            SendKeys.Send("\t");
                SendKeys.Send("\t");
            }

        private void cmdSupp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProd.Focus();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (cmdSupp.SelectedValue != null && cmbComp.Text != null)
            {
                if (cmbProd.Text != "" && txtMrp.Text != "" && txtPrate.Text != "" && txtQty.Text != "")
                {
                 if(txtQty.Text=="0")
                {
                    MessageBox.Show("Zero Qty not Allowed");
                }
                else
                   
                 {
                     if (c1TrueDBGrid1.Rows.Count!=0)
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
                    c1TrueDBGrid1[introw, 2] = txtBatch.Text;
                    c1TrueDBGrid1[introw, 3] = dteExpiry.Value.ToString("dd/MM/yyyy");
                    c1TrueDBGrid1[introw, 4] = txtMrp.Text;
                    c1TrueDBGrid1[introw, 5] = txtPrate.Text;
                    c1TrueDBGrid1[introw, 6] = txtQty.Text;
                    c1TrueDBGrid1[introw, 7] = txtnoofPacks.Text;
                    introw += 1;
                    clearPanel2();
                }
                }
                else
                {
                    MessageBox.Show("Details Incomplete!");
                }
              }
            
            else { MessageBox.Show("Enter Receipt Details"); }
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
        }


        public void clearPanel2()
        {
            cmbProd.SelectedIndex = -1;
            txtMrp.Text = "";
            txtBatch.Text = "";
            txtPrate.Text="";
            txtQty.Text = "";
            txtnoofPacks.Text = "0";
            dteExpiry.Value = DateTime.Now;
            dteExpiry.Enabled = true;
            cmbProd.Focus();
        }
        public void clearAll()
        {
            BALRec barec = new BALRec();
            clearPanel2();
            introw = 0;
            dteToday.Value = DateTime.Now;
            txtRec.Text = Convert.ToString(barec.Getserial());
            txtRef.Text = "";
            cmbComp.SelectedIndex = -1;
            cmdSupp.SelectedIndex = -1;
            c1TrueDBGrid1.Rows.Clear();
            c1TrueDBGrid1.SetDataBinding();
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            this.BackColor = Color.FromArgb(235, 237, 239);
            panel1.BackColor = Color.FromArgb(235, 237, 239);
            panel2.BackColor = Color.FromArgb(235, 237, 239);
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clearPanel2();
           
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cmdSupp.SelectedValue != null && cmbComp.Text != null)
            {
                if (c1TrueDBGrid1.Rows.Count!=0)
                {
                    string str;
                   BELRec beobj=new BELRec();
                    BALRec baobj=new BALRec();
                   List<string> lstitems = new List<string>();
                    beobj._Recno=txtRec.Text;
                    beobj._RecDate = dteToday.Value.ToString("yyyy-MM-dd");
                    beobj._Refno= txtRef.Text;
                    beobj._Supp= Convert.ToInt32(cmdSupp.SelectedValue);
                    beobj._Compname = cmbComp.Text;
                    for (int i = 0; i <= c1TrueDBGrid1.Rows.Count - 1; i++)
                    {
                        str = c1TrueDBGrid1[i, 0] + "|" + c1TrueDBGrid1[i, 1] + "|" + c1TrueDBGrid1[i, 2] + "|" + c1TrueDBGrid1[i, 3] + "|" + c1TrueDBGrid1[i, 4] + "|" + c1TrueDBGrid1[i, 5] + "|" + c1TrueDBGrid1[i, 6] + "|" + c1TrueDBGrid1[i, 7];
                        lstitems.Add(str);
                    }
                    beobj._lstItems = lstitems;
                    if (baobj.InsertRec(beobj) == false)
                    {
                        MessageBox.Show("Reciept Save Failed");
                    }
                    else {
                        MessageBox.Show("Reciept Successfully Saved");
                        DialogResult dialogResult = MessageBox.Show("Do You Want To Print barcodes?", "Confirm", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            printbarcode(beobj);
                        }
                        clearAll();
                        txtRef.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Item Details Not Entered!");
                }

            }
            else { MessageBox.Show("Enter Receipt Details"); }
            //c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
        }


        //public void printbarcode(BELRec beobj)
        //{
        //    BALRec baobj=new BALRec();
        //    DataTable da=new DataTable();
        //    da.Load(baobj.getBarcode(beobj));
        //    int intline;
        //    string DPL;
        //    intline=da.Rows.Count-1;
        //    DataRow dr;
        //    if (da.Rows.Count > 0)
        //    {
        //        for (int i = 0; i <= intline; i++)
        //        {
        //            DPL = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Barcode.txt");

        //            if (intline+1 - i == 1)
        //            {
                       
        //                dr = da.Rows[i];
        //                DPL = DPL.Replace("[Barcode1a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode2a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode3a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());

        //                DPL = DPL.Replace("[Barcode1]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item1]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString());
        //                DPL = DPL.Replace("[Barcode2]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item2]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString());
        //                DPL = DPL.Replace("[Barcode3]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item3]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString());
 
        //            }
        //            else if (intline+1 - i == 2)
        //            {
        //                dr = da.Rows[i];
        //                DPL = DPL.Replace("[Barcode1]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode1a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item1]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString());
        //                dr = da.Rows[i + 1];
        //                DPL = DPL.Replace("[Barcode2]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode2a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item2]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString());
        //                DPL = DPL.Replace("[Barcode3]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode3a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item3]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString());
        //            }
        //            else
        //            {

        //                dr = da.Rows[i];
        //                //string a = dr["item_name"].ToString();
        //                DPL = DPL.Replace("[Barcode1]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode1a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item1]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString());
        //                dr = da.Rows[i + 1];
        //                DPL = DPL.Replace("[Barcode2]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode2a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item2]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString());
        //                dr = da.Rows[i + 2];
        //                DPL = DPL.Replace("[Barcode3]", dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Barcode3a]", dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
        //                DPL = DPL.Replace("[Item3]", dr["item_name"].ToString());
        //                DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString());
        //            }
        //            dllbuild.RawPrinterHelper.SendStringToPrinter(DefaultPrinterName(), DPL);
        //            i += 2;
        //        }
                
        //        //
        //    }
        //    else { MessageBox.Show("Nothing to Print"); }
        //}

        public void printbarcode(BELRec beobj)
        {
            BALRec baobj = new BALRec();
            DataTable da = new DataTable();
            da.Load(baobj.getBarcode(beobj));
            int intline;
            string DPL;
            intline = da.Rows.Count - 1;
            DataRow dr;
            if (da.Rows.Count > 0)
            {
                for (int i = 0; i <= intline; i++)
                {
                    dr = da.Rows[i];
                    if (Convert.ToDouble(dr["mrp"]) == 0.0)
                    {
                        DPL =
System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory+ "BarcodeNOMRP.txt");

                    }

                    else
                    {
                        DPL =
   System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
   + "Barcode.txt");

                    }
                    if (intline + 1 - i == 1)
                    {


                        DPL = DPL.Replace("[Barcode1a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode2a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode3a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());

                        DPL = DPL.Replace("[Barcode1]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item1]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString().Substring(0,dr["MRP"].ToString().Length-3));
                        DPL = DPL.Replace("[Barcode2]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item2]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                        DPL = DPL.Replace("[Barcode3]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item3]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));

                    }
                    else if (intline + 1 - i == 2)
                    {

                        DPL = DPL.Replace("[Barcode1]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode1a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item1]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                        dr = da.Rows[i + 1];
                        DPL = DPL.Replace("[Barcode2]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode2a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item2]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                        DPL = DPL.Replace("[Barcode3]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode3a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item3]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                    }
                    else
                    {


                        //string a = dr["item_name"].ToString();
                        DPL = DPL.Replace("[Barcode1]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode1a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item1]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP1]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                        dr = da.Rows[i + 1];
                        DPL = DPL.Replace("[Barcode2]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode2a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item2]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP2]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                        dr = da.Rows[i + 2];
                        DPL = DPL.Replace("[Barcode3]",
dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Barcode3a]",
dr["CompName"].ToString() + " " + dr["Serial_no"].ToString());
                        DPL = DPL.Replace("[Item3]",
dr["item_name"].ToString());
                        DPL = DPL.Replace("[MRP3]", dr["MRP"].ToString().Substring(0, dr["MRP"].ToString().Length - 3));
                    }
                    dllbuild.RawPrinterHelper.SendStringToPrinter(DefaultPrinterName(), DPL);
                    i += 2;
                }

                //
            }
            else { MessageBox.Show("Nothing to Print"); }
        }


        private String DefaultPrinterName()
        {
         System.Drawing.Printing.PrinterSettings  oPS =new System.Drawing.Printing.PrinterSettings();

         try
         {
             return oPS.PrinterName;
         }
         catch (Exception ex)
         {
             return "";
         }
         finally
         {

             oPS = null;
         }
        }
        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMrp_Leave(object sender, EventArgs e)
        {
            if (txtMrp.Text != "" && txtPrate.Text != "")
            {
                if (Convert.ToDouble(txtMrp.Text) < Convert.ToDouble(txtPrate.Text.ToString()))
                {
                    MessageBox.Show("MRP less than Prate!!");
                    txtMrp.Focus();
                }
                
             }
            double value;

            if (double.TryParse(txtMrp.Text, out value))
            {
                txtMrp.Text = String.Format("{0:0,0.00}", value);
            }
            else
            {
                // Some code to handle the bad input (not parsable to double)
            }
        }
        void NumberValidation(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar==08)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtPrate_Leave(object sender, EventArgs e)
        {
            if (txtPrate.Text != "")
            {
                if (Convert.ToDouble(txtMrp.Text) < Convert.ToDouble(txtPrate.Text.ToString()))
                {
                    MessageBox.Show("MRP less than Prate!!");
                    txtPrate.Focus();
                }
            }
            
            double value;

            if (double.TryParse(txtPrate.Text, out value))
            {
                txtPrate.Text = String.Format("{0:0,0.00}", value);
            }
            else
            {
                // Some code to handle the bad input (not parsable to double)
            }
        }

        private void txtMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberValidation(1,e);
        }

        private void txtPrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberValidation(1, e);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberValidation(1, e);
        }

        private void txtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double value;

                if (double.TryParse(txtMrp.Text, out value))
                {
                    txtMrp.Text = String.Format("{0:0,0.00}", value);
                }
                else
                {
                    // Some code to handle the bad input (not parsable to double)
                } 
            }
        }

        private void txtPrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double value;

                if (double.TryParse(txtPrate.Text, out value))
                {
                    txtPrate.Text = String.Format("{0:0,0.00}", value);
                }
                else
                {
                    // Some code to handle the bad input (not parsable to double)
                }
                dteExpiry.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double value;

                if (double.TryParse(txtQty.Text, out value))
                {
                    txtQty.Text = String.Format("{0:0,0.00}", value);
                }
                else
                {
                    // Some code to handle the bad input (not parsable to double)
                }
                txtnoofPacks.Focus();
            }

        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            double value;

            if (double.TryParse(txtQty.Text, out value))
            {
                txtQty.Text = String.Format("{0:0,0.00}", value);
            }
        }

        private void c1TrueDBGrid1_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            if (c1TrueDBGrid1.Col==5)
            {
                c1TrueDBGrid1.Columns[5].Text = String.Format("{0:0,0.00}", c1TrueDBGrid1.Columns[5].Text);
            }
        }

        private void cmbProd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtBatch.Focus();
            }
        }

        private void txtBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMrp.Focus();
            }
        }

        private void c1TrueDBGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (c1TrueDBGrid1.Rows.Count > 0)
                {
                    cmdSave.Focus();
                }
                else 
                {
                    MessageBox.Show("Item Details Incomplete");
                }
            }
        }

        private void cmbComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { ProcessTabKey(true); }
        }

        private void txtRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { ProcessTabKey(true); }
        }

        private void dteExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { ProcessTabKey(true);}
        }

        private void dteExpiry_Leave(object sender, EventArgs e)
        {
            if (dteExpiry.Value < DateTime.Now)
            {
                MessageBox.Show("Expiry Already Over");

            }
        }

        private void dteToday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTabKey(true);
            }
        }

        private void cmbProd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (boolload == false)
            {
                if (cmbProd.SelectedValue != null)
                {
                    BELItem beobj = new BELItem();
                    BALItem baobj = new BALItem();
                    beobj._id = cmbProd.SelectedValue.ToString();
                    if (baobj.ItemExpEnabled(beobj) == true)
                    {
                        dteExpiry.Enabled = true;
                    }
                    else { dteExpiry.Enabled = false; }
                    txtMrp.Text = String.Format("{0:0,0.00}", baobj.ItemMrp(beobj));
                    try
                    {
                        txtnoofPacks.Text = String.Format("{0}", baobj.ItemPacks(beobj));
                    }
                    catch { }
                }
            }
            
        }

        private void cmbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbComp.SelectedIndex == 0)
            {
                this.BackColor = Color.FromArgb(235, 237, 239);
                panel1.BackColor = Color.FromArgb(235, 237, 239);
                panel2.BackColor = Color.FromArgb(235, 237, 239);
                
            }
            else { this.BackColor = Color.Pink;
            panel1.BackColor = Color.Pink;
            panel2.BackColor = Color.Pink;
            }
        }

        private void txtnoofPacks_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        }

    }     



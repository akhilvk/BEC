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

namespace BEC3
{
    public partial class FrmRackMaster : Form
    {
        public FrmRackMaster()
        {
            InitializeComponent();
        }
        ClsBllRack objbll = new ClsBllRack();
        DataTable dtdgv = new DataTable();
        DataTable dtid = new DataTable();
        string sav = "save";
        public void clear()
        {
            GridFill();
            txtrackNo.Text = "";
            sav = "save";
            c1DockingTab1.SelectedIndex = 1;
            txtrackNo.Focus();
        }
        private void FrmSuppMast_Load(object sender, EventArgs e)
        {
            GridFill();
            txtrackNo.Focus();
        }
        public void GridFill()
        {
            dtdgv = objbll.gridfill(1);
            DgvProduct.DataSource = dtdgv;
            dtid = objbll.gridfill(2);
            try
            {
                txtRackId.Text = dtid.Rows[0][0].ToString();
                if (txtRackId.Text == "")
                {
                    txtRackId.Text = "1";
                }
            }
            catch { txtRackId.Text = "1"; }

        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (txtrackNo.Text == "")
            {
                errorProvider1.SetError(txtrackNo, "Enter Rack No");
                txtrackNo.Focus();
                return;
            }
            objbll.RackNo = txtrackNo.Text.Trim();
            if (sav == "save")
            {
                if (objbll.SavetoDb(3))
                {
                    MessageBox.Show("Data Saved Successfully");
                }
            }
            else
            {
                objbll.RackId = Convert.ToInt32(txtRackId.Text);
                if (objbll.SavetoDb(4))
                {
                    MessageBox.Show("Data Updated Successfully");
                }
            }
            clear();
        }

        private void c1Button4_Click(object sender, EventArgs e)
        {
            GridFill();
            txtrackNo.Text = "";
            sav = "save";
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
            if (sav == "update")
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure want to delete?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    objbll.RackId = Convert.ToInt32(txtRackId.Text);
                    if (objbll.SavetoDb(5))
                    {
                        MessageBox.Show("Data deleted Successfully");
                        clear();
                    }
                }
            }
        }

        private void c1DockingTabPage1_Click(object sender, EventArgs e)
        {
            GridFill();
            txtrackNo.Focus();
        }

        private void DgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvProduct.Rows.Count > 0)
            {
                int i;
                i = DgvProduct.SelectedCells[0].RowIndex;
                txtRackId.Text = DgvProduct.Rows[i].Cells[0].Value.ToString();
                txtrackNo.Text = DgvProduct.Rows[i].Cells[1].Value.ToString();
                sav = "update";
                c1DockingTab1.SelectedIndex = 1;
            }
        }
        private void Search(string FieldName)
        {
            DataView objDv;
            string[] Field = FieldName.Split(' ');
            FieldName = "";
            for (int i = 0; i < Field.Length; i++)
            {
                FieldName = FieldName + Field[i].Trim();
            }
            string Criteria = "", TextToSearch = "";
            TextToSearch = textBox1.Text;
            Criteria = FieldName + " Like '" + TextToSearch.ToUpper().Trim() + "%'";

            objDv = new DataView(dtdgv, Criteria, "", DataViewRowState.OriginalRows);
            DgvProduct.DataSource = objDv.ToTable();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search("Rack_No");
        }

        private void c1Button5_Click(object sender, EventArgs e)
        {
            if (sav == "update")
            {
                  DialogResult dialogResult = MessageBox.Show("Do You Want To Print barcodes?", "Confirm", MessageBoxButtons.YesNo);
                  if (dialogResult == DialogResult.Yes)
                  {
                      printRack();
                  }
            }

        }
        public void printRack()
        {
            string DPL;

            DPL = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Barcode.txt");

            DPL = DPL.Replace("[Barcode1a]", txtrackNo.Text );
            DPL = DPL.Replace("[Barcode2a]", txtrackNo.Text);
            DPL = DPL.Replace("[Barcode3a]", txtrackNo.Text);

            DPL = DPL.Replace("[Barcode1]", txtrackNo.Text);
            DPL = DPL.Replace("[Item1]", "");
            DPL = DPL.Replace("[MRP1]", "");
            DPL = DPL.Replace("[Barcode2]", txtrackNo.Text);
            DPL = DPL.Replace("[Item2]", "");
            DPL = DPL.Replace("[MRP2]", "");
            DPL = DPL.Replace("[Barcode3]", txtrackNo.Text);
            DPL = DPL.Replace("[Item3]", "");
            DPL = DPL.Replace("[MRP3]", "");
            dllbuild.RawPrinterHelper.SendStringToPrinter( DefaultPrinterName(), DPL);
        }
        private String DefaultPrinterName()
        {
            System.Drawing.Printing.PrinterSettings oPS = new System.Drawing.Printing.PrinterSettings();

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
    }

}

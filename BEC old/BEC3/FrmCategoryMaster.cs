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
    public partial class FrmCategoryMaster : Form
    {
        public FrmCategoryMaster()
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
            txtcatname.Text="";
            sav = "save";
            c1DockingTab1.SelectedIndex = 1;
            txtcatname.Focus();
        }
        private void FrmSuppMast_Load(object sender, EventArgs e)
        {
            clear();
        }
        public void GridFill()
        {
            dtdgv = objbll.gridfill(6);
            DgvProduct.DataSource = dtdgv;
            dtid = objbll.gridfill(7);
            try
            {
                txtcatid.Text = dtid.Rows[0][0].ToString();
                if (txtcatid.Text == "")
                {
                    txtcatid.Text = "1";
                }
            }
            catch { txtcatid.Text = "1"; }
            
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (txtcatname.Text == "")
            {
                errorProvider1.SetError(txtcatname, "Enter Category Name");
                txtcatname.Focus();
                return;
            }
            objbll.CategoryName   = txtcatname.Text.Trim ();
            if (sav == "save")
            {
                if (objbll.SavetoDb(8))
                {
                    MessageBox.Show("Data Saved Successfully");
                }
            }
            else
            {
                objbll.CatId = Convert.ToInt32(txtcatid.Text);
                if (objbll.SavetoDb(9))
                {
                    MessageBox.Show("Data Updated Successfully");
                }
            }
            clear();
        }

        private void c1Button4_Click(object sender, EventArgs e)
        {
            GridFill();
            txtcatname.Text = "";
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
                    objbll.CatId = Convert.ToInt32(txtcatid.Text);
                    if (objbll.SavetoDb(10))
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
            txtcatname.Focus();
        }

        private void DgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvProduct.Rows.Count > 0)
            {
                int i;
                i = DgvProduct .SelectedCells[0].RowIndex;
                txtcatid.Text = DgvProduct.Rows[i].Cells[0].Value.ToString();
                txtcatname .Text = DgvProduct.Rows[i].Cells[1].Value.ToString();
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
            TextToSearch = textBox1 .Text;
             Criteria = FieldName + " Like '" + TextToSearch.ToUpper().Trim() + "%'";
            
            objDv = new DataView(dtdgv , Criteria, "", DataViewRowState.OriginalRows);
            DgvProduct .DataSource = objDv.ToTable();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search("Category_Name");
        }
    }
}

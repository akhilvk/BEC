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
        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
          
        }

        private void c1DockingTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
            objbll.RackNo  = txtrackNo.Text.Trim ();
            if (objbll.SavetoDb(3))
            {
                MessageBox.Show("Data Saved Successfully");
            }
            GridFill();
            txtrackNo.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void c1Button4_Click(object sender, EventArgs e)
        {
            GridFill();
            txtrackNo.Text = "";
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
          
        }

        private void c1DockingTabPage1_Click(object sender, EventArgs e)
        {
            GridFill();
            txtrackNo.Focus();
        }
    }
}

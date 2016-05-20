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
    public partial class FrmItemMast : Form
    {
        public FrmItemMast()
        {
            InitializeComponent();
        }
        ClsBllRack objbll = new ClsBllRack();
        public void catLoad()
        {
            DataTable dt = new DataTable();
            dt = objbll.gridfill(6);
            cmbcat.DataSource = dt;
            cmbcat.DisplayMember = "Category_Name";
            cmbcat.ValueMember = "Category_Id";
            cmbcat.SelectedValue = 0;
        }
        private void FrmItemMast_Load(object sender, EventArgs e)
        {
            c1DockingTab1.SelectedIndex = 0;
            BALItem baobj = new BALItem();
            
            DataTable da = new DataTable();
            da.Load(baobj.ItemSelect());
            if (da.Rows.Count != 0)
            {
                ListView1.Items.Clear();
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = da.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr[0].ToString());
                    listitem.SubItems.Add(dr[1].ToString());
                    listitem.SubItems.Add(dr[2].ToString());
                    listitem.SubItems.Add(dr[3].ToString());
                    //listitem.SubItems.Add(dr[6].ToString());
                    //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                    ListView1.Items.Add(listitem);
                }
            }
            catLoad();
            SendKeys.Send("\t");
            textBox2.Tag = "";
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            BALItem baobj = new BALItem();
            BELItem beobj = new BELItem();
            beobj._id = ListView1.SelectedItems[0].SubItems[0].Text.ToString();
            DataTable da = new DataTable();
            da.Load(baobj.ItemSuniqSelect(beobj));
            if (da.Rows.Count != 0)
            {
                c1DockingTab1.SelectedIndex = 1;
                DataRow dr = da.Rows[0];
                textBox2.Tag = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                txtnoofpacks.Text = dr["NoofPacks"].ToString();
                cmbcat.SelectedValue = dr["CatId"].ToString();
                if (dr[4].ToString() == "0") { checkBox1.Checked = false; } else { checkBox1.Checked = true; }
            }
        }

        private void c1DockingTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1DockingTab1.SelectedIndex == 0)
            {
                ListView1.Items.Clear();
                BALItem baobj = new BALItem();
                DataTable da = new DataTable();
                da.Load(baobj.ItemSelect());
                if (da.Rows.Count != 0)
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[2].ToString());
                        listitem.SubItems.Add(dr[3].ToString());
                        //listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
                textBox1.Focus();
            }
            else { if (textBox2.Text == "") { SendKeys.Send("\t"); } else { c1Button1.Focus(); } }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                BALItem baobj = new BALItem();
                BELItem beobj = new BELItem();
                beobj._Itemname = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.ItemSTypeSelect(beobj));
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[2].ToString());
                        listitem.SubItems.Add(dr[3].ToString());
                        //listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
            }
            else
            {
                BALItem baobj = new BALItem();
                BELItem beobj = new BELItem();
                beobj._Itemname = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.ItemSelect());
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[2].ToString());
                        listitem.SubItems.Add(dr[3].ToString());
                        //listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }

            }
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BALItem baobj = new BALItem();
            BELItem beobj = new BELItem();
            beobj._id = textBox2.Tag.ToString();
            beobj._Itemname = textBox2.Text;
            beobj._ItemCode = textBox3.Text;
            beobj._Mrp = textBox4.Text;
            beobj._Expiry = checkBox1.Checked ? 1 : 0;
            if (txtnoofpacks.Text == "")
            {
                beobj.NoofPacks = 0;
            }
            else
                beobj.NoofPacks = Convert.ToInt32(txtnoofpacks.Text);

            beobj.catid =Convert.ToInt32( cmbcat.SelectedValue);

            DataTable da = new DataTable();
            da.Load(baobj.ItemSTypeSelect(beobj));

            if (da.Rows.Count > 0)
            {
                if (textBox2.Tag != "")
                {

                    goto Update;
                }
                else
                {
                    MessageBox.Show("Duplicate ItemName!! Failed To Save");
                }
            }
            else
            {
                if (textBox2.Tag != "")
                { goto Update; }

                if (baobj.ItemSinsert(beobj) == true)
                {
                    MessageBox.Show("Saved Successfully!");
                    foreach (Control c in panel1.Controls)
                    {

                        if (c.GetType().FullName.ToString() == "System.Windows.Forms.TextBox")
                        {

                            c.Text = "";
                            c.Tag = "";

                        }

                    }
                    textBox1.Text = "";
                    c1DockingTab1.SelectedIndex = 0;
                    return;
                }
            }
        Update:
            if (baobj.ItemSupdate(beobj) == true)
            {
                MessageBox.Show("Updated Successfully!");
                foreach (Control c in panel1.Controls)
                {

                    if (c.GetType().FullName.ToString() == "System.Windows.Forms.TextBox")
                    {

                        c.Text = "";
                        c.Tag = "";

                    }

                }
                textBox1.Text = "";
                c1DockingTab1.SelectedIndex = 0;
            }
            
        }

        private void c1Button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Unsaved Changes Will be Lost!Continue?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (Control c in panel1.Controls)
                {

                    if (c.GetType().FullName.ToString() == "System.Windows.Forms.TextBox")
                    {

                        c.Text = "";
                        c.Tag = "";

                    }

                }
                textBox1.Text = "";
                catLoad();
            }
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {

            BALItem baobj = new BALItem();
            BELItem beobj = new BELItem();
            beobj._id = Convert.ToString(textBox2.Tag);
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (baobj.ItemSDelete(beobj) == true)
                {
                    MessageBox.Show("Item Deleted");
                    c1DockingTab1.SelectedIndex = 0;
                    foreach (Control c in panel1.Controls)
                    {

                        if (c.GetType().FullName.ToString() == "System.Windows.Forms.TextBox")
                        {

                            c.Text = "";
                            c.Tag = "";

                        }

                    }
                    textBox1.Text = "";
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            double value;

            if (double.TryParse(textBox4.Text, out value))
            {
                textBox4.Text = String.Format("{0:0,0.00}", value);
            }
            else
            {
                // Some code to handle the bad input (not parsable to double)
            }
        }
    }
}

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
    public partial class FrmCustMast : Form
    {
        public FrmCustMast()
        {
            InitializeComponent();
        }

        private void FrmCustMast_Load(object sender, EventArgs e)
        {
            
            c1DockingTab1.SelectedIndex = 0;
            BAL baobj = new BAL();
            DataTable da = new DataTable();
            da.Load(baobj.custSelect());
            if (da.Rows.Count != 0)
            {
                ListView1.Items.Clear();
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = da.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr[0].ToString());
                    listitem.SubItems.Add(dr[1].ToString());
                    listitem.SubItems.Add(dr[4].ToString());
                    listitem.SubItems.Add(dr[5].ToString());
                    listitem.SubItems.Add(dr[6].ToString());
                    //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                    ListView1.Items.Add(listitem);
                } 
            }
            SendKeys.Send("\t");
            textBox2.Tag = "";
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            BAL baobj = new BAL();
            BEL beobj = new BEL();
            beobj._id = ListView1.SelectedItems[0].SubItems[0].Text.ToString();
            DataTable da = new DataTable();
            da.Load(baobj.custuniqSelect(beobj));
            if (da.Rows.Count != 0)
            {
                c1DockingTab1.SelectedIndex = 1;
                 DataRow dr = da.Rows[0];
                 textBox2.Tag = dr[0].ToString();
                 textBox2.Text = dr[1].ToString();
                 textBox4.Text = dr[2].ToString();
                 textBox5.Text = dr[3].ToString();
                 textBox6.Text = dr[4].ToString();
                 textBox3.Text = dr[5].ToString();
                 textBox7.Text = dr[6].ToString();
            }
        }

        private void c1DockingTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1DockingTab1.SelectedIndex == 0)
            {
                ListView1.Items.Clear();
                BAL baobj = new BAL();
                DataTable da = new DataTable();
                da.Load(baobj.custSelect());
                if (da.Rows.Count != 0)
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[4].ToString());
                        listitem.SubItems.Add(dr[5].ToString());
                        listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
                textBox1.Focus();
            }
            else { if (textBox2.Text == "") { SendKeys.Send("\t"); } else { c1Button1.Focus(); } }
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BAL baobj = new BAL();
            BEL beobj = new BEL();
            beobj._id = textBox2.Tag.ToString();
            beobj._name = textBox2.Text;
            beobj._add1 = textBox4.Text;
            beobj._add2 = textBox5.Text;
            beobj._add3 = textBox6.Text;
            beobj._phone = textBox3.Text;
            beobj._email = textBox7.Text;
            DataTable da = new DataTable();
            da.Load(baobj.custTypeSelect(beobj));

            if (da.Rows.Count > 0)
            {
                if (textBox2.Tag != "")
                {

                    goto Update;
                }
                else
                {
                    MessageBox.Show("Duplicate CustomerName!! Failed To Save");
                }
            }
            else {
                if (textBox2.Tag != "")
                { goto Update; }
            
                if (baobj.custinsert(beobj) == true)
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
                    c1DockingTab1.SelectedIndex = 0;
                    return;
                }
            }
 Update:
            if (baobj.custupdate(beobj) == true)
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
                c1DockingTab1.SelectedIndex = 0;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                BAL baobj = new BAL();
                BEL beobj = new BEL();
                beobj._name = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.custTypeSelect(beobj));
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[4].ToString());
                        listitem.SubItems.Add(dr[5].ToString());
                        listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
            }
            else
            {
                BAL baobj = new BAL();
                BEL beobj = new BEL();
                beobj._name = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.custSelect());
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        listitem.SubItems.Add(dr[4].ToString());
                        listitem.SubItems.Add(dr[5].ToString());
                        listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
 
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

            }
          
        }

        private void c1Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
            BAL baobj = new BAL();
            BEL beobj = new BEL();
            beobj._id = Convert.ToString(textBox2.Tag);
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (baobj.custDelete(beobj) == true)
                {
                    MessageBox.Show("Customer Deleted");
                    c1DockingTab1.SelectedIndex = 0;
                    foreach (Control c in panel1.Controls)
                    {

                        if (c.GetType().FullName.ToString() == "System.Windows.Forms.TextBox")
                        {

                            c.Text = "";
                            c.Tag = "";

                        }

                    }
                }
            }
        }
    }
}

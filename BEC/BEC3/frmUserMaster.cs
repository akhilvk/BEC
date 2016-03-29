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
    public partial class frmUserMaster : Form
    {
        public frmUserMaster()
        {
            InitializeComponent();
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            c1DockingTab1.SelectedIndex = 0;
            BALUser baobj = new BALUser();
            DataTable da = new DataTable();
            da.Load(baobj.UserSelect());
            if (da.Rows.Count != 0)
            {
                ListView1.Items.Clear();
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = da.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr[0].ToString());
                    listitem.SubItems.Add(dr[1].ToString());
                  
                    //listitem.SubItems.Add(dr[6].ToString());
                    //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                    ListView1.Items.Add(listitem);
                }
            }
            SendKeys.Send("\t");
            textBox2.Tag = "";
        }

        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            BALUser baobj = new BALUser();
            BELUser beobj = new BELUser();
            beobj._id = Convert.ToString(ListView1.SelectedItems[0].SubItems[0].Text);
            DataTable da = new DataTable();
            da.Load(baobj.UseruniqSelect(beobj));
            if (da.Rows.Count != 0)
            {
                c1DockingTab1.SelectedIndex = 1;
                DataRow dr = da.Rows[0];
                textBox2.Tag = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                              
            }
        }

        private void c1DockingTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1DockingTab1.SelectedIndex == 0)
            {
                ListView1.Items.Clear();
                BALUser baobj = new BALUser();
                DataTable da = new DataTable();
                da.Load(baobj.UserSelect());
                if (da.Rows.Count != 0)
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                      
                       
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
                BALUser baobj = new BALUser();
                BELUser beobj = new BELUser();
                beobj._name = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.UserTypeSelect(beobj));
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                       
                        //listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }
            }
            else
            {
                BALUser baobj = new BALUser();
                BELUser beobj = new BELUser();
                beobj._name = textBox1.Text;
                DataTable da = new DataTable();
                da.Load(baobj.UserSelect());
                if (da.Rows.Count != 0)
                    ListView1.Items.Clear();
                {
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        DataRow dr = da.Rows[i];
                        ListViewItem listitem = new ListViewItem(dr[0].ToString());
                        listitem.SubItems.Add(dr[1].ToString());
                        
                        //listitem.SubItems.Add(dr[6].ToString());
                        //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                        ListView1.Items.Add(listitem);
                    }
                }

            }
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            BALUser baobj = new BALUser();
            BELUser beobj = new BELUser();
            beobj._id = textBox2.Tag.ToString();
            beobj._name = textBox2.Text;
            beobj._pwd = textBox3.Text;

            DataTable da = new DataTable();
            da.Load(baobj.UserTypeSelect(beobj));

            if (da.Rows.Count > 0)
            {
                if (textBox2.Tag != "")
                {

                    goto Update;
                }
                else
                {
                    MessageBox.Show("Duplicate UserName!! Failed To Save");
                }
            }
            else
            {
                if (textBox2.Tag != "")
                { goto Update; }

                if (baobj.UserInsert(beobj) == true)
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
            if (baobj.Userupdate(beobj) == true)
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

            BALUser baobj = new BALUser();
            BELUser beobj = new BELUser();
            beobj._id = textBox2.Tag.ToString();
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (baobj.UserDelete(beobj) == true)
                {
                    MessageBox.Show("User Deleted");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.PasswordChar = '\0';

            }
            else { textBox3.PasswordChar = Convert.ToChar("*");  }
        }
    }
}

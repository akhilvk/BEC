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

namespace BEC3
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                c1Button1.PerformClick();
            }
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "")
            {
                BELLogin beobj = new BELLogin();
                BALLogin baobj = new BALLogin();
                beobj._name = textBox1.Text;
                beobj._pwd = textBox2.Text;
                if (baobj.checklogin(beobj) == true)
                {
                    this.Hide();
                    var myform = new FrmMain();
                    myform.Show();
                    myform.ribbonLabel1.Text = beobj._name;
                    
                }
                else
                {
                    MessageBox.Show("Invalid Login Credentials");
                }
            }
            else  
            {
                MessageBox.Show("UserName or Password Field Empty");
            }
        }

        private void c1Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

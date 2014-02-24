using MainLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = AppDomain.CurrentDomain.FriendlyName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var msg = new MessageLogic();
            msg.ShowMessage();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show(string.Format("{0} FormClosing", AppDomain.CurrentDomain.FriendlyName));
        }
    }
}

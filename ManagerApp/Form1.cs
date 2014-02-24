using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ManagerApp
{
    public partial class Form1 : Form
    {
        private static readonly string MAIN_APP
            = @"..\..\..\MainApp\bin\Debug\MainApp.exe";

        private AppDomain _mainDomain = null;
        private Proxy _mainProxy = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._mainDomain != null)
            {
                return;
            }

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            var info = new AppDomainSetup();
            var asmFile = Path.Combine(Environment.CurrentDirectory, Form1.MAIN_APP);
            info.ApplicationBase = Path.GetDirectoryName(asmFile);
            this._mainDomain = AppDomain.CreateDomain("MainAppDomain", null, info);
            this._mainProxy = (Proxy)this._mainDomain.CreateInstanceAndUnwrap(typeof(Proxy).Assembly.FullName, typeof(Proxy).FullName);
            this._mainProxy.Start(asmFile);

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this._mainDomain == null)
            {
                return;
            }

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            this._mainProxy.Stop();
            AppDomain.Unload(this._mainDomain);
            this._mainProxy = null;
            this._mainDomain = null;

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
        }
    }
}

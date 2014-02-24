using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainApp
{
    [Serializable]
    public sealed class Boot
        : IBoot
    {
        private Form1 _mainForm = null;

        //[STAThread]
        public void Start()
        {            
            this._mainForm = new Form1();
            this._mainForm.Show();
        }

        public void Stop()
        {
            this._mainForm.Close();
        }
    }
}

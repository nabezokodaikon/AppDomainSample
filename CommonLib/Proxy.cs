using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonLib
{
    public sealed class Proxy
        : MarshalByRefObject
    {
        private IBoot _bootInstance = null;

        public Proxy()
        {

        }

        public void Start(string inAssemblyFile)
        {
            if (string.IsNullOrEmpty(inAssemblyFile))
            {
                throw new ArgumentNullException("inAssemblyFile");
            }

            var assembly = Assembly.LoadFile(inAssemblyFile);
            var bootType = assembly.GetTypes().First(i => i.GetInterface(typeof(IBoot).FullName) == typeof(IBoot));
            this._bootInstance = (IBoot)Activator.CreateInstance(bootType);
            this._bootInstance.Start();
        }

        public void Stop()
        {
            this._bootInstance.Stop();
        }
    }
}

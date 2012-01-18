using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;

namespace vPowerModule.Objects
{
    public class VPMViProxy
    {
        private CViProxy proxy;

        #region Properties
        public CViProxy Proxy
        {
            get { return this.proxy; }
            set { this.proxy = value; }
        }
        #endregion

        public VPMViProxy(CViProxy p)
        {
            this.proxy = p;
        }
    }
}

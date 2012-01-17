using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Common;

namespace vPowerModule.Objects
{
    public class VPMOptions
    {
        private CDomContainer _options;

        public CDomContainer Options
        {
            get { return _options; }
            set { _options = value; }
        }

        public VPMOptions(CDomContainer cDomContainer)
        {
            // TODO: Complete member initialization
            this._options = cDomContainer;
        }
    }
}

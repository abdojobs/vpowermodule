using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Model;

namespace vPowerModule.Objects
{
    public class VPMVssOptions
    {
        private CVssOptions _vssOptions;

        public VPMVssOptions(CVssOptions cVssOptions)
        {
            // TODO: Complete member initialization
            this._vssOptions = cVssOptions;
        }
    }
}

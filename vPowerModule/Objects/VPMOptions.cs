﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Common;

namespace vPowerModule.Objects
{
    public class VPMOptions
    {
        private CDomContainer _options;

        public VPMOptions(CDomContainer cDomContainer)
        {
            // TODO: Complete member initialization
            this._options = cDomContainer;
        }
    }
}
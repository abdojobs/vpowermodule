using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Model;

namespace vPowerModule.Objects
{
    public class VPMScheduleOptions
    {
        private ScheduleOptions _schedOptions;

        public ScheduleOptions SchedOptions
        {
            get { return _schedOptions; }
            set { _schedOptions = value; }
        }
        

        public VPMScheduleOptions(ScheduleOptions scheduleOptions)
        {
            // TODO: Complete member initialization
            this._schedOptions = scheduleOptions;
        }
    }
}

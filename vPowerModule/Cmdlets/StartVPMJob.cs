using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;
using vPowerModule;
using System.Reflection;
using Lapointe.PowerShell.MamlGenerator.Attributes;

namespace vPowerModule.Cmdlets
{
    [Cmdlet("Start", "VPMJob")]
    public class StartVPMJob : PSCmdlet
    {
        private vPowerModule.Objects.VPMJob[] _job;
        private SwitchParameter _retry;
        private SwitchParameter _full;
        private SwitchParameter _runAsync;

        #region Parameters        
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public vPowerModule.Objects.VPMJob[] Job
        {
            get { return this._job; }
            set { this._job = value; }            
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter Retry { get { return _retry; } set { _retry = value; } }

        [Parameter(Position = 2, Mandatory = false)]
        public SwitchParameter Full { get { return _full; } set { _full = value; } }

        [Parameter(Position = 3, Mandatory = false)]
        public SwitchParameter RunAsync { get { return _runAsync; } set { _runAsync = value; } }
        #endregion

        protected override void ProcessRecord()
        {
            foreach (vPowerModule.Objects.VPMJob job in this._job)
            {
                this.WriteObject(job.Start((bool)_retry,(bool)_full,(bool)_runAsync), false);
            }
        }
    }
}

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
 
        #endregion

        protected override void ProcessRecord()
        {
            foreach (vPowerModule.Objects.VPMJob job in this._job)
            {
                job.Start();
            }
        }
    }
}

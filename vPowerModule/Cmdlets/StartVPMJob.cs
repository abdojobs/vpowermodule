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
    [CmdletDescription("Starts a VPM Job")]
    [RelatedCmdlets((typeof(CopyVPMJob)))]
    [RelatedCmdlets((typeof(StartVPMJob)))]
    public class StartVPMJob : PSCmdlet
    {
        private vPowerModule.Objects.VPMJob[] _job;
        private SwitchParameter _retry;
        private SwitchParameter _full;

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

        #endregion

        protected override void ProcessRecord()
        {
            foreach (vPowerModule.Objects.VPMJob job in this._job)
            {
                if (_full)
                    job.Start("Full");
                else if (_retry)
                    job.Start("Retry");
                else
                    job.Start("Normal");
            }
        }
    }
}

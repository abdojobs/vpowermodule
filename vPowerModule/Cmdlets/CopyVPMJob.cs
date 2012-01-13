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
    [Cmdlet("Copy","VPMJob")]
    [CmdletDescription("Copies a VPM Job")]
    [RelatedCmdlets((typeof(GetVPMJob)))]
    [RelatedCmdlets((typeof(StartVPMJob)))]
    public class CopyVPMJob : PSCmdlet
    {
        private vPowerModule.Objects.VPMJob _job;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public vPowerModule.Objects.VPMJob Job { set { _job = value; } get { return _job; } }

        protected override void ProcessRecord()
        {
            _job.Clone();
        }
    }
}

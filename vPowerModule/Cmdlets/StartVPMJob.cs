using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;
using vPowerModule;
using System.Reflection;
using Lapointe.PowerShell.MamlGenerator.Attributes;
using vPowerModule.Job;

namespace vPowerModule.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Start, "VPMJob")]
    [CmdletDescription("Starts a VPM Job based off of a single job or an array of jobs.")]
    [Example(Code = "PS C:\\ $Job = Get-VPMJob -name \"Backup Job\"\nPS C:\\ Start-VPMJob $Job", Remarks = "Sets $Job to an existing VPM Job and then starts it.")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"Backup Job\" | Start-VPMJob", Remarks = "Gets a job with the name of \"Backup Job\" and pipes it directly into Start-VPMJob")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"VPM*\" | Start-VPMJob", Remarks = "Gets a list of jobs that start with VPM and pipes it directly into Start-VPMJob")]
    [RelatedCmdlets(new[] {(typeof(StopVPMJob))})]
    //[RelatedCmdlets((typeof(StartVPMJob)))]
    public class StartVPMJob : PSCmdlet
    {
        private VPMJob[] _job;
        private SwitchParameter _retry;
        private SwitchParameter _full;

        #region Parameters        
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public VPMJob[] Job
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
            foreach (VPMJob job in this._job)
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

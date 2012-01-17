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
    [Cmdlet("Stop", "VPMJob")]
    [CmdletDescription("Stops a VPM Job based off of a single job or an array of jobs.")]
    [Example(Code = "PS C:\\ $Job = Get-VPMJob -name \"Backup Job\"\nPS C:\\ Stop-VPMJob $Job", Remarks = "Sets $Job to an existing VPM Job and then Stops it.")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"Backup Job\" | Stop-VPMJob", Remarks = "Gets a job with the name of \"Backup Job\" and pipes it directly into Stop-VPMJob")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"VPM*\" | Stop-VPMJob", Remarks = "Gets a list of jobs that Stop with VPM and pipes it directly into Stop-VPMJob")]
    //[RelatedCmdlets((typeof(CopyVPMJob)))]
    [RelatedCmdlets((typeof(StartVPMJob)))]
    public class StopVPMJob : PSCmdlet
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
                job.Stop();
            }
        }
    }
}

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
    [Cmdlet("Get","VPMJob")] 
    [CmdletDescription("Returns a list of Veeam Jobs")]
    //[RelatedCmdlets((typeof(CopyVPMJob)))]
    [RelatedCmdlets(new[] {(typeof(StartVPMJob))})]
    [Example(Code = "PS C:\\ Get-VPMJob | ?{$_.IsBackup}", Remarks = "Returns a list of jobs that are only Backup jobs.")]
    [Example(Code = "PS C:\\ Get-VPMJob | ?{$_.IsReplica}", Remarks = "Returns a list of jobs that are only Replica jobs.")]
    [Example(Code = "PS C:\\ Get-VPMJob -Name \"Backup Job 1\"", Remarks = "Returns job with name of \"Backup Job 1\"")]
    [Example(Code = "PS C:\\ Get-VPMJob -Name \"VPM*\"", Remarks = "Returns a list of jobs that start with \"VPM\"\n")]
    public class GetVPMJob: PSCmdlet
    {
        private string[] _name;
        [Parameter(Position = 0, Mandatory = false)]
        [SupportsWildcards]
        public string[] Name
        {
            get { return this._name; }
            set { _name = value; }
        }

        protected override void ProcessRecord()
        {
            if (this._name == null)
                this.WriteObject((object)VPMJob.GetAll(), true);
            else
            {

                foreach (string pattern in this._name)
                {
                    if (pattern == null)
                        this.WriteObject((object)VPMJob.GetAll(), true);
                    else
                    {
                        WildcardPattern wildcard = new WildcardPattern(pattern, WildcardOptions.Compiled | WildcardOptions.IgnoreCase);
                        foreach (VPMJob Job in (VPMJob.GetAll()))
                        {
                            if (wildcard.IsMatch(Job.Name))
                                WriteObject((object)Job, true);
                        }
                    }

                }
            }
        }
    }
}

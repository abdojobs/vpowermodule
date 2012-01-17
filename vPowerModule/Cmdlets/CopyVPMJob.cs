using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;
using vPowerModule;
using System.Reflection;
using Lapointe.PowerShell.MamlGenerator.Attributes;
using Veeam.Backup.Model;
using Veeam.Backup.DBManager;

namespace vPowerModule.Cmdlets
{
    [Cmdlet("Copy","VPMJob")]
    [CmdletDescription("Copies a VPM Job")]
    [Example(Code = "PS C:\\ $Job = Get-VPMJob -name \"Backup Job\"\nPS C:\\ Copy-VPMJob $Job", Remarks="Sets $Job to an existing VPM Job and copies it to a new instance with _copy appended to the name of the job.")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"Backup Job\" | Copy-VPMJob", Remarks = "Gets job \"Backup Job\" and pipes it directly into Copy-VPMJob")]
    [Example(Code = "PS C:\\ $Job = Get-VPMJob -name \"Backup Job\"\nPS C:\\ Copy-VPMJob $Job -Name \"New Backup Job\"", Remarks = "Sets $Job to an existing VPM Job and copies it to a new instance with the name provided.")]
    [Example(Code = "PS C:\\ Get-VPMJob -name \"Backup Job\" | Copy-VPMJob -Name \"New Backup Job\"", Remarks = "Gets VPM Job \"Backup Job\" and copies it to a new instance with the name provided.")]
    [RelatedCmdlets((typeof(GetVPMJob)))]
    //[RelatedCmdlets((typeof(StartVPMJob)))]
    public class CopyVPMJob : PSCmdlet
    {
        private vPowerModule.Objects.VPMJob _job;
        private string _name;


        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public vPowerModule.Objects.VPMJob Job { set { _job = value; } get { return _job; } }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false)]
        public string Name 
        { 
            get { return _name; } 
            set 
            {
                CDbBackupJobInfo FindJob = CDBManager.Instance.BackupJobs.FindJob(value);
                if (FindJob == null)
                    this._name = value;
                else
                { throw new Exception("Job already exists with that name"); }
            } 
        }

        protected override void ProcessRecord()
        {
            _job.Clone(Name);
        }
    }
}

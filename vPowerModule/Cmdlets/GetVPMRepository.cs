using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Veeam.Backup.Core;

namespace vPowerModule.Cmdlets
{
    [Cmdlet(VerbsCommon.Get,"VPMRepository")]
    public class GetVPMRepository : PSCmdlet
    {


        protected override void ProcessRecord()
        {
            foreach (CBackupRepository repo in CBackupRepository.GetAll())
            {
                this.WriteObject((object)new vPowerModule.Objects.VPMRepository(repo));
            }
        }
    }
}

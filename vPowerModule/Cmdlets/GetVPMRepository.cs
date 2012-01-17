using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Veeam.Backup.Core;
using Lapointe.PowerShell.MamlGenerator.Attributes;

namespace vPowerModule.Cmdlets
{
    [Cmdlet(VerbsCommon.Get,"VPMRepository")]
    [CmdletDescription("Gets all repositories.")]
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

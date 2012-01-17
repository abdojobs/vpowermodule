using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Veeam.Backup.Core;
using Lapointe.PowerShell.MamlGenerator.Attributes;

namespace vPowerModule.Cmdlets
{
    [Cmdlet(VerbsCommon.Get,"VPMViProxy")]
    [CmdletDescription("Gets all VMWare Proxies")]
    public class GetVPMViProxy : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            foreach (CViProxy proxy in CViProxy.GetAll())
            {
                this.WriteObject((object)new vPowerModule.Objects.VPMViProxy(proxy));
            }
        }
    }
}

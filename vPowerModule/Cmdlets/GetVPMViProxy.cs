using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Veeam.Backup.Core;
using Lapointe.PowerShell.MamlGenerator.Attributes;

namespace vPowerModule.Cmdlets
{
    [Cmdlet(VerbsCommon.Get,"ViProxy")]
    [CmdletDescription("Gets all VMWare Proxies")]
    class GetVPMViProxy : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            // Go figure out how to get a proxy.
        }
    }
}

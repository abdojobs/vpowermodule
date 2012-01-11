using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;
using vPowerModule;
using System.Reflection;

namespace vPowerModule.Cmdlets
{
    [Cmdlet("Get","VPMJob")]
    public class GetVPMJob: PSCmdlet
    {
        private string[] _name;
        [Parameter(Position = 0, Mandatory = false)]

        public string[] Name
        {
            get { return this._name; }
            set { _name = value; }
        }

        protected override void ProcessRecord()
        {
            if (this._name == null)
                this.WriteObject((object)vPowerModule.Objects.VPMJob.GetAll(), true);
            else
            {

                foreach (string pattern in this._name)
                {
                    if (pattern == null)
                        this.WriteObject((object)vPowerModule.Objects.VPMJob.GetAll(), true);
                    else
                    {
                        WildcardPattern wildcard = new WildcardPattern(pattern, WildcardOptions.Compiled | WildcardOptions.IgnoreCase);
                        foreach (vPowerModule.Objects.VPMJob Job in (vPowerModule.Objects.VPMJob.GetAll()))
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

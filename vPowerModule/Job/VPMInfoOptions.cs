using Veeam.Backup.Common;

namespace vPowerModule.Job
{
    public class VPMInfoOptions
    {
        private CDomContainer _options;

        public CDomContainer Options
        {
            get { return _options; }
            set { _options = value; }
        }

        public VPMInfoOptions(CDomContainer cDomContainer)
        {
            // TODO: Complete member initialization
            this._options = cDomContainer;
        }
    }
}

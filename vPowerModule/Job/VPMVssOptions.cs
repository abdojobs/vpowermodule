using Veeam.Backup.Model;

namespace vPowerModule.Job
{
    public class VPMVssOptions
    {
        private CVssOptions _vssOptions;

        public CVssOptions VssOptions
        {
            get { return _vssOptions; }
            set { _vssOptions = value; }
        }

        public VPMVssOptions(CVssOptions cVssOptions)
        {
            // TODO: Complete member initialization
            this._vssOptions = cVssOptions;
        }
    }
}

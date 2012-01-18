using Veeam.Backup.Model;

namespace vPowerModule.Job.Options
{
    public class VPMVssOptions
    {
        private CVssOptions _vssOptions;

        public CVssOptions cVssOptions
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

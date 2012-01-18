using Veeam.Backup.Model;

namespace vPowerModule.Job.Options
{
    public class ScheduleOptions
    {
        private Veeam.Backup.Model.ScheduleOptions _schedOptions;

        public Veeam.Backup.Model.ScheduleOptions SchedOptions
        {
            get { return _schedOptions; }
            set { _schedOptions = value; }
        }
        

        public ScheduleOptions(Veeam.Backup.Model.ScheduleOptions scheduleOptions)
        {
            // TODO: Complete member initialization
            this._schedOptions = scheduleOptions;
        }
    }
}

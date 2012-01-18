using Veeam.Backup.Common;
using Veeam.Backup.Model;

namespace vPowerModule.Job
{
    public class JobOptions
    {
        private CJobOptions _jobOptions;
        private CDomBackupStorageOptions _backupStorageOptions;
        private CDomBackupTargetOptions _backupTargetOptions;
        private CDomJobOptions _domJobOptions;
        private CDomHvNetworkMappingOptions _hvNetworkMappingOptions;
        private CDomHvReplicaTargetOptions _hvReplicaTargetOptions;
        private CDomHvSourceOptions _hvSourceOptions;
        private CDomNotificationOptions _notificationOptions;
        private CDomPostJobCommand _postJobCommand;
        private CDomReIPRulesOptions _reIpRulesOptions;
        private CDomViNetworkMappingOptions _viNetworkMappingOptions;
        private CDomViReplicaTargetOptions _viReplicaTargetOptions;
        private CDomViSourceOptions _viSourceOptions;
        private CDomContainer _options;

        public JobOptions(CJobOptions options)
        {
            this.vOptions = options;
        }

        public CDomBackupStorageOptions BackupStorageOptions
        {
            get { return vOptions.BackupStorageOptions; }
            set { _backupStorageOptions = value; }
        }

        public CDomBackupTargetOptions BackupTargetOptions
        {
            get { return vOptions.BackupTargetOptions; }
            set { _backupTargetOptions = value; }
        }

        public CDomHvSourceOptions HvSourceOptions
        {
            get { return vOptions.HvSourceOptions; }
            set { _hvSourceOptions = value; }
        }

        public CDomJobOptions DomJobOptions
        {
            get { return vOptions.JobOptions; }
            set { _domJobOptions = value; }
        }

        public CDomViNetworkMappingOptions ViNetworkMappingOptions
        {
            get { return vOptions.ViNetworkMappingOptions; }
            set { _viNetworkMappingOptions = value; }
        }

        public CDomHvNetworkMappingOptions HvNetworkMappingOptions
        {
            get { return vOptions.HvNetworkMappingOptions; }
            set { _hvNetworkMappingOptions = value; }
        }

        public CDomNotificationOptions NotificationOptions
        {
            get { return vOptions.NotificationOptions; }
            set { _notificationOptions = value; }
        }

        public CDomPostJobCommand PostJobCommand
        {
            get { return vOptions.PostJobCommand; }
            set { _postJobCommand = value; }
        }

        public CDomViReplicaTargetOptions ViReplicaTargetOptions
        {
            get { return vOptions.ViReplicaTargetOptions; }
            set { _viReplicaTargetOptions = value; }
        }

        public CDomViSourceOptions ViSourceOptions
        {
            get { return vOptions.ViSourceOptions; }
            set { _viSourceOptions = value; }
        }

        public CDomHvReplicaTargetOptions HvReplicaTargetOptions
        {
            get { return vOptions.HvReplicaTargetOptions; }
            set { _hvReplicaTargetOptions = value; }
        }

        public CDomReIPRulesOptions ReIPRulesOptions
        {
            get { return vOptions.ReIPRulesOptions; }
            set { _reIpRulesOptions = value; }
        }

        internal CJobOptions vOptions
        {
            get { return this._jobOptions; }
            set { this._jobOptions = value; }
        }

        public CDomContainer Options
        {
            get { return vOptions.Options; }
            set { _options = value; }
        }
    }
}
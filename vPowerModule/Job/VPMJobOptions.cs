using Veeam.Backup.Model;

namespace vPowerModule.Job
{
    public class VPMJobOptions
    {
        private CDomBackupStorageOptions _backupStorageOptions;
        private CDomBackupTargetOptions _backupTargetOptions;
        private CDomJobOptions _domJobOptions;
        private CDomHvNetworkMappingOptions _hvNetworkMappingOptions;
        private CDomHvReplicaTargetOptions _hvReplicaTargetOptions;
        private CDomHvSourceOptions _hvSourceOptions;
        private CDomNotificationOptions _notificationOptions;
        private VPMJobOptions _options;
        private CDomPostJobCommand _postJobCommand;
        private CDomReIPRulesOptions _reIpRulesOptions;
        private CDomViNetworkMappingOptions _viNetworkMappingOptions;
        private CDomViReplicaTargetOptions _viReplicaTargetOptions;
        private CDomViSourceOptions _viSourceOptions;

        public CDomBackupStorageOptions BackupStorageOptions
        {
            get { return JobOptions.BackupStorageOptions; }
            set { _backupStorageOptions = value; }
        }

        public CDomBackupTargetOptions BackupTargetOptions
        {
            get { return JobOptions.BackupTargetOptions; }
            set { _backupTargetOptions = value; }
        }

        public CDomHvSourceOptions HvSourceOptions
        {
            get { return JobOptions.HvSourceOptions; }
            set { _hvSourceOptions = value; }
        }

        public CDomJobOptions DomJobOptions
        {
            get { return JobOptions.JobOptions; }
            set { _domJobOptions = value; }
        }

        public CDomViNetworkMappingOptions ViNetworkMappingOptions
        {
            get { return JobOptions.ViNetworkMappingOptions; }
            set { _viNetworkMappingOptions = value; }
        }

        public CDomHvNetworkMappingOptions HvNetworkMappingOptions
        {
            get { return JobOptions.HvNetworkMappingOptions; }
            set { _hvNetworkMappingOptions = value; }
        }

        public CDomNotificationOptions NotificationOptions
        {
            get { return JobOptions.NotificationOptions; }
            set { _notificationOptions = value; }
        }

        public CDomPostJobCommand PostJobCommand
        {
            get { return JobOptions.PostJobCommand; }
            set { _postJobCommand = value; }
        }

        public CDomViReplicaTargetOptions ViReplicaTargetOptions
        {
            get { return JobOptions.ViReplicaTargetOptions; }
            set { _viReplicaTargetOptions = value; }
        }

        public CDomViSourceOptions ViSourceOptions
        {
            get { return JobOptions.ViSourceOptions; }
            set { _viSourceOptions = value; }
        }

        public CDomHvReplicaTargetOptions HvReplicaTargetOptions
        {
            get { return JobOptions.HvReplicaTargetOptions; }
            set { _hvReplicaTargetOptions = value; }
        }

        public CDomReIPRulesOptions ReIPRulesOptions
        {
            get { return JobOptions.ReIPRulesOptions; }
            set { _reIpRulesOptions = value; }
        }

        public CJobOptions JobOptions { get; set; }
    }
}
using Veeam.Backup.Model;

namespace vPowerModule.Objects
{
    public class VPMJobOptions
    {
        private CJobOptions _jobOptions;
        private VPMJobOptions _options;
        private CDomHvReplicaTargetOptions _hvReplicaTargetOptions;
        private CDomReIPRulesOptions _reIpRulesOptions;

        private CDomBackupStorageOptions _backupStorageOptions;

        public CDomBackupStorageOptions BackupStorageOptions
        {
            get { return _backupStorageOptions; }
            set { _backupStorageOptions = value; }
        }

        public CDomBackupTargetOptions BackupTargetOptions { get; set; }

        private CDomHvSourceOptions _hvSourceOptions;

        public CDomHvSourceOptions HvSourceOptions
        {
            get { return _hvSourceOptions; }
            set { _hvSourceOptions = value; }
        }
        private CDomJobOptions _domJobOptions;

        public CDomJobOptions DomJobOptions
        {
            get { return _domJobOptions; }
            set { _domJobOptions = value; }
        }
        private CDomViNetworkMappingOptions _viNetworkMappingOptions;

        public CDomViNetworkMappingOptions ViNetworkMappingOptions
        {
            get { return _viNetworkMappingOptions; }
            set { _viNetworkMappingOptions = value; }
        }
        private CDomHvNetworkMappingOptions _hvNetworkMappingOptions;

        public CDomHvNetworkMappingOptions HvNetworkMappingOptions
        {
            get { return _hvNetworkMappingOptions; }
            set { _hvNetworkMappingOptions = value; }
        }
        private CDomNotificationOptions _notificationOptions;

        public CDomNotificationOptions NotificationOptions
        {
            get { return _notificationOptions; }
            set { _notificationOptions = value; }
        }
        private CDomPostJobCommand _postJobCommand;

        public CDomPostJobCommand PostJobCommand
        {
            get { return _postJobCommand; }
            set { _postJobCommand = value; }
        }
        private CDomViReplicaTargetOptions _viReplicaTargetOptions;

        public CDomViReplicaTargetOptions ViReplicaTargetOptions
        {
            get { return _viReplicaTargetOptions; }
            set { _viReplicaTargetOptions = value; }
        }
        private CDomViSourceOptions _viSourceOptions;

        public CDomViSourceOptions ViSourceOptions
        {
            get { return _viSourceOptions; }
            set { _viSourceOptions = value; }
        }

        public CDomHvReplicaTargetOptions HvReplicaTargetOptions
        {
            get { return _hvReplicaTargetOptions; }
            set { _hvReplicaTargetOptions = value; }
        }
        public CDomReIPRulesOptions ReIPRulesOptions
        {
            get { return _reIpRulesOptions; }
            set { _reIpRulesOptions = value; }
        }
    }
}

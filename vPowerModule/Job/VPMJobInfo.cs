using System;
using Veeam.Backup.Common;
using Veeam.Backup.DBManager;
using Veeam.Backup.Model;
using vPowerModule.Job.Options;
using vPowerModule.Objects;

namespace vPowerModule.Job
{
    public class VPMJobInfo
    {
        #region Private Properties

        private readonly CDbBackupJobInfo _info;
        private readonly VPMInfoOptions _options;
        private readonly VPMScheduleOptions _schedOptions;
        private readonly VPMVssOptions _vssOptions;
        private string _description;
        private string _name;
        private int _postRunCount = -999; // Setting this to a ridiculous number for evaluation later
        private string _targetDir;
        private Guid _targetHostId = Guid.Empty;
        private Guid _targetRepoId = Guid.Empty;

        #endregion

        #region Public Properties

        public Guid Id
        {
            get { return Info.Id; }
        }

        // If you ever need a reason to set this...You can write a SQL query...
        public string Name
        {
            get
            {
                if (_name == null)
                    return Info.Name;
                else
                    return _name;
            }
            set
            {
                CDbBackupJobInfo Job = CDBManager.Instance.BackupJobs.FindJob(value);
                if (Job == null)
                    _name = value;
                else
                {
                    throw new Exception("Job already exists with that name");
                }
            }
        }

        public string Description
        {
            get
            {
                if (_description == null)
                    return Info.Description;
                else
                    return _description;
            }
            set { _description = value; }
        }

        public EDbJobType JobType
        {
            get { return Info.JobType; }
        }

        public Guid VcbHostId
        {
            get { return Info.VcbHostId; }
        }

        public string TargetDir
        {
            get
            {
                if (_targetDir == null)
                    return Info.TargetDir;
                else
                    return _targetDir;
            }
            set { throw new Exception("Please use ChangeRepository() on the job object to set this value."); }
        }

        public Guid TargetHostId // Still needs some error checking and verified
        {
            get
            {
                if (_targetHostId.Equals(Guid.Empty))
                    return Info.TargetHostId;
                else
                    return _targetHostId;
            }
            set { throw new Exception("Please use ChangeRepository() on the job object to set this value."); }
        }

        public Guid TargetRepositoryId
        {
            get
            {
                if (_targetRepoId.Equals(Guid.Empty))
                    return Info.TargetRepositoryId;
                else
                    return _targetRepoId;
            }
            set { throw new Exception("Please use ChangeRepository() on the job object to set this value."); }
        }

        // This should never be set, instead, you set the Repository which then in turn sets this field
        public string TargetFile
        {
            get { return Info.TargetFile; }
        }

        // Don't really need to set this atm, would be a cool feature to change the file names after a job has been created
        public VPMInfoOptions Options
        {
            get { return _options; }
        }

        // Will need to create a VPMOptions
        public VPMScheduleOptions ScheduleOptions
        {
            get { return _schedOptions; }
        }

        // Need to create VPMScheduleOptions
        public VPMVssOptions VssOptions
        {
            get { return _vssOptions; }
        }

        // Need to create VPMVssOptions
        public int PostCommandRunCount
        {
            get
            {
                if (_postRunCount == -999)
                    return Info.PostCommandRunCount;
                else
                    return _postRunCount;
            }
            set { _postRunCount = value; }
        }

        // Not fully sure what this does, will have to verify
        public CDbBackupJobInfo.ESourceType SourceType
        {
            get { return Info.SourceType; }
        }

        // This should probably never be touched. NET/VCB/VDDK/Files/HyperV/Backup
        public CDbBackupJobInfo.ETargetType TargetType
        {
            get { return Info.TargetType; }
        }

        // This should also never be touched probably. Other/NfcTarget/SnapReplica. Looks like v5/v6 job stuff and other for backups/other?
        public long IncludedSize
        {
            get { return Info.IncludedSize; }
        }

        public long ExcludedSize
        {
            get { return Info.ExcludedSize; }
        }

        internal bool IsDeleted
        {
            get { return Info.IsDeleted; }
        }

        internal CBaseSessionInfo.EResult LatestStatus
        {
            get { return Info.LatestStatus; }
        }

        // Reporting data, you would never set this
        public bool IsScheduleEnabled
        {
            get { return Info.IsScheduleEnabled; }
        }

        // May want to set this to false to turn off scheduling? Makes the most sense
        public EPlatform BackupPlatform
        {
            get { return Info.BackupPlatform; }
        }

        // Vmware/Hyper V, you would probably never set this

        public Guid InitialRepositoryId
        {
            get { return Info.InitialRepositoryId; }
        }

        // Probably staying a get for reporting?

        #endregion

        #region Internal Properties

        internal CDbBackupJobInfo Info{ get { return _info; } }

        internal bool IsBackup()
        {
            if (Info.JobType == EDbJobType.Backup)
                return true;
            else
                return false;
        }

        internal bool IsReplica()
        {
            if (Info.JobType == EDbJobType.Replica)
                return true;
            else
                return false;
        }

        internal bool IsCopy()
        {
            if (Info.JobType == EDbJobType.Copy)
                return true;
            else
                return false;
        }
        #endregion

        public VPMJobInfo(CDbBackupJobInfo Info)
        {
            _info = Info;
            _options = new VPMInfoOptions(Info.Options);
            _schedOptions = new VPMScheduleOptions(Info.ScheduleOptions);
            _vssOptions = new VPMVssOptions(Info.VssOptions);
        }

        internal void ChangeRepository(VPMRepository repository)
        {
            _targetDir = repository.Path;
            _targetRepoId = repository.Id;
            _targetHostId = repository.MountHostId;
        }
    }
}
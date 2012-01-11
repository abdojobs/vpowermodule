using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.DBManager;
using Veeam.Backup.Model;
using Veeam.Backup.Common;

namespace vPowerModule.Objects
{
    public class VPMJobInfo
    {
        private CDbBackupJobInfo _info;
        //private CDomContainer _options;
        //private ScheduleOptions _schedOptions;
        //private CVssOptions _vssOptions;
        private string _name;
        private string _description;
        private string _targetDir = null;
        private int _postRunCount = -999; // Setting this to a ridiculous number for evaluation later

        public Guid Id { get { return this.Info.Id; } } // If you ever need a reason to set this...You can write a SQL query...
        public string Name
        {
            get 
            {
                if (_name == null)
                    return this.Info.Name;
                else
                    return this._name;
            }
            set 
            {
                CDbBackupJobInfo Job = CDBManager.Instance.BackupJobs.FindJob(value);
                if (Job == null)
                    this._name = value;
                else
                { /* fuck off?*/  }
            }
        }
        public string Description
        {
            get 
            {
                if (_description == null)
                    return this.Info.Description;
                else
                    return this._description;
            }
            set 
            { 
                _description = value; 
            }
        }
        public EDbJobType JobType
        {
            get { return this._info.JobType; }
        }
        public Guid TargetHostId
        {
            get { return this.Info.TargetHostId; } 
        } // May need to set this on a replication job
        public Guid VcbHostId
        {
            get { return this.Info.VcbHostId; }
        } // Not sure if I will ever have to set this currently
        public string TargetDir 
        {
            get 
            { 
                if(_targetDir == null)
                    return this.Info.TargetDir; 
                else
                    return this._targetDir; 
            } 
        } // This should never be set, instead, you set the Repository which then in turn sets this field
        public string TargetFile
        {
            get { return this.Info.TargetFile; }
        } // Don't really need to set this atm, would be a cool feature to change the file names after a job has been created
        public CDomContainer Options
        {
            get { return this.Info.Options; }
        } // Will need to create a VPMOptions
        public ScheduleOptions ScheduleOptions
        {
            get { return this.Info.ScheduleOptions; }
        } // Need to create VPMScheduleOptions
        public CVssOptions VssOptions
        {
            get { return this.Info.VssOptions; }
        } // Need to create VPMVssOptions
        public int PostCommandRunCount
        {
            get
            {
                if (_postRunCount == -999)
                    return this.Info.PostCommandRunCount;
                else
                    return this._postRunCount;
            }
            set { _postRunCount = value; } 
        } // Not fully sure what this does, will have to verify
        public CDbBackupJobInfo.ESourceType SourceType
        {
            get{ return this.Info.SourceType; }
        } // This should probably never be touched. NET/VCB/VDDK/Files/HyperV/Backup
        public CDbBackupJobInfo.ETargetType TargetType
        {
            get { return this.Info.TargetType; }
        } // This should also never be toucehd probably. Other/NfcTarget/SnapReplica. Looks like v5/v6 job stuff and other for backups/other?
        public long IncludedSize
        {
            get { return this.Info.IncludedSize; }
        } // No reason to set this data
        public long ExcludedSize
        {
            get { return this.Info.ExcludedSize; }
        } // No reason to set this data
        public bool IsDeleted
        {
            get { return this.Info.IsDeleted; }
        } // Why the shit would you set this, what would that even do??
        public CBaseSessionInfo.EResult LatestStatus
        {
            get { return this.Info.LatestStatus; }
        } // Reporting data, you would never set this
        public bool IsScheduleEnabled
        {
            get { return this.Info.IsScheduleEnabled; }
        } // May want to set this to false to turn off scheduling? Makes the most sense
        public EPlatform BackupPlatform
        {
            get { return this.Info.BackupPlatform; }
        } // Vmware/Hyper V, you would probably never set this
        public Guid TargetRepositoryId
        {
            get { return this.Info.TargetRepositoryId; }
        } // Currently a get, will want to add ChangeRepository() method
        public Guid InitialRepositoryId
        {
            get { return this.Info.InitialRepositoryId; }
        } // Probably staying a get for reporting?
        

        internal bool IsBackup()
        {
            if (this.Info.JobType == EDbJobType.Backup)
                return true;
            else
                return false;
        }
        internal bool IsReplica()
        {
            if (this.Info.JobType == EDbJobType.Replica)
                return true;
            else
                return false;
        }
        internal bool IsCopy()
        {
            if (this.Info.JobType == EDbJobType.Copy)
                return true;
            else
                return false;
        }


        internal CDbBackupJobInfo Info
        {
            get
            {
                return this._info;
            }
        }
        public VPMJobInfo(CDbBackupJobInfo Info)
        {
            this._info = Info;
        }

    }
}

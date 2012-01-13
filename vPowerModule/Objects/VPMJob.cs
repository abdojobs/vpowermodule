using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.DBManager;
using Veeam.Backup.Model;
using Veeam.Backup.Core;

namespace vPowerModule.Objects
{
    public class VPMJob
    {
        #region Properties
        private readonly CBackupJob _job;
        private VPMJobInfo _info;

        public string Name
        {
            get { return this._info.Name; }
            set
            {
                CDbBackupJobInfo Job = CDBManager.Instance.BackupJobs.FindJob(value);
                if (Job == null)
                    this._info.Name = value;
                else
                { throw new Exception("Job already exists with that name"); }
            }
        }

        public string Description
        {
            get { return this._info.Description; }
            set { _info.Description = value;  }
        }

        public VPMJobInfo Info
        {
            get 
            {
                return _info; 
            }
            set // I decided to add a set here so you could create a template of baseline info and only change a few things for each job you template
            {
                _info = value;
            }
        }
        public Guid Id { get { return this.Info.Id; } }
        #endregion

        public VPMJob(CBackupJob job)
        {
            this._job = job;
            this._info = new VPMJobInfo(job.Info);
        }

        public static VPMJob[] GetAll()
        {
            var list = CBackupJob.GetAll();
            List<VPMJob> Jobs = new List<VPMJob>();
            foreach( CBackupJob BackupJob in list)
            {
                Jobs.Add(new VPMJob(BackupJob));
            }
            return Jobs.ToArray();
        }

        public bool IsBackup { get { return this.Info.IsBackup(); } }
        public bool IsReplica { get { return this.Info.IsReplica(); } }
        public bool IsCopy { get { return this.Info.IsCopy(); } }

        public void Save()
        {
            CDbBackupJobInfo temp = CDbBackupJobInfo.CreateExisting(
                this.Info.Id,
                this.Info.Name,
                this.Info.Description,
                this.Info.JobType,
                this.Info.TargetHostId,
                this.Info.TargetDir,
                this.Info.TargetFile,
                this.Info.Options.Options,
                this.Info.ScheduleOptions.SchedOptions,
                this.Info.VssOptions.VssOptions,
                this.Info.PostCommandRunCount,
                this.Info.VcbHostId,
                this.Info.SourceType,
                this.Info.TargetType,
                this.Info.IncludedSize,
                this.Info.ExcludedSize,
                this.Info.IsDeleted,
                this.Info.LatestStatus,
                this.Info.IsScheduleEnabled,
                this.Info.BackupPlatform,
                this.Info.TargetRepositoryId,
                this.Info.InitialRepositoryId);
            CDBManager.Instance.BackupJobs.UpdateJob(temp);
        }


        internal void Clone()
        {
            CDbBackupJobInfo temp = CDbBackupJobInfo.CreateNew(
                this.Info.Name + "_copy",
                this.Info.Description,
                this.Info.JobType,
                this.Info.TargetHostId,
                this.Info.TargetDir,
                this.Info.TargetFile,
                this.Info.Options.Options,
                this.Info.ScheduleOptions.SchedOptions,
                this.Info.VssOptions.VssOptions,
                this.Info.PostCommandRunCount,
                this.Info.VcbHostId,
                this.Info.SourceType,
                this.Info.TargetType,
                this.Info.IncludedSize,
                this.Info.ExcludedSize,
                this.Info.BackupPlatform,
                this.Info.TargetRepositoryId,
                this.Info.InitialRepositoryId);
            CDBManager.Instance.BackupJobs.CreateJob(temp);
        }

        internal void Start(string RunType)
        {
            // Create a blank task sesion and set its event to started
            CBackupSession tempSession = CBackupSession.Create(CDbBackupJobInfo.Mode.Full, this._job, true);
            Veeam.Backup.Core.CJobEvent.Create(tempSession.Id, "started");

            System.Diagnostics.ProcessStartInfo jobRun = new System.Diagnostics.ProcessStartInfo();
            jobRun.CreateNoWindow = true;
            jobRun.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            jobRun.FileName = "C:\\Program Files\\Veeam\\Backup and Replication\\Veeam.Backup.Manager.exe";
            jobRun.Arguments = "startbackupjob " + "owner=[vbsvc] " + RunType + " " + this.Id + " " + tempSession.Id;
            System.Diagnostics.Process.Start(jobRun);
        }
    }
}

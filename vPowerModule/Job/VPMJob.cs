using System;
using System.Collections.Generic;
using Veeam.Backup.DBManager;
using Veeam.Backup.Model;
using Veeam.Backup.Core;
using vPowerModule.Job.Options;
using vPowerModule.Objects;

namespace vPowerModule.Job
{
    public class VPMJob
    {
        #region Properties
        private readonly CBackupJob _job;
        private VPMJobInfo _info;
        private string managerExe = "C:\\Program Files\\Veeam\\Backup and Replication\\Veeam.Backup.Manager.exe";
        //private JobOptions _options;

        public Guid Id { get { return this.Info.Id; } }

        public string Name
        {
            get { return this.Info.Name; }
            set { this.Info.Name = value; }
        }

        public string Description
        {
            get { return this.Info.Description; }
            set { this.Info.Description = value;  }
        }

        internal VPMJobInfo Info
        {
            get 
            {
                return _info; 
            }
            set { _info = value; }
        }

        public CBaseSessionInfo.EResult LatestStatus
        {
            get { return this.Info.LatestStatus; }
        }
        
        

        #endregion

        public VPMJob(CBackupJob job)
        {
            this._job = job;
            this.Info = new VPMJobInfo(job.Info);
            //this.Options = new JobOptions(job.Options);
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

        public void ChangeRepository(VPMRepository repository)
        {
            this.Info.ChangeRepository(repository);
        }

        /* Currently commented until I fully integrate VPMJobInfo
         * public JobOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }*/

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
                this.Info.VssOptions.cVssOptions,
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


        internal void Clone(string name)
        {
            string jobName;
            if (name == null) { jobName = this.Info.Name + "_copy"; }
            else { jobName = name; }
            CDbBackupJobInfo temp = CDbBackupJobInfo.CreateNew(
                jobName,
                this.Info.Description,
                this.Info.JobType,
                this.Info.TargetHostId,
                this.Info.TargetDir,
                this.Info.TargetFile,
                this.Info.Options.Options,
                this.Info.ScheduleOptions.SchedOptions,
                this.Info.VssOptions.cVssOptions,
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
            jobRun.FileName = this.managerExe;
            jobRun.Arguments = "startbackupjob " + "owner=[vbsvc] " + RunType + " " + this.Id + " " + tempSession.Id;
            System.Diagnostics.Process.Start(jobRun);
        }

        internal void Stop()
        {
            System.Diagnostics.ProcessStartInfo jobStop = new System.Diagnostics.ProcessStartInfo();
            jobStop.CreateNoWindow = true;
            jobStop.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            jobStop.FileName = this.managerExe;
            jobStop.Arguments = "stop " + this.Id;
            System.Diagnostics.Process.Start(jobStop);
        }
    }
}

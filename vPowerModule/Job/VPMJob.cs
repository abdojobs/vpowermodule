using System;
using System.Collections.Generic;
using System.Diagnostics;
using Veeam.Backup.Core;
using Veeam.Backup.DBManager;
using Veeam.Backup.Model;
using vPowerModule.Job.Options;
using vPowerModule.Objects;

namespace vPowerModule.Job
{
    public class VPMJob
    {

        #region Private Properties
        private readonly CBackupJob _job;
        private string managerExe = "C:\\Program Files\\Veeam\\Backup and Replication\\Veeam.Backup.Manager.exe";
        private VPMJobOptions _options;
        #endregion

        #region Public Properties

        public Guid Id
        {
            get { return Info.Id; }
        }

        public string Name
        {
            get { return Info.Name; }
            set { Info.Name = value; }
        }

        public string Description
        {
            get { return Info.Description; }
            set { Info.Description = value; }
        }

        public CBaseSessionInfo.EResult LatestStatus
        {
            get { return Info.LatestStatus; }
        }

        public bool IsBackup
        {
            get { return Info.IsBackup(); }
        }

        public bool IsReplica
        {
            get { return Info.IsReplica(); }
        }

        public bool IsCopy
        {
            get { return Info.IsCopy(); }
        }

        public VPMVssOptions VssOptions { get { return this.Info.VssOptions; } }

        public VPMScheduleOptions ScheduleOptions { get { return this.Info.ScheduleOptions; } }

        public VPMJobOptions Options { get { return this._options; } private set { _options = value; } }

        #endregion

        #region Public Methods

        public CObjectInJob[] GetObjectsInJob()
        {
            return CObjectInJob.GetByJob(this.Info.Id);
        }

        public void ChangeRepository(VPMRepository repository)
        {
            Info.ChangeRepository(repository);
        }

        public void Save()
        {
            CDbBackupJobInfo temp = CDbBackupJobInfo.CreateExisting(
                Info.Id,
                Info.Name,
                Info.Description,
                Info.JobType,
                Info.TargetHostId,
                Info.TargetDir,
                Info.TargetFile,
                Info.Options.Options,
                Info.ScheduleOptions.SchedOptions,
                Info.VssOptions.cVssOptions,
                Info.PostCommandRunCount,
                Info.VcbHostId,
                Info.SourceType,
                Info.TargetType,
                Info.IncludedSize,
                Info.ExcludedSize,
                Info.IsDeleted,
                Info.LatestStatus,
                Info.IsScheduleEnabled,
                Info.BackupPlatform,
                Info.TargetRepositoryId,
                Info.InitialRepositoryId);
            CDBManager.Instance.BackupJobs.UpdateJob(temp);
        }
        #endregion

        #region Internal Methods

        internal void Clone(string name, bool includeObjects)
        {
            string jobName;
            if (name == null)
            {
                jobName = Info.Name + "_copy";
            }
            else
            {
                jobName = name;
            }
            CDbBackupJobInfo temp = CDbBackupJobInfo.CreateNew(
                jobName,
                Info.Description,
                Info.JobType,
                Info.TargetHostId,
                Info.TargetDir,
                Info.TargetFile,
                Info.Options.Options,
                Info.ScheduleOptions.SchedOptions,
                Info.VssOptions.cVssOptions,
                Info.PostCommandRunCount,
                Info.VcbHostId,
                Info.SourceType,
                Info.TargetType,
                Info.IncludedSize,
                Info.ExcludedSize,
                Info.BackupPlatform,
                Info.TargetRepositoryId,
                Info.InitialRepositoryId);
            //CBackupJob.Create(temp);
            CDBManager.Instance.BackupJobs.CreateJob(temp);
            if(includeObjects)
            {
                foreach (CObjectInJob objectInJob in this._job.GetObjectsInJob())
                {
                    CObjectInJob.CreateViOij(temp.Id, objectInJob.GetObject().Id, new Guid("00000000-0000-0000-0000-000000000000"), 
                                             temp.VssOptions, objectInJob.Info.ApproxSize, objectInJob.Info.Location,
                                             objectInJob.Info.Type, objectInJob.Info.DiskFilter,
                                             objectInJob.Info.UpdateVmx);
                }
                //CBackupJob.Update(temp);
                CDBManager.Instance.BackupJobs.UpdateJob(temp);
            }
            
        }

        internal void Start(string RunType)
        {
            // Create a blank task sesion and set its event to started
            CBackupSession tempSession = CBackupSession.Create(CDbBackupJobInfo.Mode.Full, _job, true);
            CJobEvent.Create(tempSession.Id, "started");

            var jobRun = new ProcessStartInfo();
            jobRun.CreateNoWindow = true;
            jobRun.WindowStyle = ProcessWindowStyle.Hidden;
            jobRun.FileName = managerExe;
            jobRun.Arguments = "startbackupjob " + "owner=[vbsvc] " + RunType + " " + Id + " " + tempSession.Id;
            Process.Start(jobRun);
        }

        internal void Stop()
        {
            var jobStop = new ProcessStartInfo();
            jobStop.CreateNoWindow = true;
            jobStop.WindowStyle = ProcessWindowStyle.Hidden;
            jobStop.FileName = managerExe;
            jobStop.Arguments = "stop " + Id;
            Process.Start(jobStop);
        }
        #endregion

        public  VPMJobInfo Info { get; set; }

        public VPMJob(CBackupJob job)
        {
            _job = job;
            Info = new VPMJobInfo(job.Info);
            this.Options = new VPMJobOptions(job.Options);
        }

        public static VPMJob[] GetAll()
        {
            CBackupJob[] list = CBackupJob.GetAll();
            var Jobs = new List<VPMJob>();
            foreach (CBackupJob BackupJob in list)
            {
                Jobs.Add(new VPMJob(BackupJob));
            }
            return Jobs.ToArray();
        }

    }
}
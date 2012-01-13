using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;

namespace vPowerModule.Objects
{
    class VPMRepository
    {
        private readonly CBackupRepository _repository;

        #region Properties
        public CBackupRepository Repository
        {
            get { return _repository; }           
        }

        public string Description
        {
            get { return _repository.Description; }
        }

        public Guid HostId
        {
            get { return _repository.HostId; }
        }

        public Guid MountHostId
        {
            get { return _repository.MountHostId; }
        }

        public string Name
        {
            get { return _repository.Name; }
        }

        public CDomBackupRepositoryOptions Options
        {
            get { return _repository.Options; }
        }

        public string Path
        {
            get
            { return _repository.Path; }
        }

        public Guid ShareCredsId
        {
            get { return _repository.ShareCredsId; }
        }
        #endregion

        public VPMRepository(CBackupRepository repo)
        {
            _repository = repo;
        }
    }
}

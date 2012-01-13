using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veeam.Backup.Core;

namespace vPowerModule.Objects
{
    class VPMRepository
    {
        private CBackupRepository _repository;

        public CBackupRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public VPMRepository(CBackupRepository repo)
        {
            _repository = repo;
        }
    }
}

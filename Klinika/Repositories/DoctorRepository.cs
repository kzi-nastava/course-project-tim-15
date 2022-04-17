using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;

namespace Klinika.Repositories
{
    internal class DoctorRepository
    {
        #region [ --- VARIABLES --- ]
        public List<Doctor> Doctors { get; private set; }
        #endregion

        #region [ --- SINGLETON --- ]
        private DoctorRepository? Instance;
        private DoctorRepository()
        {
            Doctors = new List<Doctor>();
            // TODO Load data
        }
        public DoctorRepository GetInstance()
        {
            if(Instance == null) Instance = new DoctorRepository();
            return Instance;
        }
        #endregion
        
    }
}

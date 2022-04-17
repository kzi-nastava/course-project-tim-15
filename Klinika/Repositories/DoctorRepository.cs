using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Newtonsoft.Json;

namespace Klinika.Repositories
{
    internal class DoctorRepository
    {
        #region [ --- VARIABLES --- ]
        private static string PATH = "./../../../Data/Doctors.json";
        public List<Doctor> Doctors { get; private set; }
        #endregion

        #region [ --- FUNCTIONS --- ]
        public void Put(Doctor doctor)
        {
            Doctors.Add(doctor);
            File.WriteAllText(PATH, JsonConvert.SerializeObject(Doctors, Formatting.Indented));
        }
        #endregion

        #region [ --- SINGLETON --- ]
        private static DoctorRepository? instance;
        private DoctorRepository()
        {
            var doctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(PATH));
            if (doctors == null) Doctors = new List<Doctor>();
            else Doctors = doctors;
        }
        public static DoctorRepository Instance
        {
            get
            {
                if (instance == null) instance = new DoctorRepository();
                return instance;
            }
        }
        #endregion
        
    }
}

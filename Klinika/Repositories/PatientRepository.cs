using Klinika.Roles;
using Newtonsoft.Json;

namespace Klinika.Repositories
{
    internal class PatientRepository
    {
        #region [ --- VARIABLES --- ]
        private static string PATH = "./../../../Data/Patients.json";
        public List<Patient> Patients { get; private set; }
        #endregion

        #region [ --- FUNCTIONS --- ]
        public void Put(Patient patient)
        {
            Patients.Add(patient);
            File.WriteAllText(PATH, JsonConvert.SerializeObject(Patients, Formatting.Indented));
        }
        #endregion

        #region [ --- SINGLETON --- ]
        private PatientRepository()
        {
            var patients = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(PATH));
            if (patients == null) Patients = new List<Patient>();
            else Patients = patients;
        }
        private static PatientRepository? instance;
        public static PatientRepository Instance
        {
            get
            {
                if (instance == null) instance = new PatientRepository();
                return instance;
            }
        }
        #endregion
    }
}

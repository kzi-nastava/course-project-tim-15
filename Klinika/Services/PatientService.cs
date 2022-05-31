using System.Data;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Utilities;

namespace Klinika.Services
{
    internal class PatientService
    {
        public static Patient? GetSingle(string email)
        {
            return PatientRepository.IDPatientPairs[PatientRepository.EmailIDPairs[email]];
        }
        public static User? GetSingle(int id)
        {
            return UserRepository.GetInstance().Users.Where(x => x.ID == id).FirstOrDefault();
        }
        public static DataTable GetAll()
        {
            return PatientRepository.GetAll();
        }

        public static bool Add(Patient newPatient)
        {
            string error_message = ValidationUtilities.ValidatePatient(newPatient);
            if(error_message != null)
            {
                MessageBoxUtilities.ShowErrorMessage(error_message);
                return false;
            }
            PatientRepository.Create(newPatient);
            return true;
        }
        public static void Modify(Patient patient)
        {
            string error_message = ValidationUtilities.ValidatePatient(patient,isModification: true);
            if(error_message != null)
            {
                MessageBoxUtilities.ShowErrorMessage(error_message);
                return;
            }
            PatientRepository.Modify(patient);
        }
        public static void Delete(int patientId)
        {
            PatientRepository.Delete(patientId);
        }

        public static string GetFullName(int ID)
        {
            var patient = UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
            return $"{patient.Name} {patient.Surname}";
        }
        public static Patient GetById(int id)
        {
            return PatientRepository.GetSingle(id);
        }

        public static bool IsBlocked(User patient)
        {
            bool isBlocked = AppointmentRepository.GetScheduledAppointmentsCount(patient.ID) > 8 
                || AppointmentService.GetModifyAppointmentsCount(patient.ID) > 5;
            if (!isBlocked) return false;
            Block(patient, "SYS");
            return true;
        }
        public static void Block(User patient, string whoBlocked)
        {
            patient.IsBlocked = true;
            PatientRepository.Block(patient.ID, whoBlocked);
        }
        public static void Unblock(Patient patient)
        {
            patient.whoBlocked = "";
            patient.IsBlocked = false;
            PatientRepository.Unblock(patient.ID);
        }
    }
}
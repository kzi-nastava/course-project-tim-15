using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Klinika.Data;
using Klinika.Exceptions;
using Klinika.GUI.Secretary;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Utilities;

namespace Klinika.Services
{
    internal class PatientService
    {
        public static void Add(Patient newPatient)
        {
            string error_message = ValidationUtilities.ValidatePatient(newPatient);
            if(error_message != null)
            {
                MessageBoxUtilities.ShowErrorMessage(error_message);
                return;
            }
            PatientRepository.Create(newPatient);
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

        public static void Block(Patient patient,string whoBlocked)
        {
            patient.whoBlocked = whoBlocked;
            patient.IsBlocked = true;
            PatientRepository.Block(patient.ID);
        }

        public static void Unblock(Patient patient)
        {
            patient.whoBlocked = "";
            patient.IsBlocked = false;
            PatientRepository.Unblock(patient.ID);
        }

        public static string GetFullName(int ID)
        {
            var patient = UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
            return $"{patient.Name} {patient.Surname}";
        }

        public static bool IsBlocked(int id)
        {
            if (AppointmentRepository.GetScheduledAppointmentsCount(id) > 8 
                || PatientRequestRepository.GetModifyAppointmentsCount(id) > 5)
            {
                return true;
            }
            return false;
        }

        public static Patient? GetSingle(string email)
        {
            return PatientRepository.IDPatientPairs[PatientRepository.EmailIDPairs[email]];
        }

        public static DataTable GetAll()
        {
            return PatientRepository.GetAll();
        }
    }
}

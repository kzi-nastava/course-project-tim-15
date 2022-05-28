using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class MedicalRecordService
    {
        public MedicalRecordService() { }
        public static List<Anamnesis> GetAnamneses(int patientID)
        {
            return MedicalRecordRepository.GetAnamneses(patientID);
        }
        public static void StoreAnamanesis(Anamnesis anamnesis)
        {
            MedicalRecordRepository.CreateAnamnesis(anamnesis);
        }
        public static void CreateReferal(int patientID, int specializationID, int doctorID)
        {
            ReferalRepository.Create(patientID, specializationID, doctorID);
        }
        public static List<Anamnesis> GetFiltered(int patientID, string searchParam)
        {
            return MedicalRecordRepository.GetAnamneses(patientID).Where(
                x => x.Description.ToUpper().Contains(searchParam.ToUpper())
                || x.Symptoms.ToUpper().Contains(searchParam.ToUpper())
                || x.Conclusion.ToUpper().Contains(searchParam.ToUpper())).ToList();
        }
    }
}

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
        public void StoreAnamanesis(Anamnesis anamnesis)
        {
            MedicalRecordRepository.CreateAnamnesis(anamnesis);
        }
        public void CreateReferal(int patientID, int specializationID, int doctorID)
        {
            ReferalRepository.Create(patientID, specializationID, doctorID);
        }
    }
}

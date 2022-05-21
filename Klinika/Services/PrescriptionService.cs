using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.GUI.Doctor;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    public class PrescriptionService
    {
        public PrescriptionService() { }
        public static void StorePrescription(Prescription prescription)
        {
            DrugRepository.CreatePrescription(prescription);
        }
    }
}
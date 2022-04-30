using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class PatientRequest
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int MedicalActionID  { get; set; }
        public char Type { get; set; }
        public string? Description { get; set; }
        public bool Approved { get; set; }

        public PatientRequest()
        {
            ID = -1;
        }
        public PatientRequest(int id, int patientID, int medicalActionID, char type,
            string? description, bool approved)
        {
            ID = id;
            PatientID = patientID;
            MedicalActionID = medicalActionID;
            Type = type;
            Description = description;
            Approved = approved;
        }
    }
}

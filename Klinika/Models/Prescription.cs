﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Prescription
    {
        public int PatientID { get; set; }
        public int DrugID { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
        public int Interval { get; set; }
        public string? Comment { get; set; }

        public Prescription() { }
        public Prescription(int patientID, int drugID, TimeSlot timeSlot, int interval, string comment)
        {
            PatientID = patientID;
            DrugID = drugID;
            DateStarted = timeSlot.from;
            DateEnded = timeSlot.to;
            Interval = interval;
            Comment = comment;
        }
    }
}

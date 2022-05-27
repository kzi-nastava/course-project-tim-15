﻿using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    internal class PatientRequestService
    {
        public static void SendDeleted(bool isApproved, Appointment toDelete)
        {
            PatientRequest patientRequest = new PatientRequest(-1, toDelete.PatientID, toDelete.ID,
                        'D', GenerateDescription(toDelete.DateTime, toDelete.DoctorID), isApproved);
            PatientRequestRepository.Create(patientRequest);
        }

        public static string GenerateDescription(DateTime dateTime, int doctorID)
        {
            return "DateTime=" + dateTime.ToString("yyyy-MM-dd HH:mm:ss.000") + ";DoctorID=" + doctorID.ToString();
        }

        public static void SendModify(bool isApproved, Appointment appointment, string description)
        {
            PatientRequest patientRequest = new PatientRequest();
            patientRequest.PatientID = appointment.PatientID;
            patientRequest.MedicalActionID = appointment.ID;
            patientRequest.Type = 'M';
            patientRequest.Description = description;
            patientRequest.Approved = isApproved;
            PatientRequestRepository.Create(patientRequest);
        }

        public static PatientModificationRequest GetModificationRequest(int requestId)
        {
            return PatientRequestRepository.IdRequestPairs[requestId];
        }

        public static DataTable GetAll()
        {
            return PatientRequestRepository.GetAll();
        }

        public static void Approve(int requestId)
        {
            PatientRequestRepository.Approve(requestId);
        }

        public static void Deny(int requestId)
        {
            PatientRequestRepository.Deny(requestId);
        }
    }
}

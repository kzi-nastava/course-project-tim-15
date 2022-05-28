﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;

namespace Klinika.Services
{
    internal class AppointmentService
    {
        public static string GetTypeFullName(char type)
        {
            switch (type)
            {
                case 'O':
                    return "Operation";
                default:
                    return "Examination";
            }
        }
        public static List<Appointment> GetOccupied(DateTime date, int doctorID)
        {
            return AppointmentRepository.GetAll(date.ToString("yyyy-MM-dd"), doctorID, User.RoleType.DOCTOR);
        }
        public static List<Appointment> GetCompleted(int patientID)
        {
            return AppointmentRepository.GetCompleted(patientID);
        }
        public static void Create(Appointment appointment)
        {
            AppointmentRepository.GetInstance().Create(appointment);
        }
        public static void Modify(Appointment appointment)
        {
            AppointmentRepository.GetInstance().Modify(appointment);
        }
        public static void Delete(int id)
        {
            AppointmentRepository.Delete(id);
            AppointmentRepository.GetInstance().DeleteFromList(id);
        }
        public static Appointment GetById(int id)
        {
            return AppointmentRepository.GetInstance().Appointments.Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
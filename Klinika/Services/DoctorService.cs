using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Models;
using System.Data;

namespace Klinika.Services
{
    internal class DoctorService
    {
        private DoctorRepository doctorRepository { get; }
        public DoctorService()
        {
            doctorRepository = DoctorRepository.GetInstance();
        }


        public static Doctor? GetSuitable(int specializationId, DateTime from)
        {
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.ID != specializationId) continue;

                if (!AppointmentRepository.GetInstance().IsOccupied(from, doctor.ID)) return doctor;
            }
            return null;
        }

        public static (Doctor?,TimeSlot?) GetSuitableUnderTwoHours(int specializationId)
        {
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (doctor.specialization.ID == specializationId)
                {
                    TimeSlot? firstAvailable = ScheduleService.GetFirstSlotAvailableUnderTwoHours(doctor.ID);
                    if (firstAvailable != null) return (doctor,firstAvailable);
                }
            }
            return (null,null);
        }

        // TODO This needs to move
        public static void FillAppointmentTypeField(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Type"] = AppointmentService.GetTypeFullName(Convert.ToChar(row["Type"]));
            }
        }

        public static string GetFullName(int doctorID)
        {
            return UserRepository.GetDoctor(doctorID).ToString();
        }

        public static List<Doctor> SearchByName(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.Name.ToUpper().Contains(keyword.ToUpper())).ToList();
        }

        public static List<Doctor> SearchBySurname(string keyword)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.Surname.ToUpper().Contains(keyword.ToUpper())).ToList();
        }

        public static List<Doctor> SearchBySpecialization(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.specialization.ID == id).ToList();
        }

        public static Doctor GetById(int id)
        {
            return DoctorRepository.GetInstance().doctors.Where(x => x.ID == id).FirstOrDefault();
        }

    }
}

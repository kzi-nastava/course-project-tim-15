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
        public static Doctor? GetSuitable(int specializationId,TimeSlot slot)
        {
            List<Doctor> allDoctors = DoctorRepository.GetInstance().doctors; 
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.specialization.ID == specializationId &&
                    !AppointmentRepository.GetInstance().IsOccupied(newAppointmentStart:slot.from,doctorID:doctor.ID))
                {
                    return doctor;
                }
            }
            return null;
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
        public static int GetSelectedID(DataGridView table)
        {
            return Convert.ToInt32(table.SelectedRows[0].Cells["Doctor ID"].Value);
        }
    }
}

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
        public static Doctor? GetSuitable(string specialization,DateTime from)
        {
            List<Doctor> allDoctors = DoctorRepository.GetAll();
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.specialization.Name.Equals(specialization) &&
                    !AppointmentRepository.GetInstance().IsOccupied(newAppointmentStart:from,doctorID:doctor.ID))
                {
                    return doctor;
                }
            }
            return null;
        }

        public static void FillTableWithData(DataTable? data, DataGridView table)
        {
            if (data != null)
            {
                FillTableWithPatientData(data);
                FillAppointmentTypeField(data);
                data.Columns.Remove("DoctorID");
                data.Columns.Remove("PatientID");
                data.Columns.Remove("RoomID");
                data.Columns.Remove("IsDeleted");
                data.Columns.Remove("Description");

                data.Columns["Completed"].SetOrdinal(6);

                table.DataSource = data;
                table.Columns["Duration"].HeaderText = "Duration [min]";

                table.ClearSelection();
            }
        }
        private static void FillTableWithPatientData(DataTable dt)
        {
            dt.Columns.Add("Patient Full Name");
            dt.Columns["Patient Full Name"].SetOrdinal(1);
            foreach (DataRow row in dt.Rows)
            {
                row["Patient Full Name"] = PatientService.GetFullName(Convert.ToInt32(row["PatientID"]));
            }
        }
        private static void FillAppointmentTypeField(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Type"] = AppointmentService.GetTypeFullName(Convert.ToChar(row["Type"]));
            }
        }
        public static void UpdateTableRow(Appointment appointment, DataGridView table)
        {
            table.SelectedRows[0].SetValues(appointment.ID.ToString(),
                PatientService.GetFullName(appointment.PatientID),
                appointment.DateTime.ToString(),
                appointment.GetType(),
                appointment.Duration.ToString(),
                appointment.Urgent,
                appointment.Completed);
        }
        public static void DeleteAppointmet(DataGridView table)
        {
            int id = AppointmentService.GetSelectedID(table);
            AppointmentService.Delete(id);
            table.Rows.RemoveAt(table.CurrentRow.Index);
        }
    }
}

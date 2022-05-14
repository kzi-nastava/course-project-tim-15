using Klinika.Data;
using Klinika.Models;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Services;

namespace Klinika.Repositories
{
    internal class DoctorRepository
    {

        private static DoctorRepository? singletonInstance;
        public  List<Doctor> doctors { get; }

        private DoctorRepository()
        {
            doctors = GetAll();
        }

        public static DoctorRepository GetInstance()
        {
            if (singletonInstance == null) singletonInstance = new DoctorRepository();
            return singletonInstance;
        }

        public Doctor GetById(int id)
        {
            return doctors.Where(x => x.ID == id).FirstOrDefault();
        }

        public static string GetNameSurname(int id)
        {
            string getQuery = "SELECT Name + ' ' + Surname AS 'Doctor' " +
                                     "FROM [User] " +
                                     "WHERE ID = @ID";
            string nameSurname = "";
            DataTable allDoctors = DatabaseConnection.GetInstance().CreateTableOfData(getQuery, ("@ID", id));
            foreach (DataRow doctor in allDoctors.Rows)
            {
                nameSurname = doctor["Doctor"].ToString();
            }
            return nameSurname;
        }

        public static List<Specialization> GetSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            
            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT * FROM [Specialization]";

            try
            {
                SqlCommand get = new SqlCommand(getQuery, database);
                database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        specializations.Add(new Specialization
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            Name = retrieved["Name"].ToString()
                        });
                    }
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return specializations;
        }
        public static List<int> GetSpecializedIDs(int specializationID)
        {
            List<int> doctors = new List<int>();

            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT UserID " +
                "FROM [DoctorSpecialization] " +
                $"WHERE SpecializationID = {specializationID}";

            try
            {
                SqlCommand get = new SqlCommand(getQuery, database);
                database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        doctors.Add(Convert.ToInt32(retrieved["UserID"]));
                    }
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return doctors;
        }
        public static Specialization getSpecialization (int DoctorID)
        {
            string specializationQuerry = "SELECT [Specialization].ID, [Specialization].Name " +
                                          "FROM [Specialization] JOIN [DoctorSpecialization] " +
                                          "ON [Specialization].ID = [DoctorSpecialization].SpecializationID " +
                                          $"WHERE [DoctorSpecialization].UserID = {DoctorID}";

            Specialization specialization = new Specialization();

            try
            {
                SqlCommand getAnamneses = new SqlCommand(specializationQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAnamneses.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        specialization.ID = Convert.ToInt32(retrieved["ID"]);
                        specialization.Name = retrieved["Name"].ToString();
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return specialization;
        }


        public static List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            string getAllQuery = "SELECT [DoctorSpecialization].UserID, [User].Name,[User].Surname, " +
                                 "[DoctorSpecialization].SpecializationID,[Specialization].Name 'Specialization' " +
                                 "FROM [DoctorSpecialization] " +
                                 "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                                 "LEFT OUTER JOIN [Specialization] ON [DoctorSpecialization].SpecializationID = [Specialization].ID";

            DataTable allDoctors = DatabaseConnection.GetInstance().CreateTableOfData(getAllQuery);

            foreach(DataRow row in allDoctors.Rows)
            {
                Specialization specialization = new Specialization(
                                                Convert.ToInt32(row["SpecializationID"]),
                                                row["Specialization"].ToString());

                Doctor doctor = new Doctor(
                                Convert.ToInt32(row["UserID"]),
                                row["Name"].ToString(),
                                row["Surname"].ToString(),
                                specialization);
                doctors.Add(doctor);
            }

            return doctors;
        }

        public List<Specialization> GetAllAvailableSpecializations()
        {
            List<int> availableSpecializationsIds = new List<int>();
            List<Specialization> available = new List<Specialization>();
            foreach (Doctor doctor in doctors)
            {
                if (!availableSpecializationsIds.Contains(doctor.specialization.ID))
                {
                    availableSpecializationsIds.Add(doctor.specialization.ID);
                    available.Add(doctor.specialization);
                }
            }

            return available;
        }


        public Doctor? GetFirstUnoccupied(TimeSlot slot,int specializationId)
        {
            foreach(Doctor doctor in doctors)
            {
                if(doctor.specialization.ID == specializationId &&
                   !AppointmentRepository.GetInstance().IsOccupied(slot, doctor.ID))
                {
                    return doctor;
                }
            }
            return null;
        }


        public Dictionary<Appointment, DateTime> GetMostMovableAppointments(int specializationId,int duration)
        {
            Dictionary<Appointment, DateTime> appointmentIdRescheduleDatePairs = new Dictionary<Appointment, DateTime>();

            foreach(Doctor doctor in doctors)
            {
                if (doctor.specialization.ID != specializationId) continue;

                TimeSlot broadSpan = new TimeSlot(SecretaryService.GetNow().AddHours(-2),SecretaryService.GetNow().AddYears(1));
                List<TimeSlot> occupied = doctor.GetOccupiedTimeSlots(broadSpan);
                foreach(Appointment appointment in AppointmentRepository.GetInstance().Appointments)
                {
                    if (appointment.DoctorID != doctor.ID) continue;
                    TimeSlot appointmentSlot = new TimeSlot(appointment.DateTime, appointment.DateTime.AddMinutes(Convert.ToInt32(appointment.Duration)));
                    for(int i = 0; i < occupied.Count; i++)
                    {
                        if(occupied[i].from == appointment.DateTime)
                        {
                            TimeSlot firstUnoccupied = appointmentSlot.GetFirstUnoccupied(occupied,-1);
                            appointmentIdRescheduleDatePairs.Add(appointment, firstUnoccupied.from);
                            break;
                        }
                    }
                }
            }

            var midSortedDictionary = from entry in appointmentIdRescheduleDatePairs orderby entry.Key.DateTime ascending select entry;
            var sortedDictionary = from entry in midSortedDictionary orderby entry.Value ascending select entry;
            return sortedDictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Data;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using static Klinika.Roles.User;

namespace Klinika.Repositories
{
    internal class AppointmentRepository
    {
        public List<Appointment> Appointments { get; set; }

        #region Singleton
        private static AppointmentRepository? Instance;
        public static AppointmentRepository GetInstance()
        {
            if(Instance == null) Instance = new AppointmentRepository();
            return Instance;
        }
        public T CheckNull<T>(object obj)
        {
            return obj == DBNull.Value ? default(T) : (T)obj;
        }
        public AppointmentRepository()
        {
            Appointments = new List<Appointment>();
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction]";
            try
            {
                SqlCommand getAll = new SqlCommand(getAllQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAll.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.ID = Convert.ToInt32(retrieved["ID"]);
                        appointment.DoctorID = Convert.ToInt32(retrieved["DoctorID"]);
                        appointment.PatientID = Convert.ToInt32(retrieved["PatientID"]);
                        appointment.DateTime = Convert.ToDateTime(retrieved["DateTime"].ToString());
                        appointment.RoomID = Convert.ToInt32(retrieved["RoomID"]);
                        appointment.Completed = Convert.ToBoolean(retrieved["Completed"]);
                        appointment.Type = Convert.ToChar(retrieved["Type"]);
                        appointment.Duration = CheckNull<int>(retrieved["Duration"]);
                        appointment.Urgent = CheckNull<bool>(retrieved["Urgent"]);
                        appointment.Description = CheckNull<string>(retrieved["Description"]);
                        appointment.IsDeleted = CheckNull<bool>(retrieved["IsDeleted"]);
                        Appointments.Add(appointment);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Returns all appointmets of requested day in format "yyyy-MM-dd"
        /// </summary>
        /// <param name="requestedDate"></param>
        /// <returns></returns>
        public static DataTable? GetAll(string requestedDate, int days = 1)
        {
            DateTime start = DateTime.ParseExact($"{requestedDate} 00:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = start.AddDays(days);

            DataTable? retrievedAppointments = null;

            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime BETWEEN '{start}' AND '{end}' " +
                                  $"AND IsDeleted = 0";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuerry, DatabaseConnection.GetInstance().database);
                retrievedAppointments = new DataTable();
                adapter.Fill(retrievedAppointments);

            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }

            return retrievedAppointments;
        }
        public static DataTable? GetAll(int ID, RoleType role)
        {
            DataTable? retrievedAppointments = null;

            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime > '{DateTime.Now}' AND {roleToString} = {ID} " +
                                  $"AND IsDeleted = 0";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuerry, DatabaseConnection.GetInstance().database);
                retrievedAppointments = new DataTable();
                adapter.Fill(retrievedAppointments);
                foreach (DataRow row in retrievedAppointments.Rows)
                {
                    Appointment appointment = new Appointment(Convert.ToInt32(row["ID"]), Convert.ToInt32(row["DoctorID"]),
                            Convert.ToInt32(row["PatientID"]), Convert.ToDateTime(row["DateTime"].ToString()),
                            Convert.ToInt32(row["RoomID"]), Convert.ToBoolean(row["Completed"]), Convert.ToChar(row["Type"]),
                            Convert.ToInt32(row["Duration"]), Convert.ToBoolean(row["Urgent"]), row["Description"].ToString(),
                            Convert.ToBoolean(row["IsDeleted"]));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retrievedAppointments;
        }
        
        public void Delete(int ID)
        {
            string deleteQuerry = "UPDATE [MedicalAction] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuerry, DatabaseConnection.GetInstance().database);
                delete.Parameters.AddWithValue("@ID", ID);
                DatabaseConnection.GetInstance().database.Open();
                delete.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
                Appointments.Where(x => x.ID == ID).FirstOrDefault().IsDeleted = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Create(Appointment appointment)
        {
            string createQuery = "INSERT INTO [MedicalAction] " +
                "(DoctorID,PatientID,DateTime,RoomID,Completed,Type,Duration,Urgent,Description,IsDeleted) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@DoctorID,@PatientID,@DateTime,@RoomID,@Completed,@Type,@Duration,@Urgent,@Description,@IsDeleted)";

            SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
            create.Parameters.AddWithValue("@PatientID", appointment.PatientID);
            create.Parameters.AddWithValue("@DateTime", appointment.DateTime);
            create.Parameters.AddWithValue("@RoomID", appointment.RoomID);
            create.Parameters.AddWithValue("@Completed", appointment.Completed);
            create.Parameters.AddWithValue("@Type", appointment.Type);
            create.Parameters.AddWithValue("@Duration", appointment.Duration);
            create.Parameters.AddWithValue("@Urgent", appointment.Urgent);
            create.Parameters.AddWithValue("@Description", appointment.Description);
            create.Parameters.AddWithValue("@IsDeleted", appointment.IsDeleted);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                appointment.ID = (int)create.ExecuteScalar();
                DatabaseConnection.GetInstance().database.Close();
                Appointments.Add(appointment);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Modify(Appointment appointment)
        {
            string createQuery = "UPDATE [MedicalAction] SET " +
                "DoctorID = @DoctorID, " +
                "PatientID = @PatientID, " +
                "DateTime = @DateTime, " +
                "RoomID = @RoomID, " +
                "Completed = @Completed, " +
                "Type = @Type, " +
                "Duration = @Duration, " +
                "Urgent = @Urgent, " +
                "Description = @Description, " +
                "IsDeleted = @IsDeleted " +
                "WHERE ID = @ID";

            SqlCommand modify = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            modify.Parameters.AddWithValue("@ID", appointment.ID);
            modify.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
            modify.Parameters.AddWithValue("@PatientID", appointment.PatientID);
            modify.Parameters.AddWithValue("@DateTime", appointment.DateTime);
            modify.Parameters.AddWithValue("@RoomID", appointment.RoomID);
            modify.Parameters.AddWithValue("@Completed", appointment.Completed);
            modify.Parameters.AddWithValue("@Type", appointment.Type);
            modify.Parameters.AddWithValue("@Duration", appointment.Duration);
            modify.Parameters.AddWithValue("@Urgent", appointment.Urgent);
            modify.Parameters.AddWithValue("@Description", appointment.Description);
            modify.Parameters.AddWithValue("@IsDeleted", appointment.IsDeleted);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                modify.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();

                Appointments.Remove(Appointments.Where(x => x.ID == appointment.ID).FirstOrDefault());
                Appointments.Add(appointment);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool IsOccupied(DateTime newAppointmentStart, int duration = 15, int id = -1)
        {
            var newAppointmentEnd = newAppointmentStart.AddMinutes(duration);

            foreach (Appointment appointment in Appointments)
            {
                var start = appointment.DateTime;
                var end = appointment.DateTime.AddMinutes(appointment.Duration);

                if (!appointment.IsDeleted && appointment.ID != id &&
                    newAppointmentStart < end && start < newAppointmentEnd)
                    return true;
            }
            return false;
        }
    }
}

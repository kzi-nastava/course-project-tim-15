using Klinika.Data;
using Klinika.Models;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using static Klinika.Roles.User;

namespace Klinika.Repositories
{
    internal class AppointmentRepository
    {
        public List<Appointment> Appointments { get; set; }
        public void DeleteFromList(int ID)
        {
            Appointments.Where(x => x.ID == ID).FirstOrDefault().IsDeleted = true;
        }

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
        public static DataTable? GetAll(string requestedDate, int ID, RoleType role, int days = 1)
        {
            DateTime start = DateTime.ParseExact($"{requestedDate} 00:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = start.AddDays(days);


            DataTable? retrievedAppointments = null;

            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime BETWEEN '{start}' AND '{end}' AND {roleToString} = {ID} " +
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
        public List<Appointment> GetCompleted(int PatientID)
        {
            string getCompletedQuerry = "SELECT * " +
                                        "FROM [MedicalAction] " +
                                        $"WHERE PatientID = {PatientID} AND Completed = 1";

            List<Appointment> appointments = new List<Appointment>();

            try
            {
                SqlCommand getCompleted = new SqlCommand(getCompletedQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getCompleted.ExecuteReader())
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
                        appointments.Add(appointment);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return appointments;
        }

        public void Create(Appointment appointment)
        {
            string createQuery = "INSERT INTO [MedicalAction] " +
                "(DoctorID,PatientID,DateTime,RoomID,Completed,Type,Duration,Urgent,Description,IsDeleted) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@DoctorID,@PatientID,@DateTime,@RoomID,@Completed,@Type,@Duration,@Urgent,@Description,@IsDeleted)";

            appointment.ID = (int)DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(
                createQuery,
                ("@DoctorID", appointment.DoctorID),
                ("@PatientID", appointment.PatientID),
                ("@DateTime", appointment.DateTime),
                ("@RoomID", appointment.RoomID),
                ("@Completed", appointment.Completed),
                ("@Type", appointment.Type),
                ("@Duration", appointment.Duration),
                ("@Urgent", appointment.Urgent),
                ("@Description", appointment.Description),
                ("@IsDeleted", appointment.IsDeleted));

            Appointments.Add(appointment);
        }
        public static void Modify(int id, int newDoctorID, DateTime newAppointment)
        {
            string modifyQuery = "UPDATE [MedicalAction] SET DoctorID = @DoctorID, DateTime = @DateTime WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@DoctorID", newDoctorID),
                ("@DateTime", newAppointment),
                ("@ID", id));
        }
        public void Modify(Appointment appointment)
        {
            string modifyQuery = "UPDATE [MedicalAction] SET " +
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

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@ID", appointment.ID),
                ("@DoctorID", appointment.DoctorID),
                ("@PatientID", appointment.PatientID),
                ("@DateTime", appointment.DateTime),
                ("@RoomID", appointment.RoomID),
                ("@Completed", appointment.Completed),
                ("@Type", appointment.Type),
                ("@Duration", appointment.Duration),
                ("@Urgent", appointment.Urgent),
                ("@Description", appointment.Description),
                ("@IsDeleted", appointment.IsDeleted));

            Appointments.Remove(Appointments.Where(x => x.ID == appointment.ID).FirstOrDefault());
            Appointments.Add(appointment);
        }
        public static void Delete(int ID)
        {
            string deleteQuerry = "UPDATE [MedicalAction] SET IsDeleted = 1 WHERE ID = @ID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(deleteQuerry, ("@ID", ID));
        }

        public bool IsOccupied(DateTime newAppointmentStart, int doctorID, int duration = 15, int appointmentID = -1)
        {
            var newAppointmentEnd = newAppointmentStart.AddMinutes(duration); 

            foreach (Appointment appointment in Appointments)
            {
                var start = appointment.DateTime;
                var end = appointment.DateTime.AddMinutes(appointment.Duration);

                if (appointment.DoctorID != doctorID)
                {
                    continue;
                }
                if (!appointment.IsDeleted && appointment.ID != appointmentID &&
                    newAppointmentStart < end && start < newAppointmentEnd) 
                    return true;
            }
            return false;
        }
        public static int GetPersonalCount (int ID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);
            int counter = 0;

            string getQuerry = "SELECT COUNT(*) as Number " +
                "FROM [MedicalAction] " +
                $"WHERE PatientID = {ID} AND DateTime > '{startDate.ToString("yyyy-MM-dd HH:mm:ss.000")}'";

            try
            {
                SqlCommand get = new SqlCommand(getQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = get.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        counter = Convert.ToInt32(retrieved["Number"]);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return counter;
        }


    }
}

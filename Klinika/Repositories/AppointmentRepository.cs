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
        public AppointmentRepository()
        {
            Appointments = new List<Appointment>();
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction]";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getAllQuerry);
            foreach (object row in resoult)
            {
                var appointment = new Appointment
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    DoctorID = Convert.ToInt32(((object[])row)[1].ToString()),
                    PatientID = Convert.ToInt32(((object[])row)[2].ToString()),
                    DateTime = Convert.ToDateTime(((object[])row)[3].ToString()),
                    RoomID = Convert.ToInt32(((object[])row)[4].ToString()),
                    Completed = Convert.ToBoolean(((object[])row)[5].ToString()),
                    Type = Convert.ToChar(((object[])row)[6].ToString()),
                    Duration = DatabaseConnection.CheckNull<int>(((object[])row)[7]),
                    Urgent = DatabaseConnection.CheckNull<bool>(((object[])row)[8]),
                    Description = DatabaseConnection.CheckNull<string>(((object[])row)[9]),
                    IsDeleted = DatabaseConnection.CheckNull<bool>(((object[])row)[10])
                };
                Appointments.Add(appointment);
            }
        }
        #endregion

        public static DataTable? GetAll(string requestedDate, int ID, RoleType role, int days = 1)
        {
            DateTime start = DateTime.ParseExact($"{requestedDate} 00:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = start.AddDays(days);

            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime BETWEEN '{start}' AND '{end}' AND {roleToString} = {ID} " +
                                  $"AND IsDeleted = 0";
            
            return DatabaseConnection.GetInstance().CreateTableOfData(getAllQuerry);
        }
        public static DataTable? GetAll(int ID, RoleType role)
        {
            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime > '{DateTime.Now}' AND {roleToString} = {ID} " +
                                  $"AND IsDeleted = 0";

            return DatabaseConnection.GetInstance().CreateTableOfData(getAllQuerry);
        }
        public List<Appointment> GetCompleted(int PatientID)
        {
            string getCompletedQuerry = "SELECT * " +
                                        "FROM [MedicalAction] " +
                                        $"WHERE PatientID = {PatientID} AND Completed = 1";

            List<Appointment> appointments = new List<Appointment>();

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getCompletedQuerry);
            foreach(object row in resoult)
            {
                var appointment = new Appointment
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    DoctorID = Convert.ToInt32(((object[])row)[1].ToString()),
                    PatientID = Convert.ToInt32(((object[])row)[2].ToString()),
                    DateTime = Convert.ToDateTime(((object[])row)[3].ToString()),
                    RoomID = Convert.ToInt32(((object[])row)[4].ToString()),
                    Completed = Convert.ToBoolean(((object[])row)[5].ToString()),
                    Type = Convert.ToChar(((object[])row)[6].ToString()),
                    Duration = DatabaseConnection.CheckNull<int>(((object[])row)[7]),
                    Urgent = DatabaseConnection.CheckNull<bool>(((object[])row)[8]),
                    Description = DatabaseConnection.CheckNull<string>(((object[])row)[9]),
                    IsDeleted = DatabaseConnection.CheckNull<bool>(((object[])row)[10])
                };
                appointments.Add(appointment);
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
        //This metod should be moved to Appointment service
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
        public static int GetScheduledAppointmentsCount (int ID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);

            string getQuerry = "SELECT COUNT(*) as Number " +
                "FROM [MedicalAction] " +
                $"WHERE PatientID = {ID} AND DateTime > '{startDate.ToString("yyyy-MM-dd HH:mm:ss.000")}'";

            var selection = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuerry);
            return Convert.ToInt32(((object[])selection[0])[0]);
        }
    }
}

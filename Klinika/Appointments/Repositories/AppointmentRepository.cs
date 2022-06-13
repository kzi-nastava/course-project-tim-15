using Klinika.Appointments.Interfaces;
using Klinika.Appointments.Models;
using Klinika.Core;
using Klinika.Core.Database;
using Klinika.Login;
using Klinika.Schedule;
using Klinika.Schedule.Models;
using System.Data;
using System.Globalization;
using static Klinika.Users.Models.User;

namespace Klinika.Appointments.Repositories
{
    internal class AppointmentRepository : Repository, IScheduledAppointmentsRepo, IAppointmentRepo, IBaseAppointmentRepo, IAntiTrollRepo
    {
        public List<Appointment> appointments { get; set; }
        public void DeleteFromList(int ID)
        {
            appointments.Where(x => x.id == ID).FirstOrDefault().isDeleted = true;
        }

        public AppointmentRepository() : base()
        {
            appointments = GetAll();
        }

        public List<Appointment> GetAll()
        {
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction]";

            var result = database.ExecuteSelectCommand(getAllQuerry);
            return GenerateList(result);
        }
        public List<Appointment> GetAll(int userID, RoleType role)
        {
            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime > '{DateTime.Now}' AND {roleToString} = {userID} " +
                                  $"AND IsDeleted = 0";

            var resoult = database.ExecuteSelectCommand(getAllQuerry);
            return GenerateList(resoult);
        }
        public List<Appointment> GetAll(string requestedDate, int userID, RoleType role, int days = 1)
        {
            DateTime start = DateTime.ParseExact($"{requestedDate} 00:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = start.AddDays(days);

            string roleToString = role == RoleType.DOCTOR ? "DoctorID" : "PatientID";
            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime BETWEEN '{start}' AND '{end}' AND {roleToString} = {userID} " +
                                  $"AND IsDeleted = 0";

            var result = database.ExecuteSelectCommand(getAllQuerry);
            return GenerateList(result);
        }
        public List<Appointment> GetCompleted(int PatientID)
        {
            string getCompletedQuerry = "SELECT * " +
                                        "FROM [MedicalAction] " +
                                        $"WHERE PatientID = {PatientID} AND Completed = 1";

            var result = database.ExecuteSelectCommand(getCompletedQuerry);
            return GenerateList(result);
        }
        private List<Appointment> GenerateList(List<object> input)
        {
            var output = new List<Appointment>();
            foreach (object row in input)
            {
                var appointment = new Appointment
                {
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    doctorID = Convert.ToInt32(((object[])row)[1].ToString()),
                    patientID = Convert.ToInt32(((object[])row)[2].ToString()),
                    dateTime = Convert.ToDateTime(((object[])row)[3].ToString()),
                    roomID = Convert.ToInt32(((object[])row)[4].ToString()),
                    completed = Convert.ToBoolean(((object[])row)[5].ToString()),
                    type = Convert.ToChar(((object[])row)[6].ToString()),
                    duration = DatabaseConnection.CheckNull<int>(((object[])row)[7]),
                    urgent = DatabaseConnection.CheckNull<bool>(((object[])row)[8]),
                    description = DatabaseConnection.CheckNull<string>(((object[])row)[9]),
                    isDeleted = DatabaseConnection.CheckNull<bool>(((object[])row)[10])
                };
                output.Add(appointment);
            }
            return output;
        }

        public void Create(Appointment appointment)
        {
            string createQuery = "INSERT INTO [MedicalAction] " +
                "(DoctorID,PatientID,DateTime,RoomID,Completed,Type,Duration,Urgent,Description,IsDeleted) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@DoctorID,@PatientID,@DateTime,@RoomID,@Completed,@Type,@Duration,@Urgent,@Description,@IsDeleted)";


            appointment.id = (int)database.ExecuteNonQueryScalarCommand(
                createQuery,
                ("@DoctorID", appointment.doctorID),
                ("@PatientID", appointment.patientID),
                ("@DateTime", appointment.dateTime),
                ("@RoomID", appointment.roomID),
                ("@Completed", appointment.completed),
                ("@Type", appointment.type),
                ("@Duration", appointment.duration),
                ("@Urgent", appointment.urgent),
                ("@Description", appointment.description),
                ("@IsDeleted", appointment.isDeleted));

            appointments.Add(appointment);
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
                ("@ID", appointment.id),
                ("@DoctorID", appointment.doctorID),
                ("@PatientID", appointment.patientID),
                ("@DateTime", appointment.dateTime),
                ("@RoomID", appointment.roomID),
                ("@Completed", appointment.completed),
                ("@Type", appointment.type),
                ("@Duration", appointment.duration),
                ("@Urgent", appointment.urgent),
                ("@Description", appointment.description),
                ("@IsDeleted", appointment.isDeleted));

            appointments.Remove(appointments.Where(x => x.id == appointment.id).FirstOrDefault());
            appointments.Add(appointment);
        }
        public void Delete(int ID)
        {
            string deleteQuerry = "UPDATE [MedicalAction] SET IsDeleted = 1 WHERE ID = @ID";
            database.ExecuteNonQueryCommand(deleteQuerry, ("@ID", ID));
        }

        public int GetScheduledAppointmentsCount(int ID)
        {
            DateTime startDate = DateTime.Now.AddDays(-30);

            string getQuerry = "SELECT COUNT(*) as Number " +
                "FROM [MedicalAction] " +
                $"WHERE PatientID = {ID} AND DateTime > '{startDate.ToString("yyyy-MM-dd HH:mm:ss.000")}'";

            var selection = database.ExecuteSelectCommand(getQuerry);
            return Convert.ToInt32(((object[])selection[0])[0]);
        }
        public List<string> GetDescriptions(int patientID)
        {
            var descriptions = new List<string>();

            string getDescriptionsQuerry = "SELECT Description " +
                                 "FROM [PatientRequest] " +
                                 $"WHERE PatientID = {patientID}";

            var resoult = database.ExecuteSelectCommand(getDescriptionsQuerry);
            foreach (object row in resoult)
            {
                descriptions.Add(DatabaseConnection.CheckNull<string>(((object[])row)[0]));
            }
            return descriptions;
        }
        public List<TimeSlot> GetOccupiedTimeSlotsPerDoctor(TimeSlot span, int doctorID)
        {
            List<TimeSlot> scheduledAppointments = new List<TimeSlot>();
            string getInSpanQuery = "SELECT DateTime,Duration " +
                                    "FROM [MedicalAction] " +
                                    "WHERE DoctorID = @doctorId AND " +
                                    "DateTime BETWEEN @start AND @end " +
                                    "ORDER BY DateTime";
            DataTable retrieved = database.CreateTableOfData(getInSpanQuery,
                ("@doctorId", doctorID), ("@start", span.from), ("@end", span.to));
            foreach (DataRow row in retrieved.Rows)
            {
                DateTime from = DateTime.Parse(row["DateTime"].ToString());
                scheduledAppointments.Add(new TimeSlot(from, from.AddMinutes(Convert.ToInt32(row["Duration"]))));
            }
            return scheduledAppointments;
        }
    }
}
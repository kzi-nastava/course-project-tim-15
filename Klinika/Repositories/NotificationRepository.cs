using Klinika.Data;
using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Repositories
{
    internal class NotificationRepository : Repository
    {
        public static List<Notification> Get(Patient patient)
        {
            var notifications = new List<Notification>();
            DateTime time = DateTime.Now.AddMinutes(patient.NotificationOffset);
            string getQuerry = "SELECT * " +
                "FROM [Notification] " +
                "WHERE [Notification].UserID = @userID AND [Notification].DateTime <= @dateTime AND [Notification].IsNotified = 0";
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuerry,
                                            ("@userId", patient.ID),
                                            ("@dateTime", time));

            foreach (object row in resoult)
            {
                var notification = new Notification(
                    Convert.ToInt32(((object[])row)[0]),
                    Convert.ToInt32(((object[])row)[1]),
                    ((object[])row)[2].ToString(),
                    Convert.ToDateTime(((object[])row)[4]));
                notifications.Add(notification);
            }
            return notifications;
        }
        public static void Send(Notification notification)
        {
            string sendQuery = "INSERT INTO [Notification] (UserID,Message,IsNotified,DateTime) " +
                               "VALUES(@userID,@message,@isNotified,@dateTime)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(sendQuery,
                                            ("@userId", notification.userId),
                                            ("@message", notification.message),
                                            ("@isNotified", notification.isNotified),
                                            ("@dateTime", notification.dateTime));
        }
        public static void Modify (int id)
        {
            string modifyQuery = "UPDATE [Notification] SET " +
               "IsNotified = 1 " +
               "WHERE ID = @Id";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@Id", id));
        }
    }
}

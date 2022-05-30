using Klinika.Models;
using Klinika.Data;

namespace Klinika.Repositories
{
    internal class NotificationRepository : Repository
    {
        public static void Send(Notification notification)
        {
            string sendQuery = "INSERT INTO [Notification] (UserID,Message,IsNotified,DateTime) " +
                               "VALUES(@userID,@message,@isNotified,@dateTime)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(sendQuery,
                                            ("@userId", notification.userId),
                                            ("@message", notification.message),
                                            ("@isNotified", notification.isNotified),
                                            ("@dateTime", notification.DateTime));
        }
    }
}

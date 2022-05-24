using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Data;

namespace Klinika.Repositories
{
    internal class NotificationRepository : Repository
    {
        public static void Send(Notification notification)
        {
            string sendQuery = "INSERT INTO [Notification] (UserID,Message,IsNotified) " +
                               "VALUES(@userID,@message,@isNotified)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(sendQuery,
                                            ("@userId", notification.userId),
                                            ("@message", notification.message),
                                            ("@isNotified", notification.isNotified));
        }
    }
}

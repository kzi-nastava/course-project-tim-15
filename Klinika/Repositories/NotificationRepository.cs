using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;

namespace Klinika.Repositories
{
    internal class NotificationRepository : Repository
    {
        private static NotificationRepository? instance;
        public static NotificationRepository GetInstance()
        {
            if (instance == null) instance = new NotificationRepository();
            return instance;
        }

        public void Send(Notification notification)
        {
            string sendQuery = "INSERT INTO [Notification] (UserID,Message,IsNotified) " +
                               "VALUES(@userID,@message,@isNotified)";
            database.ExecuteNonQueryCommand(sendQuery,
                                            ("@userId", notification.userId),
                                            ("@message", notification.message),
                                            ("@isNotified", notification.isNotified));
        }
    }
}

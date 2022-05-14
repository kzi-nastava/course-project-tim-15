using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Data;

namespace Klinika.Models
{
    internal class Notification
    {
        public int userId { get; set; }
        public string message{ get; set; }
        public bool isNotified { get; set; }

        public Notification(int userId, string message)
        {
            this.userId = userId;
            this.message = message;
            isNotified = false;
        }

        public void Send()
        {
            string sendQuery = "INSERT INTO [Notification] (UserID,Message,IsNotified) " +
                               "VALUES(@userID,@message,@isNotified)";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(sendQuery,
                                            ("@userId", userId),
                                            ("@message", message),
                                            ("@isNotified", isNotified));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Data;
using Klinika.Repositories;

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

    }
}

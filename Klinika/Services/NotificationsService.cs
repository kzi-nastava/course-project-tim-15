using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class NotificationsService
    {
        public static void Send(Notification notification)
        {
            NotificationRepository.Send(notification);
        }
    }
}

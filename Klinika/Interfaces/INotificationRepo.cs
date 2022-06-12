using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface INotificationRepo
    {
        public void Send(Notification notification);
        public void Modify(int id);
    }
}

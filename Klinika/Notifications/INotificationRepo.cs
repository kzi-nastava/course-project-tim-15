using Klinika.Users.Models;

namespace Klinika.Notifications
{
    public interface INotificationRepo
    {
        public void Create(Notification notification);
        public void Modify(int id);
        List<Notification> Get(Patient patient);
    }
}

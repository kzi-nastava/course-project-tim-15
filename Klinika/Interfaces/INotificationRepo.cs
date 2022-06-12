using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Interfaces
{
    public interface INotificationRepo
    {
        public void Create(Notification notification);
        public void Modify(int id);
        List<Notification> Get(Patient patient);
    }
}

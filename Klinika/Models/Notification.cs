namespace Klinika.Models
{
    internal class Notification
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string message{ get; set; }
        public bool isNotified { get; set; }
        public DateTime dateTime { get; set; }

        public Notification(int userId, string message)
        {
            this.userId = userId;
            this.message = message;
            isNotified = false;
            dateTime = DateTime.Now;
        }
        public Notification(int userId, string message, DateTime dateTime)
        {
            this.userId = userId;
            this.message = message;
            isNotified = false;
            this.dateTime = dateTime;
        }
        public Notification(int id, int userId, string message, DateTime dateTime)
        {
            this.id = id;
            this.userId = userId;
            this.message = message;
            isNotified = false;
            this.dateTime = dateTime;
        }

    }
}

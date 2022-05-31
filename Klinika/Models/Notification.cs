namespace Klinika.Models
{
    internal class Notification
    {
        public int ID { get; set; }
        public int userId { get; set; }
        public string message{ get; set; }
        public bool isNotified { get; set; }
        public DateTime DateTime { get; set; }

        public Notification(int userId, string message)
        {
            this.userId = userId;
            this.message = message;
            isNotified = false;
            DateTime = DateTime.Now;
        }
        public Notification(int userId, string message, DateTime dateTime)
        {
            this.userId = userId;
            this.message = message;
            isNotified = false;
            DateTime = dateTime;
        }
        public Notification(int id, int userId, string message, DateTime dateTime)
        {
            ID = id;
            this.userId = userId;
            this.message = message;
            isNotified = false;
            DateTime = dateTime;
        }

    }
}

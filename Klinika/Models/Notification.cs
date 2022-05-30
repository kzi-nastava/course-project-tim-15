namespace Klinika.Models
{
    internal class Notification
    {
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

    }
}

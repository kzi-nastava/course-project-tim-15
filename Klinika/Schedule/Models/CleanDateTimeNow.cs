namespace Klinika.Schedule.Models
{
    internal class CleanDateTimeNow
    {
        public DateTime cleanNow { get; }

        public CleanDateTimeNow()
        {
            cleanNow = DateTime.Now;
            cleanNow = cleanNow.AddMilliseconds(-cleanNow.Millisecond);
            cleanNow = cleanNow.AddSeconds(-cleanNow.Second);
        }
    }
}

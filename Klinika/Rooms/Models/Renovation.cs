namespace Klinika.Rooms.Models
{
    public class Renovation
    {
        public int id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public int advanced { get; set; }
        public int secondId { get; set; }
        public int secondType { get; set; }
        public int secondNumber { get; set; }
    }
}

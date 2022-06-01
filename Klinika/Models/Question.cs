namespace Klinika.Models
{
    public class Question
    {
        public enum Types { DOCTOR = 'D', CLINIC = 'C'}
        public int ID { get; set; }
        public string Context { get; set; }
        public char Type { get; set; }

        public Question(int id, string context, Types type)
        {
            ID = id;
            Context = context;
            Type = (char)type;
        }
    }
}

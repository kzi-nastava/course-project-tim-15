namespace Klinika.Questionnaries.Models
{
    public class Question
    {
        public enum Types { DOCTOR = 'D', CLINIC = 'C' }
        public int id { get; set; }
        public string context { get; set; }
        public char type { get; set; }

        public Question(int id, string context, Types type)
        {
            this.id = id;
            this.context = context;
            this.type = (char)type;
        }
    }
}

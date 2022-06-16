namespace Klinika.Questionnaries.Models
{
    public class Grades
    {
        public int questionnaireID { get; set; }
        public int targetID { get; set; }
        public string targetName { get; set; }
        public char type { get; set; }
        public double avgGrade { get; set; }
    }
}

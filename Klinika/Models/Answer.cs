
namespace Klinika.Models
{
    internal class Answer
    {
        public int QuestionnaireID { get; set; }
        public int QuestionID { get; set; }
        public int Grade { get; set; }
        
        public Answer(int questionID, int grade)
        {
            QuestionnaireID = -1;
            QuestionID = questionID;
            Grade = grade;
        }
    }
}

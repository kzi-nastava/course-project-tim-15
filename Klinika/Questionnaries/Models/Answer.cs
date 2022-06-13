namespace Klinika.Questionnaries.Models
{
    internal class Answer
    {
        public int questionnaireID { get; set; }
        public int questionID { get; set; }
        public int grade { get; set; }

        public Answer(int questionID, int grade)
        {
            questionnaireID = -1;
            this.questionID = questionID;
            this.grade = grade;
        }
    }
}

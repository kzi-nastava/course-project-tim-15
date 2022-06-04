using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using MQuestionnaire = Klinika.Models.Questionnaire;

namespace Klinika.GUI.Patient
{
    public partial class Questionnaire : Form
    {
        private readonly Form parent;
        private readonly Question.Types type;
        private MQuestionnaire questionnaire;
        private int appointmentID;
        private int targetID;
        private int patientID;

        #region Form
        public Questionnaire(Form parent, int patientID, Question.Types type, int appointmentID = -1, int targetID = -1)
        {
            InitializeComponent();
            this.parent = parent;
            this.type = type;
            this.appointmentID = appointmentID;
            this.targetID = targetID;
            this.patientID = patientID;
         }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            QuestionsTable.Fill(QuestionnaireService.GetQuestions(type));
            SetGradeButton.Enabled = false;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        #endregion
        private List<Answer> CollectData()
        {
            var answers = QuestionsTable.GetAll();
            string comment = CommentTextBox.Text;
            questionnaire = new MQuestionnaire(patientID, comment, appointmentID, targetID);
            return answers;
        }
        private void SendButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to send this Questionnaire?")) return;
            QuestionnaireService.Send(questionnaire, CollectData());
            Close();
        }
        private void SetGradeButtonClick(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(GradeNumericUpDown.Value);
            QuestionsTable.SetGrade(grade);
        }
        private void QuestionsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            SetGradeButton.Enabled = true;
        }
    }
}

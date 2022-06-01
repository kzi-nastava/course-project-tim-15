using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using System.Data;
using MQuestionnaire = Klinika.Models.Questionnaire;

namespace Klinika.GUI.Patient
{
    public partial class Questionnaire : Form
    {
        private readonly PatientMain parent;
        private readonly Question.Types type;
        private MQuestionnaire questionnaire;
        private int appointmentID;
        private int targetID;

        #region Form
        public Questionnaire(PatientMain parent, Question.Types type, int appointmentID = -1, int targetID = -1)
        {
            InitializeComponent();
            this.parent = parent;
            this.type = type;
            this.appointmentID = appointmentID;
            this.targetID = targetID;
         }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            FillQuestionsTable(QuestionnaireService.GetQuestions(type));
            SetGradeButton.Enabled = false;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        #endregion

        private void FillQuestionsTable(List<Question> questions)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Question");
            dataTable.Columns.Add("Grade");
            if (questions == null) return;
            foreach (Question question in questions)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["ID"] = question.id;
                newRow["Question"] = question.context;
                newRow["Grade"] = 1;
                dataTable.Rows.Add(newRow);
            }
            QuestionsTable.DataSource = dataTable;
            QuestionsTable.Columns["ID"].Width = 25;
            QuestionsTable.Columns["Grade"].Width = 45;
            QuestionsTable.ClearSelection();
        }
        private List<Answer> ColectData()
        {
            var answers = new List<Answer>();
            foreach (DataGridViewRow row in QuestionsTable.Rows)
            {
                int questionID = Convert.ToInt32(row.Cells[0].Value);
                int grade = Convert.ToInt32(row.Cells[2].Value);
                answers.Add(new Answer(questionID, grade));
            }
            string comment = CommentTextBox.Text;
            questionnaire = new MQuestionnaire(parent.patient.id, comment, appointmentID, targetID);
            return answers;
        }
        private void SendButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to send this Questionnaire?")) return;
            var result = ColectData();
            QuestionnaireService.Send(questionnaire, result);
            Close();
        }
        private void SetGradeButtonClick(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(GradeNumericUpDown.Value);
            QuestionsTable.SelectedRows[0].Cells["Grade"].Value = grade;
        }
        private void QuestionsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            SetGradeButton.Enabled = true;
        }
    }
}

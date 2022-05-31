using Klinika.Models;
using System.Data;
using Klinika.Services;
using MQuestionnaire = Klinika.Models.Questionnaire;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class Questionnaire : Form
    {
        private readonly PatientMain Parent;
        private readonly Question.Types Type;
        private MQuestionnaire This;
        private int AppointmentID;
        private int TargetID;

        #region Form
        public Questionnaire(PatientMain parent, Question.Types type, int appointmentID = -1, int targetID = -1)
        {
            InitializeComponent();
            Parent = parent;
            Type = type;
            AppointmentID = appointmentID;
            TargetID = targetID;
         }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            FillQuestionsTable(QuestionnaireService.GetQuestions(Type));
            SendButton.Enabled = false;
            SetGradeButton.Enabled = false;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
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

                newRow["ID"] = question.ID;
                newRow["Question"] = question.Context;
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
            This = new MQuestionnaire(Parent.Patient.ID, comment, AppointmentID, TargetID);
            return answers;
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to send this Questionnaire?")) return;
            var result = ColectData();
            QuestionnaireService.Send(This, result);
        }

        private void SetGradeButtonClick(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(GradeNumericUpDown.Value);
            QuestionsTable.SelectedRows[0].Cells["Grade"].Value = grade;
        }

        private void CommentTextBoxTextChanged(object sender, EventArgs e)
        {
            if (CommentTextBox.Text == "") SendButton.Enabled = false;
            else SendButton.Enabled = true;
        }

        private void QuestionsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            SetGradeButton.Enabled = true;
        }
    }
}

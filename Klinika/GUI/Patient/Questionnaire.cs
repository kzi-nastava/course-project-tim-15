using Klinika.Models;
using System.Data;
using Klinika.Services;

namespace Klinika.GUI.Patient
{
    public partial class Questionnaire : Form
    {
        private readonly PatientMain Parent;
        private readonly Question.Types Type;

        #region Form
        public Questionnaire(PatientMain parent, Question.Types type)
        {
            InitializeComponent();
            Parent = parent;
            Type = type;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            FillQuestionsTable(QuestionnaireService.GetQuestions(Type));
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

        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void NotificationsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

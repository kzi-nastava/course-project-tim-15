using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    internal class QuestionsTable : Base.TableBase<Question>
    {
        public override void Fill(List<Question> questions)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Question");
            dataTable.Columns.Add("Grade");
            DataSource = dataTable;
            Columns["ID"].Width = 25;
            Columns["Grade"].Width = 70;
            if (questions == null) return;
            foreach (Question question in questions) Insert(question);
            ClearSelection();
        }
        private void Insert(Question question)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = question.id;
            newRow["Question"] = question.context;
            newRow["Grade"] = 1;
            dt.Rows.Add(newRow);
        }
        public List<Answer> GetAll()
        {
            var answers = new List<Answer>();
            foreach (DataGridViewRow row in Rows)
            {
                int questionID = Convert.ToInt32(row.Cells["ID"].Value);
                int grade = Convert.ToInt32(row.Cells["Grade"].Value);
                answers.Add(new Answer(questionID, grade));
            }
            return answers;
        }
        public void SetGrade (int grade)
        {
            SelectedRows[0].Cells["Grade"].Value = grade;
        }
    }
}

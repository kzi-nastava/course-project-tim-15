using Klinika.Questionnaries.Models;
using System.Data;

namespace Klinika.Forms
{
    public class QuestionnaireTable : Base.TableBase<Grades>
    {
        private List<Grades> grades;
        public QuestionnaireTable() : base()
        {
            grades = new List<Grades>();
        }
        public override void Fill(List<Grades> grades)
        {
            this.grades = grades;

            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("QuestionnaireID");
            drugsData.Columns.Add("TargetID");
            drugsData.Columns.Add("TargetName");
            drugsData.Columns.Add("Type");
            drugsData.Columns.Add("AvgGrade");

            foreach (Grades grade in grades)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["QuestionnaireID"] = grade.questionnaireID;
                newRow["TargetID"] = grade.targetID;
                newRow["TargetName"] = grade.targetName;
                newRow["Type"] = grade.type;
                newRow["AvgGrade"] = grade.avgGrade;
                drugsData.Rows.Add(newRow);
            }

            DataSource = drugsData;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            return Convert.ToInt32(GetCellValue("QuestionnaireID"));
        }
        public int GetSelectedTarget()
        {
            return Convert.ToInt32(GetCellValue("TargetID"));
        }
        public Grades GetSelectedQuestionnaire()
        {
            return grades.Where(x => x.questionnaireID == GetSelectedId()).FirstOrDefault();
        }
    }
}

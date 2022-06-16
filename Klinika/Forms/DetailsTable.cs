using System.Data;
using Klinika.Questionnaries.Models;

namespace Klinika.Forms
{
    public class DetailsTable : Base.TableBase<Details>
    {
        public DetailsTable() : base()
        {
        }
        public override void Fill(List<Details> details)
        {
            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("Question ID");
            drugsData.Columns.Add("Question");
            drugsData.Columns.Add("5");
            drugsData.Columns.Add("4");
            drugsData.Columns.Add("3");
            drugsData.Columns.Add("2");
            drugsData.Columns.Add("1");
            drugsData.Columns.Add("AVG");

            foreach (Details detail in details)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["Question ID"] = detail.qID;
                newRow["Question"] = detail.text;
                newRow["5"] = detail.g5;
                newRow["4"] = detail.g4;
                newRow["3"] = detail.g3;
                newRow["2"] = detail.g2;
                newRow["1"] = detail.g1;
                newRow["AVG"] = detail.CalculateAvg();
                drugsData.Rows.Add(newRow);
            }

            DataSource = drugsData;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            return Convert.ToInt32(GetCellValue("AVG"));
        }
    }
}

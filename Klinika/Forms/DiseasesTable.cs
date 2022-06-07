using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class DiseasesTable : Base.ReadonlyTableBase<Disease>
    {
        public override void Fill(List<Disease> items)
        {
            DataTable diseasesData = new DataTable();
            diseasesData.Columns.Add("ID");
            diseasesData.Columns.Add("Name");
            diseasesData.Columns.Add("Description");
            diseasesData.Columns.Add("Date");

            foreach (Disease disease in items)
            {
                DataRow newRow = diseasesData.NewRow();
                newRow["ID"] = disease.id;
                newRow["Name"] = disease.name;
                newRow["Description"] = disease.description;
                newRow["Date"] = disease.dateDiagnosed.ToString("yyyy/MM/dd");
                diseasesData.Rows.Add(newRow);
            }

            DataSource = diseasesData;
            Columns[0].Width = 30;
            ClearSelection();
        }
    }
}

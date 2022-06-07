using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class AnamnesesTable : Base.ViewOnlyTableBase<Anamnesis>
    {
        public override void Fill(List<Anamnesis> items)
        {
            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("ID");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");

            foreach (Anamnesis anamnesis in items)
            {
                DataRow newRow = anamnesesData.NewRow();
                newRow["ID"] = anamnesis.id;
                newRow["Description"] = anamnesis.description;
                newRow["Symptoms"] = anamnesis.symptoms;
                newRow["Conclusion"] = anamnesis.conclusion;
                anamnesesData.Rows.Add(newRow);
            }

            DataSource = anamnesesData;
            Columns[0].Width = 30;
            ClearSelection();
        }
    }
}

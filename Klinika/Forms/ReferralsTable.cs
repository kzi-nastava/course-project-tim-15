using Klinika.Models;
using System.Data;
using Klinika.Forms.Base;
using Klinika.Models;

namespace Klinika.Forms
{
    public class ReferralsTable : TableBase<Referral>
    {
        public override void Fill(List<Referral> referrals)
        {
            DataTable referralsTable = new DataTable();
            referralsTable.Columns.Add("ID");
            referralsTable.Columns.Add("Doctor");
            referralsTable.Columns.Add("Specialization");
            referralsTable.Columns.Add("Date issued");
            referralsTable.Columns.Add("Used");

            foreach (Referral referrral in referrals)
            {
                DataRow newRow = referralsTable.NewRow();
                newRow["ID"] = referrral.id;
                newRow["Doctor"] = referrral.doctorIdAndFullName;
                newRow["Specialization"] = referrral.specializationIdAndName;
                newRow["Date issued"] = referrral.date;
                newRow["Used"] = referrral.used;
                referralsTable.Rows.Add(newRow);
            }
            DataSource = referralsTable;
            ClearSelection();
        }

    }
}

using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Users.Models;
using Klinika.Questionnaries.Services;
using Klinika.Core.Dependencies;

namespace Klinika.Forms
{
    internal class DoctorsTable : Base.TableBase<Doctor>
    {
        private readonly QuestionnaireService? questionnaireService;
        public DoctorsTable() : base() => questionnaireService = StartUp.serviceProvider.GetService<QuestionnaireService>();
        public override void Fill(List<Doctor> doctors)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");
            DataSource = dataTable;
            if (doctors == null) return;
            foreach (Doctor doctor in doctors) Insert(doctor);
            ClearSelection();
        }
        private void Insert(Doctor doctor)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["Doctor ID"] = doctor.id;
            newRow["Name"] = doctor.name;
            newRow["Surname"] = doctor.surname;
            newRow["Specialization"] = doctor.specialization;
            newRow["Grade"] = string.Format("{0:0.00}", questionnaireService.GetDoctorGrade(doctor.id));
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID() => Convert.ToInt32(GetCellValue("Doctor ID"));
    }
}

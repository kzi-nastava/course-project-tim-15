using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Users.Services;
using Klinika.MedicalRecords.Models;
using Klinika.Appointments.Models;
using Klinika.Appointments.Services;
using Klinika.Core.Dependencies;

namespace Klinika.Forms
{
    internal class MedicalRecordTable : Base.TableBase<Anamnesis>
    {
        private readonly AppointmentService? appointmentService;
        private readonly DoctorService? doctorService;
        private List<Appointment> appointments { get { return appointmentService.GetCompleted(patientID); } }
        private int patientID;
        public MedicalRecordTable() : base()
        {
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
        }
        public void Fill(List<Anamnesis> anamneses, int patientID)
        {
            this.patientID = patientID;
            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("Appointment ID");
            anamnesesData.Columns.Add("Doctor");
            anamnesesData.Columns.Add("Doctor Specialization");
            anamnesesData.Columns.Add("DateTime");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");
            DataSource = anamnesesData;
            foreach (Anamnesis anamnesis in anamneses) Insert(anamnesis);

            ClearSelection();
        }
        public override void Fill(List<Anamnesis> items)
        {
            throw new NotImplementedException();
        }
        public void Insert(Anamnesis anamnesis)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            Appointment appointment = appointments.Where(x => x.id == anamnesis.medicalActionID).FirstOrDefault();
            newRow["Appointment ID"] = anamnesis.medicalActionID;
            newRow["Doctor"] = doctorService.GetFullName(appointment.doctorID);
            newRow["Doctor Specialization"] = doctorService.GetSpecialization(appointment.doctorID);
            newRow["DateTime"] = appointment.dateTime;
            newRow["Description"] = anamnesis.description;
            newRow["Symptoms"] = anamnesis.symptoms;
            newRow["Conclusion"] = anamnesis.conclusion;
            dt.Rows.Add(newRow);
        }
        private int GetSelectedID()
        {
            return Convert.ToInt32(GetCellValue("Appointment ID"));
        }
        public Appointment GetSelected()
        {
            return appointments.Where(x => x.id == GetSelectedID()).First();
        }
    }
}

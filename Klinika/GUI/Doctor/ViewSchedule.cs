using Klinika.Dependencies;
using Klinika.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class ViewSchedule : Form
    {
        private readonly DoctorScheduleService? scheduleService;
        internal readonly Main parent;
        private Roles.Doctor doctor { get { return parent.doctor; } }
        public ViewSchedule(Main parent)
        {
            InitializeComponent();
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitScheduleTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitScheduleTab()
        {
            var scheduled = scheduleService.GetAppointments(ScheduleDatePicker.Value, doctor.id, 3);
            ScheduleTable.Fill(scheduled);
            ViewMedicalRecordButton.Enabled = false;
            PerformButton.Enabled = false;
        }
        private void ScheduleDatePickerValueChanged(object sender, EventArgs e)
        {
            InitScheduleTab();
        }
        private void ScheduleTableSelectionChanged(object sender, EventArgs e)
        {
            ViewMedicalRecordButton.Enabled = true;
            try
            {
                var selected = ScheduleTable.GetSelected();
                bool canBePerformed = !selected.completed
                    && selected.dateTime.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd");

                if (canBePerformed)
                {
                    PerformButton.Enabled = true;
                    return;
                }
            }
            catch { }
            PerformButton.Enabled = false;
        }
        private void ViewMedicalRecordButtonClick(object sender, EventArgs e)
        {
            new MedicalRecord(this, ScheduleTable.GetSelected()).Show();
        }
        private void PerformButtonClick(object sender, EventArgs e)
        {
            var selected = ScheduleTable.GetSelected();
            if (selected.IsExamination()) new MedicalRecord(this, selected, false).Show();
            else new DynamicEquipment(this, selected).Show();
        }
    }
}
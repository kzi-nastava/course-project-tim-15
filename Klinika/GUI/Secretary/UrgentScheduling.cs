using Klinika.Appointments.Models;
using Klinika.Appointments.Services;
using Klinika.Core;
using Klinika.Core.Database;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Notifications;
using Klinika.Schedule.Models;
using Klinika.Schedule.Services;
using Klinika.Users.Models;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Secretary
{
    public partial class UrgentScheduling : Form
    {
        private List<Rescheduling> reschedulings;
        private readonly DoctorService doctorService;
        private readonly ScheduleService scheduleService;
        private readonly SpecializationService specializationService;
        private readonly AppointmentService appointmentService;
        private readonly NotificationService notificationService;
        public UrgentScheduling()
        {
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
            scheduleService = StartUp.serviceProvider.GetService<ScheduleService>();
            specializationService = StartUp.serviceProvider.GetService<SpecializationService>();
            notificationService = StartUp.serviceProvider.GetService<NotificationService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            InitializeComponent();
        }

        private void ScheduleButton_Click(object sender, EventArgs e) => TryScheduling();

        private void UrgentScheduling_Load(object sender, EventArgs e) => FillInitialSelectionFields();

        private void FillInitialSelectionFields()
        {
            UIUtilities.FillPatientSelectionList(patientSelection);
            FillSpecializationSelectionList();
            patientSelection.SelectedIndex = 0;
            specializationSelection.SelectedIndex = 0;
        }

        private void TryScheduling()
        {
            try
            {
                if (appointmentSelection.Items.Count != 0)
                {
                    ScheduleWithRescheduling();
                }
                else
                {
                    int specializationId = UIUtilities.ExtractID(specializationSelection.SelectedItem.ToString());
                    (Users.Models.Doctor suitable, TimeSlot firstAvailable) = doctorService.GetSuitableUnderTwoHours(specializationId);
                    if (suitable == null)
                    {
                        MessageBoxUtilities.ShowInformationMessage("Unable to find available doctor under two hours. " +
                                                                "Please select one of the given appointment times to reschedule.");
                        FillAppointmentSelectionList();
                        appointmentSelection.SelectedIndex = 0;
                        appointmentSelection.Enabled = true;
                        specializationSelection.Enabled = false;
                        return;
                    }
                    ScheduleForSuitableDoctor(suitable, firstAvailable);
                }
            }
            catch(DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void ScheduleForSuitableDoctor(Users.Models.Doctor suitable,TimeSlot firstAvailable)
        {
            doctorField.Text = suitable.id + ". " + suitable.name + " " + suitable.surname;

            appointmentSelection.Text = firstAvailable.from.ToString();

            appointmentService.Create(new Appointment(-1, suitable.id,
                                        UIUtilities.ExtractID(patientSelection.SelectedItem.ToString()),
                                        firstAvailable.from,
                                        1,
                                        false,
                                        'E',
                                        15,
                                        true,
                                        "",
                                        false));
            MessageBoxUtilities.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            appointmentSelection.Enabled = false;
            scheduleButton.Enabled = false;
        }

        private void FillAppointmentSelectionList()
        {
            reschedulings = scheduleService.
            GetMostMovableAppointments(UIUtilities.ExtractID(specializationSelection.SelectedItem.ToString()));
            foreach(Rescheduling rescheduling in reschedulings)
            {
                string appointmentStart = rescheduling.appointment.dateTime.ToString("yyyy-MM-dd HH:mm");
                appointmentSelection.Items.Add(new EnhancedComboBoxItem(appointmentStart, rescheduling));
            }
        }

        public void FillSpecializationSelectionList()
        {
            List<Specialization> available = specializationService.GetAllAvailableSpecializations();

            foreach (Specialization specialization in available)
            {
                specializationSelection.Items.Add(specialization.id + ". " + specialization.name);
            }
        }

        private void ScheduleWithRescheduling()
        {
            Rescheduling selected = (Rescheduling)((appointmentSelection.SelectedItem as EnhancedComboBoxItem).value);
            Appointment toReschedule = selected.appointment;
            DateTime previousAppointment = toReschedule.dateTime;
            toReschedule.dateTime = selected.to;
            appointmentService.Modify(toReschedule);
            Appointment urgent = new Appointment(-1, toReschedule.doctorID, UIUtilities.ExtractID(patientSelection.SelectedItem.ToString()),
                                                 previousAppointment,
                                                 1, false, 'E', 15, true,"", false);
            appointmentService.Create(urgent);
            NotifyAll(toReschedule,previousAppointment);
            Users.Models.Doctor doctor = doctorService.GetById(toReschedule.doctorID);
            doctorField.Text = doctor.GetIdAndFullName();
            appointmentSelection.Text = previousAppointment.ToString("yyyy-MM-dd HH:mm");
            MessageBoxUtilities.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            scheduleButton.Enabled = false;
        }

        private void NotifyAll(Appointment selected,DateTime previousAppointment)
        {
            string message = "Appointment number " + selected.id + " modified! New time: " + selected.dateTime.ToString("yyyy-MM-dd HH:mm");

            notificationService.Send(new Notification(selected.patientID, message));
            notificationService.Send(new Notification(selected.doctorID, message));
            message = "New urgent appointment on " + previousAppointment.ToString("yyyy-MM-dd HH:mm") + ".";
            notificationService.Send(new Notification(selected.doctorID, message));
        }
    }
}

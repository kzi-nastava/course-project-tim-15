using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Models;
using Klinika.Exceptions;
using Klinika.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class UrgentScheduling : Form
    {
        private List<Rescheduling> reschedulings;

        public UrgentScheduling()
        {
            InitializeComponent();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            TryScheduling();
        }

        private void UrgentScheduling_Load(object sender, EventArgs e)
        {
            FillInitialSelectionFields();
        }

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
                    (Roles.Doctor suitable, TimeSlot firstAvailable) = DoctorService.GetSuitableUnderTwoHours(specializationId);
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

        private void ScheduleForSuitableDoctor(Roles.Doctor suitable,TimeSlot firstAvailable)
        {
            doctorField.Text = suitable.ID + ". " + suitable.Name + " " + suitable.Surname;

            appointmentSelection.Text = firstAvailable.from.ToString();

            AppointmentService.Create(new Appointment(-1, suitable.ID,
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
            reschedulings = ScheduleService.
            GetMostMovableAppointments(UIUtilities.ExtractID(specializationSelection.SelectedItem.ToString()));
            foreach(Rescheduling rescheduling in reschedulings)
            {
                string appointmentStart = rescheduling.appointment.dateTime.ToString("yyyy-MM-dd HH:mm");
                appointmentSelection.Items.Add(new EnhancedComboBoxItem(appointmentStart, rescheduling));
            }
        }

        public void FillSpecializationSelectionList()
        {
            List<Specialization> available = SpecializationService.GetAllAvailableSpecializations();

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
            AppointmentService.Modify(toReschedule);
            Appointment urgent = new Appointment(-1, toReschedule.doctorID, UIUtilities.ExtractID(patientSelection.SelectedItem.ToString()),
                                                 previousAppointment,
                                                 1, false, 'E', 15, true,"", false);
            AppointmentService.Create(urgent);
            NotifyAll(toReschedule,previousAppointment);
            Roles.Doctor doctor = DoctorService.GetById(toReschedule.doctorID);
            doctorField.Text = doctor.GetIdAndFullName();
            appointmentSelection.Text = previousAppointment.ToString("yyyy-MM-dd HH:mm");
            MessageBoxUtilities.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            scheduleButton.Enabled = false;
        }

        private void NotifyAll(Appointment selected,DateTime previousAppointment)
        {
            string message = "Appointment number " + selected.id + " modified! New time: " + selected.dateTime.ToString("yyyy-MM-dd HH:mm");

            NotificationService.Send(new Notification(selected.patientID, message));
            NotificationService.Send(new Notification(selected.doctorID, message));
            message = "New urgent appointment on " + previousAppointment.ToString("yyyy-MM-dd HH:mm") + ".";
            NotificationService.Send(new Notification(selected.doctorID, message));
        }

    }
}

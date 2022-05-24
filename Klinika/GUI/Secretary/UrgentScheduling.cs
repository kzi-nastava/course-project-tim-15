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
using Klinika.Repositories;
using Klinika.Models;
using Klinika.Roles;
using Klinika.Exceptions;

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
            UIService.FillPatientSelectionList(patientSelection);
            FillSpecializationSelectionList();
            patientSelection.SelectedIndex = 0;
            specializationSelection.SelectedIndex = 0;
        }

        private void TryScheduling()
        {
            if (appointmentSelection.Items.Count != 0)
            {
                ScheduleWithRescheduling();
            }
            else
            {
                int specializationId = UIService.ExtractID(specializationSelection.SelectedItem.ToString());
                (Roles.Doctor suitable, TimeSlot firstAvailable) = DoctorService.GetSuitableUnderTwoHours(specializationId);
                if (suitable == null)
                {
                    UIService.ShowInformationMessage("Unable to find available doctor under two hours. " +
                                                            "Please select one of the given appointment times to reschedule.");
                    FillAppointmentSelectionList();
                    appointmentSelection.SelectedIndex = 0;
                    appointmentSelection.Enabled = true;
                    specializationSelection.Enabled = false;
                    return;
                }
                ScheduleForSuitableDoctor(suitable,firstAvailable);
            }
        }

        private void ScheduleForSuitableDoctor(Roles.Doctor suitable,TimeSlot firstAvailable)
        {
            doctorField.Text = suitable.ID + ". " + suitable.Name + " " + suitable.Surname;

            appointmentSelection.Text = firstAvailable.from.ToString();
            try
            {
                AppointmentService.Create(new Appointment(-1, suitable.ID,
                                            UIService.ExtractID(patientSelection.SelectedItem.ToString()),
                                            firstAvailable.from,
                                            1,
                                            false,
                                            'E',
                                            15,
                                            true,
                                            "",
                                            false));
                UIService.ShowSuccessMessage("Urgent appointment successfully scheduled!");
                appointmentSelection.Enabled = false;
                scheduleButton.Enabled = false;
            }
            catch(DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FillAppointmentSelectionList()
        {
            reschedulings = AppointmentService.
            GetMostMovableAppointments(UIService.ExtractID(specializationSelection.SelectedItem.ToString()));
            foreach(Rescheduling rescheduling in reschedulings)
            {
                string appointmentStart = rescheduling.appointment.DateTime.ToString("yyyy-MM-dd HH:mm");
                appointmentSelection.Items.Add(new EnhancedComboBoxItem(appointmentStart, rescheduling));
            }
        }

        public void FillSpecializationSelectionList()
        {
            List<Specialization> available = SpecializationService.GetAllAvailableSpecializations();

            foreach (Specialization specialization in available)
            {
                specializationSelection.Items.Add(specialization.ID + ". " + specialization.Name);
            }
        }

        private void ScheduleWithRescheduling()
        {
            Rescheduling selected = (Rescheduling)((appointmentSelection.SelectedItem as EnhancedComboBoxItem).value);
            Appointment toReschedule = selected.appointment;
            DateTime previousAppointment = toReschedule.DateTime;
            toReschedule.DateTime = selected.to;
            AppointmentService.Modify(toReschedule);
            Appointment urgent = new Appointment(-1, toReschedule.DoctorID, UIService.ExtractID(patientSelection.SelectedItem.ToString()),
                                                 previousAppointment,
                                                 1, false, 'E', 15, true,"", false);
            AppointmentService.Create(urgent);
            NotifyAll(toReschedule,previousAppointment);
            Roles.Doctor doctor = DoctorService.GetById(toReschedule.DoctorID);
            doctorField.Text = doctor.GetIdAndFullName();
            appointmentSelection.Text = previousAppointment.ToString("yyyy-MM-dd HH:mm");
            UIService.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            scheduleButton.Enabled = false;
        }

        private void NotifyAll(Appointment selected,DateTime previousAppointment)
        {
            string message = "Appointment number " + selected.ID + " modified! New time: " + selected.DateTime.ToString("yyyy-MM-dd HH:mm");
            try
            {
                NotificationsService.Send(new Notification(selected.PatientID, message));
                NotificationsService.Send(new Notification(selected.DoctorID, message));
                message = "New urgent appointment on " + previousAppointment.ToString("yyyy-MM-dd HH:mm") + ".";
                NotificationsService.Send(new Notification(selected.DoctorID, message));
            }
            catch(DatabaseConnectionException error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}

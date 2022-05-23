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

        private Dictionary<Appointment, DateTime> appointmentRescheduleDatePairs;
        private Dictionary<int, Appointment> ordinalAppointmentPairs;
        private NotificationRepository notificationRepository;
        private AppointmentRepository appointmentRepository;
        private DoctorService doctorService;
        public UrgentScheduling()
        {
            InitializeComponent();
            notificationRepository = NotificationRepository.GetInstance();
            appointmentRepository = AppointmentRepository.GetInstance();
            doctorService = new DoctorService();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            TryScheduling();
        }

        private void FillInitialSelectionFields()
        {
            PatientRepository.FillPatientSelectionList(patientSelection);
            SecretaryService.FillSpecializationSelectionList(specializationSelection);
            patientSelection.SelectedIndex = 0;
            specializationSelection.SelectedIndex = 0;
        }

        private void UrgentScheduling_Load(object sender, EventArgs e)
        {
            FillInitialSelectionFields();
        }


        private void TryScheduling()
        {
            if (appointmentSelection.Items.Count != 0)
            {
                ScheduleWithRescheduling();
                
            }
            else
            {
                int specializationId = SecretaryService.ExtractID(specializationSelection.SelectedItem.ToString());
                (Roles.Doctor suitable, TimeSlot firstAvailable) = doctorService.GetSuitableUnderTwoHours(specializationId);
                if (suitable == null)
                {
                    SecretaryService.ShowInformationMessage("Unable to find available doctor under two hours. " +
                                                            "Please select one of the given appointment times to reschedule.");
                    FillAppointmentSelectionList();
                    appointmentSelection.SelectedIndex = 0;
                    appointmentSelection.Enabled = true;
                    specializationSelection.Enabled = false;
                }
                else
                {
                    ScheduleForSuitableDoctor(suitable,firstAvailable);
                }
            }
        }

        private void ScheduleForSuitableDoctor(Roles.Doctor suitable,TimeSlot firstAvailable)
        {
            doctorField.Text = suitable.ID + ". " + suitable.Name + " " + suitable.Surname;

            appointmentSelection.Text = firstAvailable.from.ToString();
            appointmentSelection.Enabled = false;
            appointmentRepository.Create(new Appointment(-1, suitable.ID,
                                        SecretaryService.ExtractID(patientSelection.SelectedItem.ToString()),
                                        firstAvailable.from,
                                        1,
                                        false,
                                        'E',
                                        15,
                                        true,
                                        "",
                                        false));
            SecretaryService.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            scheduleButton.Enabled = false;
        }


        private void FillAppointmentSelectionList()
        {
            ordinalAppointmentPairs = new Dictionary<int, Appointment>();
            appointmentRescheduleDatePairs = DoctorRepository.GetInstance().
            GetMostMovableAppointments(SecretaryService.ExtractID(specializationSelection.SelectedItem.ToString()),
                                           15);
            TimeSlot inTwoHours = new TimeSlot(SecretaryService.GetNow(), SecretaryService.GetNow().AddHours(2));
            int ordinal = 0;
            foreach (KeyValuePair<Appointment, DateTime> entry in appointmentRescheduleDatePairs)
            {
                if (appointmentSelection.Items.Count == 5) break;
                if(entry.Value > inTwoHours.to)
                {
                    ordinalAppointmentPairs.Add(ordinal, entry.Key);
                    appointmentSelection.Items.Add(appointmentRepository.GetById(entry.Key.ID).DateTime.ToString("yyyy-MM-dd HH:mm"));
                    ordinal++;
                }
                
            }
        }

        private void ScheduleWithRescheduling()
        {
            Appointment selected = ordinalAppointmentPairs[appointmentSelection.SelectedIndex];
            DateTime previousAppointment = selected.DateTime;
            selected.DateTime = appointmentRescheduleDatePairs[selected];
            AppointmentRepository.GetInstance().Modify(selected);
            

            Appointment urgent = new Appointment(-1, selected.DoctorID, SecretaryService.ExtractID(patientSelection.SelectedItem.ToString()),
                                                 previousAppointment,
                                                 1, false, 'E', 15, true,"", false);
            AppointmentRepository.GetInstance().Create(urgent);
            NotifyAll(selected,previousAppointment);
            Roles.Doctor doctor = DoctorRepository.GetInstance().GetById(selected.DoctorID);
            doctorField.Text = doctor.GetIdAndFullName();
            appointmentSelection.Text = previousAppointment.ToString("yyyy-MM-dd HH:mm");
            SecretaryService.ShowSuccessMessage("Urgent appointment successfully scheduled!");
            scheduleButton.Enabled = false;
        }

        private void NotifyAll(Appointment selected,DateTime previousAppointment)
        {
            string message = "Appointment number " + selected.ID + " modified! New time: " + selected.DateTime.ToString("yyyy-MM-dd HH:mm");
            new Notification(selected.PatientID, message).Send();
            new Notification(selected.DoctorID, message).Send();
            message = "New urgent appointment on " + previousAppointment.ToString("yyyy-MM-dd HH:mm") + ".";
            new Notification(selected.DoctorID, message).Send();
        }

    }
}

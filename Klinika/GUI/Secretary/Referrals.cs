using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Secretary
{
    public partial class Referrals : Form
    {

        private Referral chosenReferral;
        private readonly ReferralService referralService;
        private readonly DoctorService doctorService;
        private readonly DoctorScheduleService doctorScheduleService;
        private readonly AppointmentService appointmentService;

        public Referrals()
        {
            InitializeComponent();
            referralService = StartUp.serviceProvider.GetService<ReferralService>();
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
            doctorScheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
        }

        private void PatientSelection_SelectedIndexChanged(object sender, EventArgs e) => new ChooseReferral(this).ShowDialog();

        private void ScheduleButton_Click(object sender, EventArgs e) => ScheduleAppointmentThroughReferral();

        private void FindAvailableDoctorButton_Click(object sender, EventArgs e) => FindSuitableDoctor();

        public void SetFieldValues(Referral referral)
        {
            doctorField.Text = referral.doctorIdAndFullName;
            specializationField.Text = referral.specializationIdAndName;
            chosenReferral = referral;
        }

        public void SetCommandStates()
        {
            string chosenDoctor = doctorField.Text;
            appointmentPicker.Enabled = true;
            scheduleButton.Enabled = true;
            if (string.IsNullOrEmpty(chosenDoctor))
            {
                findAvailableDoctorButton.Enabled = true;
            }
            else
            {
                findAvailableDoctorButton.Enabled = false;
            }
        }

        private void ScheduleAppointmentThroughReferral()
        {
            int doctorId = -1;
            if (!string.IsNullOrEmpty(doctorField.Text))
            {
                doctorId = UIUtilities.ExtractID(doctorField.Text);
            }

            DateTime chosenTime = appointmentPicker.Value;
            try
            {
                if (!CreateAppointment(doctorId, chosenTime)) return;
                referralService.MarkAsUsed(chosenReferral.id);
                MessageBoxUtilities.ShowSuccessMessage("Appointment successfully scheduled!");
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private bool CreateAppointment(int doctorId, DateTime appointmentStart)
        {

            string error_message = ValidateAppointment(doctorId, appointmentStart);
            if (error_message != null)
            {
                MessageBoxUtilities.ShowErrorMessage(error_message);
                return false;
            }
            appointmentStart = appointmentStart.AddSeconds(-appointmentStart.Second);

            Appointment newAppointment = new Appointment(-1,
                                            UIUtilities.ExtractID(doctorField.Text),
                                            UIUtilities.ExtractID(patientSelection.SelectedItem.ToString()),
                                            appointmentStart, 1, false, 'E', 15, false, "", false);
            appointmentService.Create(newAppointment);
            return true;
        }

        private void FindSuitableDoctor()
        {
            try
            {
                Roles.Doctor suitableDoctor = doctorService.GetSuitable(UIUtilities.ExtractID(specializationField.Text), appointmentPicker.Value);
                if (suitableDoctor != null)
                {
                    doctorField.Text = suitableDoctor.GetIdAndFullName();
                }
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void Referrals_Load(object sender, EventArgs e) => UIUtilities.FillPatientSelectionList(patientSelection);

        public string? ValidateAppointment(int doctorID, DateTime appointmentStart)
        {
            string error_message = null;
            if (appointmentStart <= DateTime.Now)
            {
                error_message = "Selected appointment time is incorrect!";
            }

            if (doctorID == -1)
            {
                error_message = "Doctor is not selected!";
            }

            if (doctorScheduleService.IsOccupied(appointmentStart, doctorID: doctorID))
            {
                error_message = "The selected doctor is not available at the selected time!";
            }

            return error_message;
        }
    }
}

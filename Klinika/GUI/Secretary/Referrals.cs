using Klinika.Exceptions;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class Referrals : Form
    {

        private Referral chosenReferral;

        public Referrals()
        {
            InitializeComponent();
        }


        private void PatientSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            new ChooseReferral(this).ShowDialog();
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            ScheduleAppointmentThroughReferral();
        }

        private void FindAvailableDoctorButton_Click(object sender, EventArgs e)
        {
            FindSuitableDoctor();
        }

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
                ReferralService.MarkAsUsed(chosenReferral.id);
                MessageBoxUtilities.ShowSuccessMessage("Appointment successfully scheduled!");
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private bool CreateAppointment(int doctorId, DateTime appointmentStart)
        {

            string error_message = ValidationUtilities.ValidateAppointment(doctorId, appointmentStart);
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
            AppointmentService.Create(newAppointment);
            return true;
        }

        private void FindSuitableDoctor()
        {
            try
            {
                Roles.Doctor suitableDoctor = DoctorService.GetSuitable(UIUtilities.ExtractID(specializationField.Text), appointmentPicker.Value);
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

        private void Referrals_Load(object sender, EventArgs e)
        {
            UIUtilities.FillPatientSelectionList(patientSelection);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Exceptions;
using Klinika.Roles;
using Klinika.Repositories;
using Klinika.Models;

namespace Klinika.Services
{
    internal class SecretaryService
    {

        public static void FillPatientSelectionList(ComboBox patientSelection,Dictionary<int,Patient> IDPatientPairs)
        {
            foreach(KeyValuePair<int,Patient> pair in IDPatientPairs)
            {
                string patient = pair.Key + ". " + pair.Value.Name + " " + pair.Value.Surname;
                patientSelection.Items.Add(patient);
            }
        }

        public static int ExtractID(string objectWithId)
        {
            return Convert.ToInt32(objectWithId.Split('.')[0]);
        }


        public static void Validate(int doctorID, DateTime appointmentStart)
        {


            if (appointmentStart <= DateTime.Now)
            {
                throw new DateTimeInvalidException("Selected appointment time is incorrect!");
            }

            if (doctorID == -1)
            {
                throw new FieldEmptyException("Doctor is not selected!");
            }

            if(AppointmentRepository.GetInstance().IsOccupied(appointmentStart,15,-1,doctorID))
            {
                throw new DoctorUnavailableException("The selected doctor is not available at the selected time!");
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class ChosenReferral
    {
        public string chosenDoctor { get; }
        public string chosenSpecialization { get; }
        public int chosenReferralId { get; }

        public ChosenReferral(string chosenDoctor, string chosenSpecialization, int chosenReferralId)
        {
            this.chosenDoctor = chosenDoctor;
            this.chosenSpecialization = chosenSpecialization;
            this.chosenReferralId = chosenReferralId;
        }
    }
}

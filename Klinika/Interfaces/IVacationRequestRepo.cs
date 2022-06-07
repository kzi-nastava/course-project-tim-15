using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Interfaces
{
    public interface IVacationRequestRepo
    {
        int Create(VacationRequest vacationRequest);
    }
}

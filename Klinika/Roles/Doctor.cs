using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Repositories;
using Klinika.Data;
using System.Data;
using Klinika.Services;

namespace Klinika.Roles
{
    internal class Doctor : User
    {
        public Specialization specialization { get; set; }

        public Doctor(int id, string name, string surname,Specialization specialization) : base(id, name, surname)
        {
            this.specialization = specialization;
        }

    }
}

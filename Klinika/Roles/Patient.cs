using Klinika.Exceptions;
using Klinika.Repositories;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Roles
{
    public class Patient : User
    {
        public string jmbg { get; set; }
        public DateTime birthdate { get; set; }

        public string whoBlocked { get; set; }

        public char gender { get; set; }
        public Patient(
                        int id,
                        string jmbg,
                        string name,
                        string surname,
                        DateTime birthdate,
                        char gender,
                        string email,
                        string password) : base(id, name, surname, email, password)
        {
            this.jmbg = jmbg;
            this.birthdate = birthdate;
            this.gender = gender;
            IsBlocked = false;
            whoBlocked = "";
        }


        public void Validate(bool isModification = false)
        {

            if (string.IsNullOrEmpty(jmbg))
            {
                throw new FieldEmptyException("JMBG left empty!");
            }

            else if (jmbg.Length != 13)
            {
                throw new JMBGFormatInvalidException("JMBG format is not valid!");
            }

            else if (string.IsNullOrEmpty(Name))
            {
                throw new FieldEmptyException("Name left empty!");
            }

            else if (string.IsNullOrEmpty(Surname))
            {
                throw new FieldEmptyException("Surname left empty!");
            }

            else if (birthdate > DateTime.Now)
            {
                throw new BirthdateInvalidException("Invalid birthdate!");
            }

            else if (string.IsNullOrEmpty(Email) && !isModification)
            {
                throw new FieldEmptyException("Email left empty!");
            }

            else if (PatientRepository.EmailIDPairs != null &&
                     PatientRepository.EmailIDPairs.ContainsKey(Email) &&
                     !isModification)
            {
                throw new ExistingEmailException("Email already in use!");
            }

            else if (!PatientService.IsValidEmail(Email) && !isModification)
            {
                throw new EmailFormatInvalidException("Incorrect email format!");
            }

            else if (string.IsNullOrEmpty(Password))
            {
                throw new FieldEmptyException("Password left empty!");
            }

            else if (Password.Length < 4)
            {
                throw new FieldEmptyException("Password is too short!");
            }

        }

        public void Modify()
        {
            Validate(isModification: true);
            PatientRepository.Modify(this);
        }

        public void Block(string whoBlocked)
        {
            whoBlocked = whoBlocked;
            IsBlocked = true;
            PatientRepository.Block(ID);
        }

        public void Unblock()
        {
            whoBlocked = "";
            IsBlocked = false;
            PatientRepository.Unblock(ID);
        }

    }
}

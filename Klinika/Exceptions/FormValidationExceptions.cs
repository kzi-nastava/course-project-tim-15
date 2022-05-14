using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Exceptions
{
    public abstract class FormValidationException : Exception
    {
        public FormValidationException(string message) : base(message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public abstract class ItemNotSelectedException : Exception
    {
        public ItemNotSelectedException(string item) : base(item + " is not selected!")
        {
            MessageBox.Show(item + " is not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class FieldEmptyException : FormValidationException
    {
       public FieldEmptyException(string message) : base(message) { }

    }

    public class BirthdateInvalidException : FormValidationException
    {
        public BirthdateInvalidException(string message) : base(message) { }

    }

    public class ExistingEmailException : FormValidationException
    {
        public ExistingEmailException(string message) : base(message) { }

    }

    public class EmailFormatInvalidException : FormValidationException
    {
        public EmailFormatInvalidException(string message) : base(message) { }

    }

    public class JMBGFormatInvalidException : FormValidationException
    {
        public JMBGFormatInvalidException(string message) : base(message) { }

    }

    public class DateTimeInvalidException : FormValidationException
    {
        public DateTimeInvalidException(string message) : base(message) { }

    }

    public class DoctorUnavailableException : FormValidationException
    {
        public DoctorUnavailableException(string message) : base(message) { }

    }

    public class PatientNotSelectedException : ItemNotSelectedException
    {
        public PatientNotSelectedException() : base("Patient") { }

    }

    public class SpecializationNotSelectedException : ItemNotSelectedException
    {
        public SpecializationNotSelectedException() : base("Specialization") { }

    }

    public class NegativeOrZeroValueException : FormValidationException
    {
        public NegativeOrZeroValueException(string message) : base(message) { }

    }


}

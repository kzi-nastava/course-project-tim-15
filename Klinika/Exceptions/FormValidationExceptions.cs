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
}

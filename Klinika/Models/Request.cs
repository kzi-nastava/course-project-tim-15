using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class Request
    {
        public enum Status { WAITING = 'W', APPROVED = 'A', DENIED = 'D' }

        public int id { get; }
        public Status status { get; }

        public Request(int id, Status status)
        {
            this.id = id;
            this.status = status;
        }
    }
}

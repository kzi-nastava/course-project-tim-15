using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class CleanDateTimeNow
    {
        public DateTime cleanNow { get; }

        public CleanDateTimeNow()
        {
            cleanNow = DateTime.Now;
            cleanNow = cleanNow.AddMilliseconds(-cleanNow.Millisecond);
            cleanNow = cleanNow.AddSeconds(-cleanNow.Second);
        }
    }
}

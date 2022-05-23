using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class CleanDateTimeNow
    {
        public DateTime now { get; }

        public CleanDateTimeNow()
        {
            now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            now = now.AddSeconds(-now.Second);
            
        }
    }
}

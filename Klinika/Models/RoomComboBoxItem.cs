using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class RoomComboBoxItem
    {
        public string text { get; set; }
        public object value { get; set; }
        public RoomComboBoxItem(string t, object v)
        {
            text = t;
            value = v;
        }
        public override string ToString()
        {
            return text;
        }
    }
}

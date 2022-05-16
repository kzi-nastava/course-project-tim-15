using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    internal class TimeSlot
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public TimeSlot(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        public TimeSlot(DateTime from)
        {
            this.from = from;
            to = from.AddMinutes(15);
        }


        public int GetDuration()
        {
            TimeSpan duration = to - from;
            return (int)duration.TotalMinutes;
        }


        public bool Equals(TimeSlot slot)
        {
            return slot.from == from && slot.to == to; ;
        }


        public TimeSlot? GetFirstUnoccupied(List<TimeSlot> occupied,int inNextMinutes = 120)
        {
            if(occupied.Count() == 0)
            {
                return this;
            }

            TimeSlot temporary = new TimeSlot(this.from,this.to);
            int duration = GetDuration();
            for (int i = 0; i < occupied.Count; i++)
            {
                if ((temporary.from - from).TotalMinutes >= inNextMinutes && inNextMinutes != -1) break;
                if(occupied.Count == 1 && (temporary.to <= occupied[0].from || temporary.from >= occupied[0].to)){
                    return temporary;
                }
                if(i != occupied.Count - 1)
                {
                    int between = (int)(occupied[i + 1].from - occupied[i].to).TotalMinutes;
                    if(between >= (duration)  && (occupied[i].to <= temporary.from && occupied[i + 1].from >= temporary.to))
                    {
                        return temporary;
                    }
                    else
                    {
                        if(temporary.from < occupied[i + 1].to)
                        {
                            temporary.from = occupied[i + 1].to;
                            temporary.to = temporary.from.AddMinutes(duration);
                        }
                    }
                }
                else
                {
                    if (temporary.from >= occupied[i].from) return temporary;
                    return new TimeSlot(occupied[i].to, occupied[i].to.AddMinutes(duration));
                }
            }
            return null;
        }

        public bool DoesOverlap(TimeSlot slot)
        {
            return ((from >= slot.from && to <= slot.to) || (from <= slot.from && to >= slot.to)
                || (from >= slot.from && to >= slot.to && from <= slot.to) || (from <= slot.from && to <= slot.to && to >= slot.from));
        }

    }
}

namespace Klinika.Models
{
    public class TimeSlot
    {
        public DateTime from { get; }
        public DateTime to { get; }

        public TimeSlot(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }

        public TimeSlot(DateTime from, int duration)
        {
            this.from = from;
            this.to = from.AddMinutes(duration);
        }

        public int GetDuration()
        {
            TimeSpan duration = to - from;
            return (int)duration.TotalMinutes;
        }

        public TimeSlot GetFirstUnoccupied(List<TimeSlot> occupied,int duration = 15)
        {
            for (int i = 0; i < occupied.Count; i++)
            {
                if (occupied[i].to < from) continue;

                if (i == occupied.Count - 1)  return new TimeSlot(occupied[i].to,occupied[i].to.AddMinutes(duration));

                TimeSlot betweenTwo = new TimeSlot(occupied[i].to, occupied[i + 1].from);
                if (betweenTwo.GetDuration() >= duration) return new TimeSlot(betweenTwo.from, betweenTwo.from.AddMinutes(duration));
            }
            return this;
        }

        public bool DoesOverlap(TimeSlot slot)
        {
            return ((from >= slot.from && to <= slot.to) || 
                    (from <= slot.from && to >= slot.to) ||
                    (from >= slot.from && to >= slot.to && from <= slot.to) ||
                    (from <= slot.from && to <= slot.to && to >= slot.from));
        }

    }
}

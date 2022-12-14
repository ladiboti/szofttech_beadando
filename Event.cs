using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Event
    {
        public Senior organizer { get; }
        public string description { get; }
        public string eventDate { get; }
        public string place { get; }
        public Event(Senior organizer, string descripiton, string eventDate, string place)
        {
            this.organizer   = organizer;
            this.description = descripiton;
            this.eventDate   = eventDate;
            this.place       = place;
        }
    }
}

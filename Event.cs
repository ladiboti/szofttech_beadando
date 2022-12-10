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
        public Date date { get; }
        public string place { get; }
        public Event(Senior organizer, string descripiton, Date date, string place)
        {
            this.organizer = organizer;
            this.description = descripiton;
            this.date = date;
            this.place = place;
        }
    }
}

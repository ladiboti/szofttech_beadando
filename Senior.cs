using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Senior : Student
    {
        public static List<AccommodationTicket> accommodationTickets { get;  }
        public static Dictionary<string, string> pendingGuestRequest { get; }
        public bool dutyStatus { get; set; }
        public void addEvent(Event newEvent) { 
            // kifejtés szükséges
        }
        public void startDuty() {
            // kifejtés szükséges
        }
        public void modifyDisciplinaryState() { 
            // kifejtés szükséges
        }
        public void giveAccommodationTicket() { 
            // kifejtés szükséges
        }

    }
}

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
        public static List<AccommodationTicket> accommodationTickets { get; set; }
        public static Dictionary<string, string> pendingGuestRequest { get; }
        public bool dutyStatus { get; private set; }
        public void addEvent(Event newEvent) { 
            // kifejtés szükséges
        }
        private void startDuty() {
            // kifejtés szükséges
        }
        private void modifyDisciplinaryState() { 
            // kifejtés szükséges
        }
        private void giveAccommodationTicket() { 
            // kifejtés szükséges
        }
        public void newGuestRequest(string id, string name) { 
            // kifejtés szükséges
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Senior : Student
    {
        public List<AccommodationTicket> accommodationTickets { get; set; }
        public Dictionary<int, string> pendingGuestRequests { get; set; }
        bool dutyStatus { get; set; }

        public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, int roomNumber, int balance, int obligation, List<AccommodationTicket> accommodationTickets, Dictionary<int, string> pendingGuestRequests, bool dutyStatus) 
            : base(notificationList, bicycles, name, neptunCode, major, roomNumber, balance, obligation)
        {
            this.accommodationTickets = accommodationTickets;
            this.pendingGuestRequests = pendingGuestRequests;
            this.dutyStatus           = dutyStatus;
        }

        public void addEvent(Event newEvent)
        {

        }

        private void startDuty()
        {

        }

        private void modifyDisciplinaryState()
        {

        }

        private void giveAccomodationTicket()
        {

        }

        private void listAccomodation()
        {

        }

        public void newGuestRequest(int id, string nev)
        {

        }
    }
}

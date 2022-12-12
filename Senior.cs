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

        public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, int roomNumber, List<AccommodationTicket> accommodationTickets, Dictionary<int, string> pendingGuestRequests) 
            : base(notificationList, bicycles, name, neptunCode, major, roomNumber)
        {
            this.accommodationTickets = accommodationTickets;
            this.pendingGuestRequests = pendingGuestRequests;
            this.dutyStatus           = false;
        }

        public void addEvent(Event newEvent)
        {
            Container.addEvent(newEvent);
        }

        private void startDuty()
        {
            dutyStatus = true;
        }

        private void stopDuty()
        {
            dutyStatus = false;
        }

        private void modifyDisciplinaryState()
        {
            isUnderDiscipliary = isUnderDiscipliary ? false : true;
        }

        private bool getDisciplinaryState()
        {
            return isUnderDiscipliary;
        }

        private void giveAccomodationTicket(AccommodationTicket newTicket)
        {
            accommodationTickets.Add(newTicket);
        }

        private void listAccomodation()
        {
            foreach (AccommodationTicket i in accommodationTickets)
            {
                Console.WriteLine($"{i.guestId} {i.guestName} {i.getExpireDate}");
                pendingGuestRequests.Remove(i.guestId);
            }
        }

        public void newGuestRequest(int id, string nev)
        {
            pendingGuestRequests.Add(id, nev);
        }
    }
}

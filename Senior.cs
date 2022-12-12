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
        static public List<AccommodationTicket> accommodationTickets { get; set; }
        static public Dictionary<string, string> pendingGuestRequests { get; set; }
        bool dutyStatus { get; set; }

        public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, int roomNumber, List<AccommodationTicket> accommodationTickets, Dictionary<string, string> pendingGuestRequests) 
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
            Console.Write("Adja meg a fegyelmit kapó diák neptun kódját: ");
            string tempNeptun = Console.ReadLine();
            if (tempNeptun != null)
            {
                Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary =
                    Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary ? false : true;
            }
            else
                Console.WriteLine("Nem adott meg neptun kódot");
            
        }

        private bool getDisciplinaryState()
        {
            Console.Write("Adja meg a diák neptun kódját: ");
            string tempNeptun = Console.ReadLine();
            return Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary;
        }

        private void giveAccomodationTicket()
        {
            Console.Write("The id of the vistor: ");
            string tempId = Console.ReadLine();
            Console.Write("The name of the visitor: ");
            string tempName = Console.ReadLine(); 
            Console.Write("How long the visitor intended to stay (days): ");
            int tempDay = Convert.ToInt32(Console.ReadLine());
            if(pendingGuestRequests.ContainsKey(tempId) && pendingGuestRequests[tempId] != null && 
                pendingGuestRequests.ContainsValue(tempName) && pendingGuestRequests[tempName] != null)
            {
                accommodationTickets.Add(new AccommodationTicket(tempId, tempName, new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + tempDay, DateTime.Now.Hour, DateTime.Now.Minute)));
                pendingGuestRequests.Remove(tempId);
            }
            else
            {
                Console.WriteLine("Nem létezik a megadott név vagy személyigazolványszám!");
            }
        }

        private void listAccomodation()
        {
            foreach (AccommodationTicket i in accommodationTickets)
            {
                Console.WriteLine($"{i.guestId} {i.guestName} {i.getExpireDate}");
            }
        }

        public static void newGuestRequest(string id, string nev)
        {
            if(!pendingGuestRequests.ContainsKey(id))
                pendingGuestRequests.Add(id, nev);
        }
    }
}

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
        public static List<AccommodationTicket> accommodationTickets = new List<AccommodationTicket>();
        public static Dictionary<string, string> pendingGuestRequests = new Dictionary<string, string>();
        bool dutyStatus { get; set; }

        public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, string password, int roomNumber) 
            : base(notificationList, bicycles, name, neptunCode, major, password, roomNumber)
        {
            //this.accommodationTickets = accommodationTickets;
            //this.pendingGuestRequests = pendingGuestRequests;
            this.dutyStatus           = false;
        }

        public static List<AccommodationTicket> getAccommodationTickets()
        {
            return accommodationTickets;
        }

        public static void setAccommodationTickets(List<AccommodationTicket> tempList)
        {
            foreach(var i in tempList)
            {
                accommodationTickets.Add(i);
            }
        }

        public void addEvent(Event newEvent)
        {
            Container.addEvent(newEvent);
        }

        public void startDuty()
        {
            dutyStatus = true;
        }

        public void stopDuty()
        {
            dutyStatus = false;
        }

        public void modifyDisciplinaryState()
        {
            Console.Write("Give the neptun code of the student who you wish to change its disciplinary state: ");
            string tempNeptun = Console.ReadLine().ToUpper();
            while (tempNeptun == "")
            {
                Console.WriteLine("No neptun code given. Give one!");
                tempNeptun = Console.ReadLine();
            }
            if (Container.students.Exists(x => x.neptunCode == tempNeptun) == true)
            { 
                Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary =
                    Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary ? false : true;
                Console.WriteLine($"Disciplinary state successfully changed to: {Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary}");
            }
            else
                Console.WriteLine("The person does not presented in the list");
            
        }

        public bool getDisciplinaryState()
        {
            Console.Write("Give the neptun code of a student: ");
            string tempNeptun = Console.ReadLine().ToUpper();
            while (tempNeptun == "")
            {
                Console.WriteLine("No neptun code given");
                tempNeptun = Console.ReadLine();
            }
            if (Container.students.Exists(x => x.neptunCode == tempNeptun) == true)
            {
                return Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary;
            }
            else
                Console.WriteLine("The person does not presented in the list");
            return false;
            
        }

        public void giveAccomodationTicket()
        {
            Console.Write("The id of the vistor: ");
            string tempId = Console.ReadLine().ToUpper();
            Console.Write("The name of the visitor: ");
            string tempName = Console.ReadLine(); 
            Console.Write("How long the visitor intended to stay (days): ");
            string tempDay = Console.ReadLine();
            while(tempId == "" || tempName == "" || tempDay == "")
            {
                Console.WriteLine("No ID, staying and/or Name was given");
                if(tempId == "")
                {
                    Console.Write("The id of the vistor: ");
                    tempId = Console.ReadLine().ToUpper();
                }
                if(tempName == "")
                {
                    Console.Write("The name of the visitor: ");
                    tempName = Console.ReadLine();
                }
                if (tempDay == "")
                {
                    Console.Write("How long the visitor intended to stay (days): ");
                    tempDay = Console.ReadLine();
                }
            }
            if(pendingGuestRequests.ContainsKey(tempId) && pendingGuestRequests.ContainsValue(tempName))
            {
                accommodationTickets.Add(new AccommodationTicket(tempId, tempName, new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + Convert.ToInt32(tempDay), DateTime.Now.Hour, DateTime.Now.Minute)));
                pendingGuestRequests.Remove(tempId);
            }
            else
            {
                Console.WriteLine("The given ID or name doesn't exist!");
            }
        }

        public void listAccomodation()
        {
            foreach (AccommodationTicket i in accommodationTickets)
            {
                Console.WriteLine($"{i.guestId} {i.guestName} {i.getExpireDate()}");
            }
        }

        public static void newGuestRequest(string id, string nev)
        {
            if (!pendingGuestRequests.ContainsKey(id))
                pendingGuestRequests.Add(id, nev);
            else
                Console.WriteLine("This person is already presented in the list.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        public Senior()
        {
          
        }
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

        public static Dictionary<string, string> getPendingGuestRequest()
        {
            return pendingGuestRequests;
        }

        public static void setPednigGuestRequest(Dictionary<string, string> tempDict)
        {
            foreach(var i in tempDict)
            {
                pendingGuestRequests.Add(i.Key, i.Value);
            }
        }

        public void addEvent()
        {
            Console.WriteLine("Give a description about the event:");
            string description = Console.ReadLine();
            while (description == "")
            {
                Console.WriteLine("Give a description about the event!");
                description = Console.ReadLine();
            }

            Console.WriteLine("When the event will take place?");
            Console.Write("Year:");
            bool canConvertYear = false;
            int year;
            string yearString = Console.ReadLine();
            canConvertYear = int.TryParse(yearString, out year);
            while ((yearString == "" || year <= 0) || !canConvertYear)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                yearString = Console.ReadLine();
                canConvertYear = int.TryParse(yearString, out year);
            }

            Console.Write("Month:");
            bool canConvertMonth = false;
            int month;
            string monthString = Console.ReadLine();
            canConvertMonth = int.TryParse(monthString, out month);
            while ((monthString == "" || month <= 0) || !canConvertMonth)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                monthString = Console.ReadLine();
                canConvertMonth = int.TryParse(monthString, out month);
            }

            Console.Write("Day:");
            bool canConvertDay = false;
            int day;
            string dayString = Console.ReadLine();
            canConvertDay = int.TryParse(dayString, out day);
            while ((dayString == "" || day <= 0) || !canConvertDay)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                dayString = Console.ReadLine();
                canConvertDay = int.TryParse(dayString, out day);
            }

            Date date = new Date(year, month, day);
            Console.WriteLine("Where the event will take place?");
            string place = Console.ReadLine();
            while (place == "")
            {
                Console.WriteLine("Where the event will take place?");
                place = Console.ReadLine();
            }
            Event newEvent = new Event(new Senior(this.notificationList,this.bicycles,this.name,this.neptunCode,this.major,this.password,this.roomNumber),
                description, date.getDateString(), place);
            Container.addEvent(newEvent);
            Container.refreshEventsJSON();
            Console.WriteLine("Event created!");
            Console.ReadKey();
            Console.Clear();
        }

        public void startDuty()
        {
            if(dutyStatus == true)
            {
                Console.WriteLine("You are already on duty!");
            }
            else
            {
                dutyStatus = true;
                Console.WriteLine("You are now on duty!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void stopDuty()
        {
            if(dutyStatus == false)
            {
                Console.WriteLine("You are not on duty at the moment!");
            }
            else
            {
                dutyStatus = false;
                Console.WriteLine("You are no longer on duty!");
            }
            Console.ReadKey();
            Console.Clear();
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
                Container.refreshSeniorJSON();
            }
            else
                Console.WriteLine("The person does not presented in the list");
            Console.ReadKey();
            Console.Clear();
        }

        public void getDisciplinaryState()
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
                Console.WriteLine("A student is under disciplinary state.");
            }
            else if (Container.students.Exists(x => x.neptunCode == tempNeptun) == false)
            {
                Console.WriteLine("A student is not under disciplinary state.");
            }
            else
                Console.WriteLine("The person does not presented in the list");
            Console.ReadKey();
            Console.Clear();

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
                Console.WriteLine("Accomodation ticket successfully added!");
            }
            else
            {
                Console.WriteLine("The given ID or name doesn't exist!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void listAccomodation()
        {
            foreach (AccommodationTicket i in accommodationTickets)
            {
                Console.WriteLine($"{i.guestId} {i.guestName} {i.getExpireDate()}");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void newGuestRequest(string id, string nev)
        {
            if (!pendingGuestRequests.ContainsKey(id))
                pendingGuestRequests.Add(id, nev);
            else
                Console.WriteLine("This person is already presented in the list.");
        }

    public override void menu()
    {
        do
        {
            Console.WriteLine("DEBUG: SENIOR MENU");

            Console.WriteLine(
                $" 1: Pay your obligation\n" +
                $" 2: Send request to the administrator\n" +
                $" 3: Send a guest request\n" +
                $" 4: Add a bicycle to the virtual storage\n" +
                $" 5: Set your balance\n" +
                $" 6: Create a new event\n" +
                $" 7: Start your duty\n" +
                $" 8: Stop your duty\n" +
                $" 9: Modify student's disciplinary state\n" +
                $"10: Get student's disciplinary state\n" +
                $"11: Give accomondation ticket to a student\n" +
                $"12: Show your notifications\n" +
                $"13: List accomodations\n" +
                $"99: Log out"
            );
            Console.WriteLine("\nHere is your functions, tell me what do you want to do!");
            //ki kell irni a lehetosegek :(((((
            bool canConvert = false;
            int actionNumber;
            string actionNumberString = Console.ReadLine();
            canConvert = int.TryParse(actionNumberString, out actionNumber);
            while ((actionNumberString == "" || actionNumber <= 0) || !canConvert)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                actionNumberString = Console.ReadLine();
                canConvert = int.TryParse(actionNumberString, out actionNumber);
            }
            switch (actionNumber)
            {
                case 1:
                    pay();
                    break;
                case 2:
                    sendRequest();
                    break;
                case 3:
                    requestGuest();
                    break;
                case 4:
                    addBicycle();
                    break;
                case 5:
                    setBalance();
                    break;
                case 6:
                    addEvent();
                    break;
                case 7:
                    startDuty();
                    break;
                case 8:
                    stopDuty();
                    break;
                case 9:
                    modifyDisciplinaryState();
                    break;
                case 10:
                    getDisciplinaryState();
                    break;
                case 11:
                    giveAccomodationTicket();
                    break;
                case 12:
                    showNotifications();
                    break;
                case 13:
                    listAccomodation();
                    break;
                case 99:
                    logout();
                    break;
                default:
                    Console.WriteLine("Sorry, but this function doesn't exist");
                    break;
            }
        } while (true);
    }
  }
}

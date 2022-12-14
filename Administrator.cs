using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace szofttech
{
    internal class Administrator : CollegePerson
    {
        //kell json a requestlistbol is ugye?
        //atkerult a requestlist a containerbe
        //private static List<Request> requestsList = new List<Request>();

        public void addNewStudent()
        {
            string name;
            string neptunCode;
            int roomNumber;
            string roomNumberString;
            bool canConvert = false;
            string major;
            string password;
            // password MUSZÁJ BEÁLLÍTTATNI!!!!!


            Console.WriteLine("Please give us the Student name!");
            name = Console.ReadLine();
            while (name == "") {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                name = Console.ReadLine();
            }

            Console.WriteLine("Please give us the Student neptun code!");
            neptunCode = Console.ReadLine();
            while (neptunCode == "")
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                neptunCode = Console.ReadLine();
            }

            Console.WriteLine("Please give us the Student room number!");
            roomNumberString = Console.ReadLine();
            canConvert = int.TryParse(roomNumberString, out roomNumber);
            while ((roomNumberString == "" || roomNumber <= 0) || !canConvert) {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                roomNumberString = Console.ReadLine();
                canConvert = int.TryParse(roomNumberString, out roomNumber);
            }

            Console.WriteLine("Please give us the Student major!");
            major = Console.ReadLine();
            while (major == "")
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                major = Console.ReadLine();
            }

            Console.WriteLine("Please give us the Student password!");
            password = Console.ReadLine();
            while (password == "")
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                password = Console.ReadLine();
            }

            Student newStudent = new Student(new List<Notification>(), 
                                             new List<string>(), 
                                             name, neptunCode, major, password, roomNumber
                                             );
            Container.addStudent(newStudent);
        }

        private void promoteStudentToSenior()
        {
            Console.Write("Give the neptun code of the student who you wish to promote to senior rank: ");
            string tempNeptun = Console.ReadLine().ToUpper();
            while (tempNeptun == "")
            {
                Console.WriteLine("No neptun code given. Give one!");
                tempNeptun = Console.ReadLine();
            }
            if (Container.students.Exists(x => x.neptunCode == tempNeptun) == true)
            {
                Student student = new Student();
                student = Container.students.Find(x => x.neptunCode == tempNeptun);
                Container.students.Add(new Senior(student.notificationList, student.bicycles, student.name,
                                              student.neptunCode, student.major, student.password, student.roomNumber));
                Container.students.Remove(student);
                Console.WriteLine("The selected student is sucessfully promoted!");
            }
            else
                Console.WriteLine("The person does not presented in the list");

            //TODO: frissiteni kell majd a jsont!!!!
            //public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, int roomNumber)
            //      : base(notificationList, bicycles, name, neptunCode, major, roomNumber)

        }

        public static void addRequest(Request request)
        {
            Container.addRequest(request);
        }

        //tesztelésre szorul!!!!
        private void approveRequest()
        {
            int index = 0;
            Console.WriteLine("DEBUG: Administrator.approveRequest()" + Container.requests.Count());
            foreach (Request r in Container.requests) {
                index++;
                Console.WriteLine($"{index} {r.sender.name} {r.message} {r.status}");
            }
            if (index != 0)
            {
                int status = 0;
                Console.WriteLine("Please choose a request which you want to modify! (Give a number)");
                index = Convert.ToInt32(Console.ReadLine());

                while (index < 0 && index > Container.requests.Count) {
                    Console.WriteLine("The given number is not valid! Please give a valid number!");
                    index = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Please choose a status! (1 = accepted, 2 = denied)");
                status = Convert.ToInt32(Console.ReadLine());
                while (status < 1 && status > 2) {
                    Console.WriteLine("The given number is not valid! Please give a valid number!");
                    status = Convert.ToInt32(Console.ReadLine());
                }

                Container.requests[index].status = status;
                string neptunCode = Container.requests[index].sender.neptunCode;

                Container.students.Find(x => x.neptunCode == neptunCode)
                                  .notificationList.Add(new Notification(addNotification(), 
                                                        new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                                 DateTime.Now.Hour, DateTime.Now.Minute).getDateString())
                                                        );
            }
            else {
                Console.WriteLine("Request container is empty!");
            }
        }

        private string addNotification()
        {
            string message;
            Console.WriteLine("Please give us the text you want to send to the specific Student/Students!");
            message = Console.ReadLine();
            while (message == "") {
                Console.WriteLine("The given text is invalid! Please give a valid text!");
                message = Console.ReadLine();
            }
            return message;
        }

        private void addObligation()
        {
            int obligation;
            string obligationString;
            bool canConvert = false;
            Console.WriteLine("Please give us the obligation!");
            obligationString = Console.ReadLine();
            canConvert = int.TryParse(obligationString, out obligation);
            while ((obligationString == "" || obligation <= 0) || !canConvert) {
                Console.WriteLine("The given number is invalid! Please give a valid number!");
                obligationString = Console.ReadLine();
                canConvert = int.TryParse(obligationString, out obligation);
            }
            string message = addNotification();
            foreach (Student s in Container.students) {
                s.obligation += obligation;
                s.notificationList.Add(new Notification(message, 
                                                        new Date(2022,3,14,12,0).getDateString())
                                      );
            }
            Container.refreshStudentsJSON();
        }

        private void modifyDisciplinaryState()
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
            Container.refreshStudentsJSON();
        }

        private void moveToRoom()
        {
            string neptunCode;
            int roomNumber;
            string roomNumberString;
            bool canConvert = false;

            Container.getStudentList();

            Console.WriteLine("Please give us the neptun code of the student who you want to move to another room!");
            neptunCode = Console.ReadLine();
            while (neptunCode == "") {
                Console.WriteLine("The given neptun code is invalid! Please give us a valid neptun code!");
                neptunCode = Console.ReadLine();
            }
            
            Console.WriteLine("Please give us the new room number of the Student!");
            roomNumberString = Console.ReadLine();
            canConvert = int.TryParse(roomNumberString, out roomNumber);
            while ((roomNumberString == "" || roomNumber <= 0) || !canConvert)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                roomNumberString = Console.ReadLine();
                canConvert = int.TryParse(roomNumberString, out roomNumber);
            }
            if (Container.students.Exists(x => x.neptunCode == neptunCode) == true)
            {
                Container.students.Find(x => x.neptunCode == neptunCode).roomNumber = roomNumber;
                Container.students.Find(x => x.neptunCode == neptunCode).notificationList.Add(
                    new Notification(addNotification(), new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute).getDateString()));
                Container.refreshStudentsJSON();
            }
            else
                Console.WriteLine("The person does not presented in the list");
        }
    public override void menu()
    {
        do
        {
            Console.WriteLine("DEBUG: ADMIN MENU");

            Console.WriteLine(
                $" 1: Add new student\n" +
                $" 2: Promote student to senior\n" +
                $" 3: Approve requests\n" +
                $" 4: Add obligation to student\n" +
                $" 5: Modify student's disciplinary state\n" +
                $" 6: Move student to another room\n" +
                $"99: Log out"
            );
            Console.WriteLine("\nHere is your functions, tell me what do you want to do!");

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
                    addNewStudent();
                    break;
                case 2:
                    promoteStudentToSenior();
                    break;
                case 3:
                    approveRequest();
                    break;
                case 4:
                    addObligation();
                    break;
                case 5:
                    modifyDisciplinaryState();
                    break;
                case 6:
                    moveToRoom();
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

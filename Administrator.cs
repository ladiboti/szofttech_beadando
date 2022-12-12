using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Administrator : CollegePerson
    {
        public static List<Request> requestsList;

        private void addNewStudent()
        {
            string name = "";
            string neptunCode = "";
            int roomNumber = 0;
            string major = "";
            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("Please give us the Student name!");
                name = Console.ReadLine();
                Console.WriteLine("Please give us the Student neptun code!");
                neptunCode = Console.ReadLine();
                Console.WriteLine("Please give us the Student room number!");
                roomNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please give us the Student major!");
                major = Console.ReadLine();
                if (name == "" || neptunCode == "" || roomNumber == 0 || major == "") {
                    Console.WriteLine("The input is invalid!");
                    continue;
                }
                finished = true;
            }
            Student newStudent = new Student(new List<Notification>(), new List<string>(), name, neptunCode, major, roomNumber);
            Container.addStudent(newStudent);
        }

        private void promoteStudent()
        {
            throw new NotImplementedException();
        }

        public static void addRequest()
        {
            throw new NotImplementedException();
        }

        private void approveRequest()
        {
            int index = 0;
            foreach (Request r in requestsList) {
                index++;
                Console.WriteLine($"{index} {r.sender.name} {r.message} {r.status}");
            }
            if (index != 0)
            {
                int status = 0;
                Console.WriteLine("Please choose a request which you want to modify! (Give a number)");
                index = Convert.ToInt32(Console.ReadLine());
                while (index < 0 && index > requestsList.Count) {
                    Console.WriteLine("The given number is not valid! Please give a valid number!");
                    index = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Please choose a status! (1 = accepted, 2 = denied)");
                status = Convert.ToInt32(Console.ReadLine());
                while (status < 1 && status > 2) {
                    Console.WriteLine("The given number is not valid! Please give a valid number!");
                    status = Convert.ToInt32(Console.ReadLine());
                }
                requestsList[index].status = status;
            }
            else {
                Console.WriteLine("Request container is empty!");
            }
        }

        private void addNotification()
        {
            
        }

        private void addObligation()
        {
            throw new NotImplementedException();
        }

        private void modifyDisciplinaryState()
        {
            throw new NotImplementedException();
        }

        private void moveToRoom()
        {
            throw new NotImplementedException();
        }
  }
}

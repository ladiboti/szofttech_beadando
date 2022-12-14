﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace szofttech
{
    internal class Administrator : CollegePerson
    {
        //kell json a requestlistbol is ugye?
        private static List<Request> requestsList = new List<Request>();

        public void addNewStudent()
        {
            string name;
            string neptunCode;
            int roomNumber = -1;
            string major;

            //KÉRD BE ADRIÁN!!!!
            string password = null;
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
            
            // ez a rész még kifejtésre szorul!!!

            //while (roomNumber.GetType() != typeof(int))
            //{
            //    Console.WriteLine("The given input is invalid! Please give valid input!");
            //    name = Console.ReadLine();
            //}
            //try
            //{
            //    roomNumber = Convert.ToInt32(Console.ReadLine());
            //} catch (FormatException e) {
            //    Console.WriteLine("The given input is invalid!");
            //}
            Console.WriteLine("Please give us the Student major!");
            major = Console.ReadLine();
            while (major == "")
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                name = Console.ReadLine();
            }
            Student newStudent = new Student(new List<Notification>(), 
                                             new List<string>(), 
                                             name, neptunCode, major, password, roomNumber
                                             );
            Container.addStudent(newStudent);
        }

        private void promoteStudentToSenior()
        {
            string neptunCode;

            Console.WriteLine("Please give us the neptun code of the Student you want to promote!");
            neptunCode = Console.ReadLine();
            
            //ez a feltétel így biztosan nem lesz jó
            while (neptunCode == "") {

                Console.WriteLine("The given neptun code is invalid! Please give us a valid neptun code!");
                neptunCode = Console.ReadLine();
            }

      //rossz neptun kódnál hibát fog dobni
            Student student = new Student();
            student = Container.students.Find(s => s.neptunCode == neptunCode);

            //TODO: frissiteni kell majd a jsont!!!!
            //public Senior(List<Notification> notificationList, List<string> bicycles, string name, string neptunCode, string major, int roomNumber)
            //      : base(notificationList, bicycles, name, neptunCode, major, roomNumber)
            Container.students.Add(new Senior(student.notificationList, student.bicycles, student.name,
                                              student.neptunCode, student.major, student.password, student.roomNumber));

            Container.students.Remove(student);
             // folytatás később
    }

        public static void addRequest(Request request)
        {
            requestsList.Add(request);
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
                string neptunCode = requestsList[index].sender.neptunCode;

                Container.students.Find(x => x.neptunCode == neptunCode)
                                  .notificationList.Add(new Notification(addNotification(), 
                                                        new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                                 DateTime.Now.Hour, DateTime.Now.Minute))
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
            Console.WriteLine("Please give us the obligation!");
            obligation = Convert.ToInt32(Console.ReadLine());
            while (obligation < 0) {
                Console.WriteLine("The given number is invalid! Please give a valid number!");
                obligation = Convert.ToInt32(Console.ReadLine());
            }
            string message = addNotification();
            foreach (Student s in Container.students) {
                s.obligation += obligation;
                s.notificationList.Add(new Notification(message, 
                                                        new Date(DateTime.Now.Year, DateTime.Now.Month, 
                                                        DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute))
                                      );
            }
        }

        private void modifyDisciplinaryState()
        {
            Console.Write("Adja meg a fegyelmit kapó diák neptun kódját: ");
            string tempNeptun = Console.ReadLine();
            Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary = 
                Container.students.Find(x => x.neptunCode == tempNeptun).isUnderDiscipliary ? false : true;
        }

        private void moveToRoom()
        {
            string neptunCode;
            int roomNumber;
            Container.getStudentList();
            Console.WriteLine("Please give us the neptun code of the student who you want to move to another room!");
            neptunCode = Console.ReadLine();
            while (neptunCode == "") {
                Console.WriteLine("The given neptun code is invalid! Please give us a valid neptun code!");
                neptunCode = Console.ReadLine();
            }
            Console.WriteLine("Please give us the new room number of the Student!");
            roomNumber = Convert.ToInt32(Console.ReadLine());
            while (roomNumber < 0) {
                Console.WriteLine("The given room number is invalid! Please give us a valid room number!");
                roomNumber = Convert.ToInt32(Console.ReadLine());
            }
            Container.students.Find(x => x.neptunCode == neptunCode).roomNumber = roomNumber;
            Container.students.Find(x => x.neptunCode == neptunCode).notificationList.Add(
                new Notification(addNotification(), new Date(DateTime.Now.Year, DateTime.Now.Month,
                                                             DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute)));
        }
        public override void menu()
        {
          Console.WriteLine("DEBUG: ADMIN MENU");
          Console.WriteLine("Here is your functions, tell me what do you want to do!");
          //ki kell irni a lehetosegek :(((((
          int actionNumber = int.Parse(Console.ReadLine());
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
        }
    }
}

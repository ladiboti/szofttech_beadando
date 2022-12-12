﻿using System;
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
            
        }

        private void approveRequest()
        {
            throw new NotImplementedException();
        }

        private void addNotification()
        {
            throw new NotImplementedException();
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

﻿using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace szofttech
{
  internal class Program
  {
    private void start()
    {  
      showMenu();
    }

    private void showMenu()
    {
      Console.WriteLine("Welcome to the dormitory management system!\n" +
                        "before going forward please log in to your account!");
      CollegePerson.login();
      //CollegePerson.logout();
      //switch-es szerkezettel szebb lenne
      CollegePerson.user.menu();
    }

    private void adminMenu()
    {
      
    }

    private void studentMenu()
    {
      Console.WriteLine("here is the student menu: ");
    }
    static void Main(string[] args)
    {
        //Test.seniorTest();
        //Test.testStudentJsonify();
        //Test.testEventJsonify();

        //Test.testStudent();

        //Test.testAdministrator();
        //Test.loadStudentsTest();

        Program program = new Program();
        program.start();
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  abstract class CollegePerson
  {
    //undorito, de igy mukodik a legegyszerubben :))))))
    public static CollegePerson user;
    public string name { get; set; }

    public abstract void menu();
    public static void login()
    {
      //debug 
      Container.students.ForEach(student => Console.WriteLine(student.toString()));
      Console.WriteLine("Welcome to the dormitory management system!\n" +
                       "before going forward please log in to your account!");
      //username nincs, csak neptun kod
      Console.WriteLine("For login, please enter your username, or neptun code below:");
      string username = Console.ReadLine();

      //belepes ellenorizetlen!!!!!!!
      Console.WriteLine("Can I see your password too?");
      string password = Console.ReadLine();

      switch ((username, password))
      {
        case ("admin", "admin"):
          user = new Administrator();
          Console.WriteLine("Welcome admin, glad to see you here!");
          break;

        default:
          //rossz felhasznalonev es jelszo eseten null!!! :D
          user = new Student();
          user = Container.students.Find(s =>
                  s.neptunCode == username
               && s.password == password);

          //TODO: ciklusban menjen
          Console.WriteLine(user is null ? "Bad credidentals, try again" :
                                          $"Welcome {(user is Student ? user.name : "admin")} glad to see you here!");
          break;
      }
    }
    //test!!!
    public static void logout()
    {
      Console.WriteLine("For new login restart the application\nShutting down...");
      System.Threading.Thread.Sleep(100);
      System.Environment.Exit(1);
    }
  }
}

using System.Xml.Serialization;

namespace szofttech
{
  internal class Program
  {
    Student user = new Student();
    private void start()
    {
      
      showMenu();
    }

    private void login()
    {
      //username nincs, csak neptun kod
      Console.WriteLine("For login, please enter your username, or neptun code below:");
      string username = Console.ReadLine();

      //belepes ellenorizetlen!!!!!!!
      Console.WriteLine("Can I see your password too?");
      string password = Console.ReadLine();

      //rossz felhasznalonev es jelszo eseten null!!! :D
      user = Container.students.Find(s => 
              s.neptunCode == username
           && s.password   ==password);


      //Container.students.Find(x => x.neptunCode == neptunCode)
      //                            .notificationList.Add(new Notification(addNotification(),
      //                                                  new Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
      //                                                           DateTime.Now.Hour, DateTime.Now.Minute))
      //                                                  );
    }

    private void showMenu()
    {
      Console.WriteLine("Welcome to the dormitory management system!\n" +
                        "before going forward please log in to your account!");
      login();
    }
    static void Main(string[] args)
    {
        //Test.testStudentJsonify();
        //Test.testEventJsonify();

        //Test.testStudent();

        //Test.testAdministrator();
        //Test.loadStudentsTest();

        //Program program = new Program();
        //program.start();
    }
  }
}
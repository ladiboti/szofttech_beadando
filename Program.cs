using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace szofttech
{
  internal class Program
  {
    public static void start()
    {
      Container.loadAllJSON();
      CollegePerson.login();
      CollegePerson.user.menu();
    }
    static void Main(string[] args)
    {
      //Test.seniorTest();
      //Test.testStudentJsonify();
      //Test.testEventJsonify();

      //Test.testStudent();

      //Test.testAdministrator();
      //Test.loadStudentsTest();

      start();
    }
  }
}
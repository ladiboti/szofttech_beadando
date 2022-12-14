using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace szofttech
{
  internal class Program
  {
    private void start()
    {
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

        Program program = new Program();
        program.start();
    }
  }
}
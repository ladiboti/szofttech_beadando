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
      throw new NotImplementedException();
    }
    static void Main(string[] args)
    {
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
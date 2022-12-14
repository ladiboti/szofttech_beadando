using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  public static class Test
  {
    public static void seniorTest()
        {
            Senior tester = new Senior(new List<Notification>(), new List<string>(), "Bekő Tóni", "DE97T2", "Gazdinfo","ps_1", 115);
            Senior other = new Senior(new List<Notification>(), new List<string>(), "Karó Géza", "BG5FO9", "Vegyészmérnök","ps_2", 234);
            Student testStudent = new Student(new List<Notification>(), new List<string>(), "Kris", "DGB6LT", "Proginfo", "Dallos0927", 144);
            Container.getEventList();
            Container.addStudent(testStudent);

            tester.startDuty();
            other.startDuty();
            other.stopDuty();

            tester.modifyDisciplinaryState();
            tester.getDisciplinaryState();
            Container.getStudentList();

            testStudent.requestGuest();
            tester.giveAccomodationTicket();
            tester.listAccomodation();
        }
        public static void testStudent() {
        Student student = new Student(null, null, "Adrian", "TN21X0", "Software Engineer","valami", 3071);
            student.pay();
            student.pay();
            student.pay();
            student.pay();
            //student.sendRequest();
            //student.requestGuest();
            //student.addBicycle();
        }

    public static void testAdministrator() {
        Administrator admin = new Administrator();
            admin.addNewStudent();
    }
    public static void testStudentJsonify()
    {
        Student dummy1 = new Student(
             new List<Notification> { new Notification("proba1", new Date(2022, 12, 12, 0, 0).getDateString()),
                                      new Notification("proba2", new Date(2022, 12, 13, 0, 0).getDateString()),
                                      new Notification("proba3", new Date(2022, 12, 14, 0, 0).getDateString())
                                    },
             new List<string> { "qwe", "rtz", "uio" },
             "Dumb",
             "ASD123",
             "software engineer",
             "Password",
             123
         );
        Senior dummySenior = new Senior(
            new List<Notification> { new Notification("proba4", new Date(2022, 12, 15, 0, 0).getDateString()),
                                     new Notification("proba5", new Date(2022, 12, 16, 0, 0).getDateString()),
                                     new Notification("proba6", new Date(2022, 12, 17, 0, 0).getDateString())
                                    },
            new List<string> { "asd", "fgh", "jkl" },
            "Dumber",
            "DSA321",
            "business engineer",
            "Password",
            321
        );

      Container.addStudent(dummy1);
      Container.addStudent(dummySenior);
    }

    public static void testEventJsonify()
    {
      Senior dummy1 = new Senior(
            new List<Notification> { new Notification("proba1", new Date(2022, 12, 12, 0, 0).getDateString()),
                                     new Notification("proba2", new Date(2022, 12, 13, 0, 0).getDateString()),
                                     new Notification("proba2", new Date(2022, 12, 14, 0, 0).getDateString())
                                   },
            new List<string> { "asd", "fgh", "jkl" },
            "Dumber",
            "ASD123",
            "software engineer",
            "Qq123456",
            123
        );

       Event dummyEvent1 = new Event(dummy1, "proba1", new Date(2022, 12, 12, 0, 0), "magister");
       Container.addEvent(dummyEvent1);
    }
    public static void loadStudentsTest()
    {
      string studentsPath = @"D:\students.json";
      List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsPath));

      foreach (var student in students)
      {
        Console.WriteLine(student.toString());
      }
    }
  }
}

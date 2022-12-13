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
    public static void testStudentJsonify()
    {
        Student dummy1 = new Student(
             new List<Notification> { new Notification("proba1", new Date(2022, 12, 12, 0, 0)),
                                      new Notification("proba2", new Date(2022, 12, 13, 0, 0)),
                                      new Notification("proba3", new Date(2022, 12, 14, 0, 0))
                                    },
             new List<string> { "qwe", "rtz", "uio" },
             "Dumb",
             "ASD123",
             "software engineer",
             123
         );
        Senior dummySenior = new Senior(
            new List<Notification> { new Notification("proba4", new Date(2022, 12, 15, 0, 0)),
                                     new Notification("proba5", new Date(2022, 12, 16, 0, 0)),
                                     new Notification("proba6", new Date(2022, 12, 17, 0, 0))
                                    },
            new List<string> { "asd", "fgh", "jkl" },
            "Dumber",
            "DSA321",
            "business engineer",
            321
        );

      Container.addStudent(dummy1);
      Container.addStudent(dummySenior);
    }

    public static void testEventJsonify()
    {
      Senior dummy1 = new Senior(
            new List<Notification> { new Notification("proba1", new Date(2022, 12, 12, 0, 0)),
                                     new Notification("proba2", new Date(2022, 12, 13, 0, 0)),
                                     new Notification("proba2", new Date(2022, 12, 14, 0, 0))
                                   },
            new List<string> { "asd", "fgh", "jkl" },
            "Dumber",
            "ASD123",
            "software engineer",
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
        Console.WriteLine(student.name);
      }
    }
  }
}

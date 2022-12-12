using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    static class Container
    {
      private static string studentsPath = @"C:\students.json";
      private static string eventsPath   = @"C:\events.json";

    //elképzelhető, hogy null marad vegig
    static public List<Event> events = new List<Event>();//JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(eventsPath));
    static public List<Student> students = new List<Student>();//JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsPath));

    
      private static void jsonify<T>(List<T> list)
      {
        var jsonString = JsonConvert.SerializeObject(list);
  
        //PONTOSITANI A FILE HELYET!!!!!!!!!!!!!!!!!
        Type type = typeof(T);
        //nullazni kell a file-t
        File.WriteAllText(type == typeof(Student) ? 
                          studentsPath : eventsPath, 
                          jsonString
                          );
      }

        public static void getEventList()
        {
            foreach (Event i in events)
            {
                Console.WriteLine($"{i.organizer} {i.description} {i.getDate()} {i.place}");
            }
        }
        public static void getStudentList()
        {
            foreach (Student i in students)
            {
                Console.WriteLine($"{i.name} {i.neptunCode} {i.major} {i.roomNumber}");
            }
        }
        public static void addEvent(Event newEvent)
      {   
          //nem biztos, hogy igy kell generikus metodust hivni
          events.Add(newEvent);
          jsonify<Event>(events);
      }
      public static void addStudent(Student student) 
      {
          students.Add(student);
          jsonify<Student>(students);
      }
    }
}

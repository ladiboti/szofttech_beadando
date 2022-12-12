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
      private static string studentsPath = @"D:\students.json";
      private static string eventsPath   = @"D:\events.json";

    //elképzelhető, hogy null marad vegig
    static private List<Event> events = new List<Event>();//JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(eventsPath));
    static private List<Student> students = new List<Student>();//JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsPath));

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
      
      public static List<Event> getEventList() 
      {
            return events;
      }
      public static List<Student> getStudentList() 
      {
            return students;
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

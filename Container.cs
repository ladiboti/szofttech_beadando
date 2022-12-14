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
      private static string requestsPath = @"C:\requests.json";

      //elképzelhető, hogy null marad vegig
      //productban a deserialize kell, hogy beolvassa a mar kesz jsont, ures file-al nem mukodik!!!!
      static public List<Event>   events   = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(eventsPath));
      static public List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentsPath));
      static public List<Request> requests = JsonConvert.DeserializeObject<List<Request>>(File.ReadAllText(requestsPath));

    private static void jsonify<T>(List<T> list)
      {
        
        var jsonString = JsonConvert.SerializeObject(list);
  
        //PONTOSITANI A FILE HELYET!!!!!!!!!!!!!!!!!
        Type type = typeof(T);
        //nullazni kell a file-t
        if(type == typeof(Student))
        {
          File.WriteAllText(studentsPath, string.Empty);

          File.WriteAllText(studentsPath, jsonString);
        }
        if (type == typeof(Event))
        {
          File.WriteAllText(eventsPath, string.Empty);

          File.WriteAllText(eventsPath, jsonString);
        }
        if (type == typeof(Request))
        {
          File.WriteAllText(requestsPath, string.Empty);

          File.WriteAllText(requestsPath, jsonString);
        }

    }

      public static void refreshStudentsJSON()
      {
        jsonify<Student>(students);
      }

      public static void refreshEventsJSON()
      {
        jsonify<Event>(events);
      }

    public static void refreshRequestJSON()
    {
      jsonify<Request>(requests);
    }

    public static void getEventList()
      {
          foreach (Event i in events)
          {
              Console.WriteLine($"{i.organizer.name} {i.description} {i.getDate()} {i.place}");
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

      public static void addRequest(Request request)
      {
        requests.Add(request);
        jsonify<Request>(requests);
      }
  }
}

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
      static private List<Event> events     = new List<Event>();
      static private List<Student> students = new List<Student>();
        

        public static void getEventList() 
        {
            foreach(Event i in events)
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
            events.Add(newEvent);
        }
        public static void addStudent(Student student) 
        {
            students.Add(student);
        }
    }
}

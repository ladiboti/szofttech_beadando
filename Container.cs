using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Container
    {
        static private List<Event> events;
        static private List<Student> students;

        public void getEventList() 
        {
            foreach(Event i in events)
            {
                Console.WriteLine($"{i.organizer} {i.description} {i.getDate()} {i.place}");
            }
        }
        public void getStudentList() 
        {
            foreach (Student i in students)
            {
                Console.WriteLine($"{i.name} {i.neptunCode} {i.major} {i.roomNumber}");
            }
        }
        public void addEvent(Event newEvent)
        {
            events.Add(newEvent);
        }
        public void addStudent(Student student) 
        {
            students.Add(student);
        }
    }
}

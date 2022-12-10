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
        private List<Event> events;
        private List<Student> students;

        public void getEventList();
        public void getStudentList();
        public void addEvent(Event event);
        public void addStudent(Student student);
    }
}

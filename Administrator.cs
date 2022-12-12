using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Administrator : CollegePerson
    {
        public static List<Request> requestsList;

        private void addNewStudent()
        {
          Student s1 = new Student(new List<Notification>(), new List<string>(), "dummy", "asd123", "a", 1, 1, 0);

          Container.addStudent(s1);
        }

        private void promoteStudent()
        {
            throw new NotImplementedException();
        }

        public void addRequest()
        {
            throw new NotImplementedException();
        }

        private void approveRequest()
        {
            throw new NotImplementedException();
        }

        private void addNotification()
        {
            throw new NotImplementedException();
        }

        private void addObligation()
        {
            throw new NotImplementedException();
        }

        private void modifyDisciplinaryState()
        {
            throw new NotImplementedException();
        }

        private void moveToRoom()
        {
            throw new NotImplementedException();
        }
  }
}

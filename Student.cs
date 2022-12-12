using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  internal class Student : CollegePerson
  {
    public List<Notification> notificationList { get; set; }
    public List<string>       bicycles         { get; set; }

    public string name       { get; set; }
    public string neptunCode { get; }
    public string major      { get; }

    public int roomNumber { get; set; }
    public int balance    { get; set; }
    public int obligation { get; set; }
    public bool isUnderDiscipliary { get; set; }

    public Student(List<Notification> notificationList, List<string> bicycles, string name, 
      string neptunCode, string major, int roomNumber)
    {
      this.notificationList   = notificationList;
      this.bicycles           = bicycles;

      this.name               = name;
      this.neptunCode         = neptunCode;
      this.major              = major;
      this.roomNumber         = roomNumber;
      this.balance            = 0;
      this.obligation         = 0;
      this.isUnderDiscipliary = false;
  }

    private void pay()
    {
      throw new NotImplementedException();
    }

    //TODO: disciplinarystate setter???

    public void sendRequest()
    {
      throw new NotImplementedException();
    }

    public void requestGuest()
    {
      throw new NotImplementedException();
    }

    public void addBicycle()
    {
      throw new NotImplementedException();
    }
  }
}

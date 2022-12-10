using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  internal class Student : CollegePerson
  {
    private List<Notification> notificationList { get; set; }
    private List<string>       bicycles         { get; set; }

    private string name       { get; set; }
    private string neptunCode { get; }
    private string major      { get; }

    private int roomNumber { get; set; }
    private int balance    { get; set; }
    private int obligation { get; set; }

    //setter?????
    private bool isUnderDiscipliary;

    public Student(List<Notification> notificationList, List<string> bicycles, string name, 
      string neptunCode, string major, int roomNumber, 
      int balance, int obligation)
    {
      this.notificationList   = new List<Notification>();
      this.bicycles           = new List<string>();

      this.name               = name;
      this.neptunCode         = neptunCode;
      this.major              = major;
      this.roomNumber         = roomNumber;
      this.balance            = balance;
      this.obligation         = obligation;
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

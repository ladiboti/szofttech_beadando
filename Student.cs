using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  internal class Student : CollegePerson
  {
    private List<Notification> notificationList;
    private List<string>       bicycles;

    private string name;
    private string neptunCode;
    private string major;

    private int roomNumber;
    private int balance;
    private int obligation;

    private bool isUnderDiscipliary = false;

    public Student(List<Notification> notificationList, List<string> bicycles, string name, 
      string neptunCode, string major, int roomNumber, 
      int balance, int obligation)
    {
      this.notificationList = new List<Notification>();
      this.bicycles         = new List<string>();

      this.name             = name;
      this.neptunCode       = neptunCode;
      this.major            = major;
      this.roomNumber       = roomNumber;
      this.balance          = balance;
      this.obligation       = obligation;
    }

    public override void login()
    {
      throw new NotImplementedException();
    }

    public override void logout()
    {
      throw new NotImplementedException();
    }
  }
}

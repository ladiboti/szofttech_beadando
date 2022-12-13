using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  internal class Student : CollegePerson
  {
    public List<Notification> notificationList { get; set; }
    public List<string>       bicycles         { get; set; }

    //set nelkul nem megy a tostring xddd
    public string name       { get; set; }
    public string neptunCode { get; set; }
    public string major      { get; set; }

    public int roomNumber { get; set; }
    public int balance    { get; set; }
    public int obligation { get; set; }
    public bool isUnderDiscipliary { get; set; }

    public Student()
    {
      this.notificationList   = null;
      this.bicycles           = null;

      this.name               = null;
      this.neptunCode         = null;
      this.major              = null;
      this.roomNumber         = 0;
      this.balance            = 0;
      this.obligation         = 0;
      this.isUnderDiscipliary = false;
    }

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
        char command;
        Console.WriteLine("You have: " + balance + " on your account");
        Console.WriteLine("You have: " + obligation + " that you have to pay");
        Console.WriteLine("Do you want to pay your obligation? (Y/N)");
        command = Convert.ToChar(Console.Read());
        while (command != 'y' || command != 'n') {
            Console.WriteLine("Please give the valid input! (Y/N)");
            command = Convert.ToChar(Console.Read());
        }
        if (command == 'y' && balance > obligation)
        {
            balance -= obligation;
            Console.WriteLine("The pay was successful");
        }
        else if (balance < obligation)
        {
            Console.WriteLine("You don't have enough money on your account!");
        }
        else {
            Console.WriteLine("The pay was declined");
        }
    }

    public void sendRequest()
    {
      throw new NotImplementedException();
    }

    public void requestGuest()
    {
      Console.Write("The ID number of your guest: ");
      string id = Console.ReadLine();

      Console.Write("The name of your guest: ");
      string name = Console.ReadLine();

      if (name != null && id != null)
      {
        Senior.newGuestRequest(id, name);
        Console.WriteLine("Guest request was successfull");
      }
      else
      {
        Console.WriteLine("Nem adott meg értéket!");
      }
    }

    public void addBicycle()
    {
      //exeception!!!!
      Console.WriteLine("Enter the serial number of your bicycle!");
      string serialNumber = Console.ReadLine();

      bicycles.Add(serialNumber);
      Console.WriteLine("Bicycle added successfully to the database!");
    }

    public string toString()
    {

      string text = $"name: {name}\nneptuncode: {(neptunCode == null ? "null" : "megy")}\nmajor: {major}\nroom number: {roomNumber}\n" +
                    $"balance: {balance}\nobligation: {obligation}\ndisciplinary state: {(isUnderDiscipliary ? "true" : "false")}";

      text += "\nNotifications:\n";
      foreach (var notification in notificationList)
      {
        text += notification.message + "\n";
      }

      text += "\nBicycles:\n";
      foreach (var bicycle in bicycles)
      {
        text += bicycle + "\n";
      }
      return text;
    }
  }
}

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

    //áttettem az ősosztályba
    //public string name       { get; set; }
    public string neptunCode { get; set; }
    public string major      { get; set; }

    public string password   { get; set; }

    public int roomNumber { get; set; }
    public int balance;
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
      string neptunCode, string major, string password, int roomNumber)
    {
      this.notificationList   = notificationList;
      this.bicycles           = bicycles;

      this.name               = name;
      this.neptunCode         = neptunCode.ToUpper();
      this.major              = major;
      this.password           = password;
      this.roomNumber         = roomNumber;
      this.balance            = 0;
      this.obligation         = 0;
      this.isUnderDiscipliary = false;
        }


    public int getBalance() {
        return balance;
    }
    public void setBalance() {
            string username;
            string password;
            int balance;
            string balanceString;
            bool canConvert = false;
            string command;
            Console.WriteLine("Login into your bank account!");
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            Console.WriteLine("Successfully logged in!");
            Console.WriteLine("How much do you want to send?");
            balanceString = Console.ReadLine();
            canConvert = int.TryParse(balanceString, out balance);
            while ((balanceString == "" || balance <= 0) || !canConvert)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                balanceString = Console.ReadLine();
                canConvert = int.TryParse(balanceString, out balance);
            }
            Console.WriteLine($"Name: {this.name} \nAccount number: 11773470-00543175 \nSending ammount: {balance}");
            Console.WriteLine("Do you want to send it? (Y/N)");
            command = Console.ReadLine();
            while (!((command.ToUpper()).Equals("Y") || (command.ToUpper()).Equals("N"))) {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                command = Console.ReadLine();
            }
            if (command.Equals("Y"))
            {
                this.balance = balance;
                Container.refreshStudentsJSON();
                Console.WriteLine("Transaction was successful!");
            }
            else {
                Console.WriteLine("Transaction was denied!");
            }
            Console.ReadKey();
            Console.Clear();
        }
    public void pay()
    {
        string command;
        Console.WriteLine("You have: " + balance + " on your account");
        Console.WriteLine("You have: " + obligation + " that you have to pay");
        Console.WriteLine("Do you want to pay your obligation? (Y/N)");
        command = Console.ReadLine();
        while (!(command.Equals("Y") || command.Equals("N"))) {
            Console.WriteLine("Please give the valid input! (Y/N)");
            command = Console.ReadLine();
        }
        if (command.Equals("Y") && balance >= obligation && obligation > 0 && balance > 0)
        {
            int deductedDebit = obligation;
            balance -= deductedDebit;
            obligation -= deductedDebit;
            Container.refreshStudentsJSON();
            Console.WriteLine("The pay was successful");
        }
        else if (command.Equals("Y") && balance <= obligation)
        {
            Console.WriteLine("You don't have enough money on your account!");
        }
        else {
            Console.WriteLine("The pay was declined");
        }
            Console.ReadKey();
            Console.Clear();
        }

    public void sendRequest()
    {
        string message;
        Console.WriteLine("Please summarize your request!");
        message = Console.ReadLine();
        while (message == "") {
            Console.WriteLine("The given input is empty! Please write something!");
            message = Console.ReadLine();
        }
        Request request = new Request(this, message);
        Administrator.addRequest(request);
        Console.WriteLine("The request sent successfully!");
            Console.ReadKey();
            Console.Clear();
        }

    public void requestGuest()
    {
        Console.Write("The ID number of your guest: ");
        string id = Console.ReadLine().ToUpper();
        while (id == "") {
            Console.WriteLine("Invalid input! Please give a valid input!");
            id = Console.ReadLine();
        }

        Console.Write("The name of your guest: ");
        string name = Console.ReadLine();
        while (name == "") {
            Console.WriteLine("Invalid input! Please give a valid input!");
            name = Console.ReadLine();
        }

        if (name != null && id != null)
        {
            Senior.newGuestRequest(id, name);
            Console.WriteLine("Guest request was successfull");
        }
            Console.ReadKey();
            Console.Clear();
        }

    public void addBicycle()
    {
      //exeception!!!!
      Console.WriteLine("Enter the serial number of your bicycle!");
      string serialNumber = Console.ReadLine();

      bicycles.Add(serialNumber);
        Container.refreshStudentsJSON();
      Console.WriteLine("Bicycle added successfully to the database!");
            Console.ReadKey();
            Console.Clear();
        }

    public string toString()
    {

      string text = $"name: {name}\nneptuncode: {(neptunCode)}\nmajor: {major}\nroom number: {roomNumber}\n" +
                    $"balance: {balance}\nobligation: {obligation}\ndisciplinary state: {(isUnderDiscipliary ? "true" : "false")}\n" +
                    $"password: {password}";

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
            Console.ReadKey();
            Console.Clear();
        }

    public void showNotifications()
    {
      Console.WriteLine("Your notifications are the following:");
      foreach (var notification in notificationList)
      {
        //a date null
        Console.WriteLine(
          $"-{notification.message}\n\t{notification.messageDate}"
        );
      }
            Console.ReadKey();
            Console.Clear();
        }
    public override void menu()
    {
        do
        {
            Console.WriteLine("DEBUG: STUDENT MENU");

            Console.WriteLine(
                $" 1: Pay your obligation\n" +
                $" 2: Send request to the administrator\n" +
                $" 3: Send a guest request\n" +
                $" 4: Add a bicycle to the virtual storage\n" +
                $" 5: Set your balance\n" +
                $" 6: Show your notifications\n" +
                $"99: Log out"
            );
            Console.WriteLine("Here is your functions, tell me what do you want to do!");
            //ki kell irni a lehetosegeket :(((((
            bool canConvert = false;
            int actionNumber;
            string actionNumberString = Console.ReadLine();
            canConvert = int.TryParse(actionNumberString, out actionNumber);
            while ((actionNumberString == "" || actionNumber <= 0) || !canConvert)
            {
                Console.WriteLine("The given input is invalid! Please give valid input!");
                actionNumberString = Console.ReadLine();
                canConvert = int.TryParse(actionNumberString, out actionNumber);
            }
            switch (actionNumber)
            {
                case 1:
                    pay();
                    break;
                case 2:
                    sendRequest();
                    break;
                case 3:
                    requestGuest();
                    break;
                case 4:
                    addBicycle();
                    break;
                case 5:
                    setBalance();
                    break;
                case 6:
                    showNotifications();
                    break;
                case 99:
                    logout();
                    break;
                default:
                    Console.WriteLine("Sorry, but this function doesn't exist");
                    break;
            }
        } while (true);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
  internal class Notification
  {
        public string message { get; }
        public string messageDate { get; }
        public Notification(string message, string messageDate)
        {
            this.message = message;
            this.messageDate = messageDate;
        }
    }
}

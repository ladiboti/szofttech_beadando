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
        private Date sentMessageDate;
        public Notification(string message, Date sentMessageDate) {
            this.message = message;
            this.sentMessageDate = sentMessageDate;
        }
        public string getSentMessageDate() {
            return sentMessageDate.getDate();
        }
  }
}

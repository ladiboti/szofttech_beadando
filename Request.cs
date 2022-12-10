using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Request
    {
        private Student sender { get; }
        private string message { get; }
        private int status { get; set; }

        public Request(Student sender, string message)
        {
            this.sender = sender;
            this.message = message;
            this.status = 0;
        }

    }
}

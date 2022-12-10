using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class AccommodationTicket
    {
        public string guestId { get; }
        public string guestName { get; }
        public Date expireDate { get;  }
        public AccommodationTicket(string guestId, string guestName, Date expireDate)
        {
            this.guestId = guestId;
            this.guestName = guestName;
            this.expireDate = expireDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class AccommodationTicket
    {
        private String guestId;
        private String guestName;
        private Date expireDate;
        public String getGuestId() {
            return guestId;
        }
        public String getGuestName() {
            return guestName;
        }
        public Date getExpireDate()
        {
            return expireDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Event
    {
        private Senior organizer;
        private String descripiton;
        private Date date;
        private String place;

        public Senior getOrganizer();
        public String getDescription();
        public Date getDate();
        public String getPlace();
    }
}

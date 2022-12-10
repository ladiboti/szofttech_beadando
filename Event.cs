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

        public Senior getOrganizer() {
            return organizer;
        }
        public String getDescription() {
            return descripiton;
        }
        public Date getDate() {
            return date;
        }
        public String getPlace() {
            return place;
        } 
    }
}

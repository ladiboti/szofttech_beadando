using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szofttech
{
    internal class Date
    {
        private int year;
        private int month;
        private int day;
        private int hour;
        private int minute;
        public Date(int year, int month, int day, int hour, int minute)
        {
            this.year   = year;
            this.month  = month;
            this.day    = day;
            this.hour   = hour;
            this.minute = minute;
        }

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = 0;
            this.minute = 0;
        }
    //convert kell???
        public string getDateString() {
            string date = $"{year}.{month}.{day}. {hour}:{minute}".ToString();
            return date;
        }
    }
}

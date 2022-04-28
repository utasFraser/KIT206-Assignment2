using System;
using System.Collections.Generic;
using System.Text;

namespace KIT206_Assignment2
{
    public class Consultation
    {
        public enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

        // Staff ID, foreign key
        public int staff_id { get; set; }
        public Day day { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
    }
}

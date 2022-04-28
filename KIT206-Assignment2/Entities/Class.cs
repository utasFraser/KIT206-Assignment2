using System;
using System.Collections.Generic;
using System.Text;

namespace KIT206_Assignment2
{
    public class Class
    {
        public enum Campus
        {
            Hobart,
            Launceston,
        }

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

        public enum Type
        {
            Lecture,
            Tutorial,
            Practical,
            Workshop,
        }

        public string unit_code { get; set; }
        public Campus campus { get; set; }
        public Day day { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
        public Type type { get; set; }
        public string room { get; set; }
        // Staff ID, foreign key
        public int staff { get; set; }
    }
}

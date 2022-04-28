using System;
using System.Collections.Generic;
using System.Text;

namespace KIT206_Assignment2
{
    public class Staff
    {
        public enum Campus
        {
            Hobart,
            Launceston,
        }

        public enum Category
        {
            academic,
            technical,
            admin,
            casual,
        }

        // Staff ID, primary key
        public int id { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string title { get; set; }
        public Campus campus { get; set; }
        public string phone { get; set; }
        public string room { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public Category category { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, Given Name: {1}, Family Name: {2}", id, given_name, family_name);
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIT206_Assignment2
{
    public class ClassList
    {
        private List<Class> class;
        public List<Unit> Units { get { return class; } set { } }

        private ObservableCollection<Unit> viewableClass;
        public ObservableCollection<Unit> VisibleUnits { get { return viewableClass; } set { } }

        public UnitClass()
        {
            class = sqlConn.LoadAllClass();
            viewableClass = new ObservableCollection<Class>(class);
        }
    }
}

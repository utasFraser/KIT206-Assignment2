using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIT206_Assignment2
{
    public class ClassList
    {
        private List<Class> _classes;
        public List<Class> Classes { get { return _classes; } set { } }

        private ObservableCollection<Class> viewableClasses;
        public ObservableCollection<Class> VisibleClasses { get { return viewableClasses; } set { } }

        public ClassList()
        {
            _classes = sqlConn.LoadAllClasses();
            viewableClasses = new ObservableCollection<Class>(_classes);
        }
    }
}

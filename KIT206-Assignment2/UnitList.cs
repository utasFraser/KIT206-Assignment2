using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIT206_Assignment2
{
    public class UnitList
    {
        private List<Unit> unit;
        public List<Unit> Units { get { return unit; } set { } }

        private ObservableCollection<Unit> viewableUnit;
        public ObservableCollection<Unit> VisibleUnits { get { return viewableUnit; } set { } }

        public UnitList ()
        {
            unit = sqlConn.LoadAllUnits();
            viewableUnit = new ObservableCollection<Unit>(unit);
        }
    }
}

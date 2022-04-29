using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KIT206_Assignment2
{
    class StaffList
    {
        private List<Staff> _staff;
        public List<Staff> Staff { get { return _staff; } set { } }

        private ObservableCollection<Staff> viewableStaff;
        public ObservableCollection<Staff> VisibleStaff { get { return viewableStaff; } set { } }

        public StaffList()
        {
            _staff = sqlConn.LoadAllStaff();
            viewableStaff = new ObservableCollection<Staff>(_staff);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KIT206_Assignment2
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : UserControl
    {
        private MainWindow mainWindow;

        private StaffList staffList = new StaffList();

        public StaffView(MainWindow mainWin)
        {
            mainWindow = mainWin;

            InitializeComponent();

            table.ItemsSource = staffList.VisibleStaff;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditStaffDetails details = new EditStaffDetails(new Staff(), false);
            details.ShowDialog();
            staffList.Staff.Add(details.staffMember);

            table.ItemsSource = null;
            table.ItemsSource = staffList.VisibleStaff;
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            int staffIndex = table.SelectedIndex;
            if (staffIndex < 0 || staffIndex >= table.Items.Count)
                return; // don't select any invalid staff members

            EditStaffDetails details = new EditStaffDetails(staffList.Staff[staffIndex], true);
            details.ShowDialog();
            staffList.Staff[staffIndex] = details.staffMember;

            table.ItemsSource = null;
            table.ItemsSource = staffList.VisibleStaff;
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.unitView);
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.classView);
        }

        private void consultationButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.consultationView);
        }
    }
}

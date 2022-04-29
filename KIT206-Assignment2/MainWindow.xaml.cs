using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace KIT206_Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List of all staff members
        public static List<Staff> staffList = new List<Staff>();
        public static List<Consultation> consultationList = new List<Consultation>();

        public MainWindow()
        {
            InitializeComponent();

            staffList = sqlConn.LoadAllStaff();
            // sqlConn.LoadAllClasses();
            consultationList = sqlConn.LoadAllConsultations();
            // sqlConn.LoadAllUnits();

            staffListBox.Items.Clear();
            foreach (var staff in staffList)
            {
                staffListBox.Items.Add(staff);
            }
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            int staffIndex = staffListBox.SelectedIndex;
            if (staffIndex < 0 || staffIndex >= staffList.Count)
                return; // don't select any invalid staff members

            // TODO: add code to open the staff details window
            Console.WriteLine($"Staff {staffIndex} Details Pressed");

            EditStaffDetails details = new EditStaffDetails(staffList[staffIndex]);
            details.ShowDialog();
            staffList[staffIndex] = details.staffMember;
            staffListBox.Items.RemoveAt(staffIndex);
            staffListBox.Items.Insert(staffIndex, details.staffMember);
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            // With just one window we don't need to do too much here
            // It's disabled by default so its obvious it shouldn't be pressed yet

            // later on we'll probably have this button return us to the staff list
            Console.WriteLine("Staff Button Pressed");
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add code to change/open unit view
            Console.WriteLine("Unit Button Pressed");
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add code to change/open class view
            Console.WriteLine("Class Button Pressed");
        }

        private void consultationButton_Click(object sender, RoutedEventArgs e)
        {
            staffListBox.Items.Clear();

            foreach (var consultation in consultationList)
            {
                staffListBox.Items.Add(consultation);
            }
            staffButton.IsEnabled = true;
            consultationButton.IsEnabled = false;
            detailsButton.Visibility = Visibility.Hidden;
            btnAddConsultation.Visibility = Visibility.Visible;
            btnEditConsultation.Visibility = Visibility.Visible;
            btnRemoveConsultation.Visibility = Visibility.Visible;
            Console.WriteLine("Consultation Button Pressed");
        }
    }
}

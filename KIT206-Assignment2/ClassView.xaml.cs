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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KIT206_Assignment2
{
    /// <summary>
    /// Interaction logic for ClassListView.xaml
    /// </summary>
    public partial class ClassView : UserControl
    {
        private MainWindow mainWindow;

        private ClassList classList = new ClassList();

        public ClassView(MainWindow mainWin)
        {
            mainWindow = mainWin;

            InitializeComponent();

            table.ItemsSource = classList.VisibleClasses;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // EditStaffDetails details = new EditStaffDetails(new Staff(), false);
            // details.ShowDialog();
            // classList.Classes.Add(details.staffMember);

            table.ItemsSource = null;
            table.ItemsSource = classList.VisibleClasses;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int classIndex = table.SelectedIndex;
            if (classIndex < 0 || classIndex >= table.Items.Count)
                return; // don't select any invalid staff members

            // EditStaffDetails details = new EditStaffDetails(classList.Classes[staffIndex], true);
            // details.ShowDialog();
            // classList.Classes[staffIndex] = details.staffMember;

            table.ItemsSource = null;
            table.ItemsSource = classList.VisibleClasses;
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.staffView);
        }

        private void unitButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.unitView);
        }

        private void consultationButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.consultationView);
        }
    }
}

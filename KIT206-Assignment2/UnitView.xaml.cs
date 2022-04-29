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
    /// Interaction logic for UnitView.xaml
    /// </summary>
    public partial class UnitView : UserControl
    {
        private MainWindow mainWindow;

        private UnitList unitList = new UnitList();

        public UnitView(MainWindow mainWin)
        {
            mainWindow = mainWin;

            InitializeComponent();

            var list = unitList.VisibleUnits;
            table.ItemsSource = list;
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.viewGrid.Children.Clear();
            mainWindow.viewGrid.Children.Add(mainWindow.staffView);
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

        private void EditCoordinator_Click(object sender, RoutedEventArgs e)
        {
            coordinator.IsReadOnly = false;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

            EditUnitDetails details = new EditUnitDetails(new Unit());
            details.ShowDialog();
            unitList.Units.Add(details.unitDetail);

            table.ItemsSource = null;
            table.ItemsSource = unitList.VisibleUnits;

            Console.WriteLine("Class Button Pressed");
        }
    }
}

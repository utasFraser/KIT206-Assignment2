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
            //DataGridTextColumn.IsReadOnly = true;
            Console.WriteLine("Class Button Pressed");
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add code to change/open class view
            Console.WriteLine("Class Button Pressed");
        }
    }
}

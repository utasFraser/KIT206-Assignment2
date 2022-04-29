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
    public partial class UnitView : Window
    {
        private UnitList unitList = new UnitList();

        public UnitView()
        {
            InitializeComponent();

            var list = unitList.VisibleUnits;
            table.ItemsSource = list;
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
            // TODO: add code to change/open consultation view
            Console.WriteLine("Consultation Button Pressed");
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

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
    /// Interaction logic for ConsultationView.xaml
    /// </summary>
    public partial class ConsultationView : UserControl
    {
        private MainWindow mainWindow;

        private ConsultationList consultationList = new ConsultationList();

        public ConsultationView(MainWindow mainWin)
        {
            mainWindow = mainWin;

            InitializeComponent();

            table.ItemsSource = consultationList.VisibleConsultations;
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

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: add code to change/open class view
            Console.WriteLine("Class Button Pressed");
        }

        private void btnAddConsultation_Click(object sender, RoutedEventArgs e)
        {
            AddConsultation popup = new AddConsultation();
            popup.ShowDialog();
        }

        private void btnEditConsultation_Click(object sender, RoutedEventArgs e)
        {
            int itemIndex = table.SelectedIndex;
            EditConsultation editConsultation = new EditConsultation(consultationList.Consultations[itemIndex]);
            editConsultation.ShowDialog();
            consultationList.Consultations[itemIndex] = editConsultation.change;


            table.ItemsSource = null;
            table.ItemsSource = consultationList.VisibleConsultations;
        }

        private void btnRemoveConsultation_Click(object sender, RoutedEventArgs e)
        {
            int itemIndex = table.SelectedIndex;
            sqlConn.RemoveConsultation(consultationList.Consultations[itemIndex]);
            consultationList.Consultations.RemoveAt(itemIndex);
            consultationList.Invalidate();

            table.ItemsSource = null;
            table.ItemsSource = consultationList.VisibleConsultations;
        }
    }
}

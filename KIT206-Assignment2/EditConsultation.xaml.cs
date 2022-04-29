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
    /// Interaction logic for EditConsultation.xaml
    /// </summary>
    public partial class EditConsultation : Window
    {
        public Consultation change;
        public EditConsultation(Consultation consultation)
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(Consultation.Day)))
            {
                boxDay.Items.Add(item);
            }

            change = consultation;
            txtStaffID.Text = change.staff_id.ToString();
            boxDay.SelectedItem = change.day;
            txtStart.Text = change.start.ToString();
            txtEnd.Text = change.end.ToString();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
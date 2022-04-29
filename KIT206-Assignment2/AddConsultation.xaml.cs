using MySql.Data.MySqlClient;
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
    /// Interaction logic for AddConsultation.xaml
    /// </summary>
    public partial class AddConsultation : Window
    {
        public AddConsultation()
        {
            InitializeComponent();
            //adding selection to the Day combo box
            foreach (var item in Enum.GetValues(typeof(Consultation.Day)))
            {
                boxDay.Items.Add(item);
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Consultation consultation = new Consultation();
            int id;
            if (!int.TryParse(txtStaffID.Text, out id))
            {
                MessageBox.Show("Please check the staff ID format.");
            }
            consultation.staff_id = id;
            consultation.day = (Consultation.Day)boxDay.SelectedItem;
            TimeSpan start, end;
            if (!TimeSpan.TryParse(txtStart.Text, out start))
            {
                MessageBox.Show("Please check the start time format.");
            }
            if (!TimeSpan.TryParse(txtEnd.Text, out end))
            {
                MessageBox.Show("Please check the end time format.");
            }
            consultation.start = start;
            consultation.end = end;

            sqlConn.AddConsultation(consultation);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
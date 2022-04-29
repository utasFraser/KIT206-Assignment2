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
        public EditConsultation()
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(Consultation.Day)))
            {
                boxDay.Items.Add(item);
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

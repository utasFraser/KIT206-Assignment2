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
            List<Consultation> consultations = new List<Consultation>();

            MySqlConnection conn = sqlConn.GetConnection();
            MySqlDataReader rdr = null;
            int id;
            if (!int.TryParse(txtStaffID.Text, out id)) 
            {
                MessageBox.Show("Please check the staff ID format.");
            }
            Consultation.Day day = (Consultation.Day)boxDay.SelectedItem;
            TimeSpan start, end;
            if(!TimeSpan.TryParse(txtStart.Text, out start))
            {
                MessageBox.Show("Please check the start time format.");
            }
            if (!TimeSpan.TryParse(txtEnd.Text, out end))
            {
                MessageBox.Show("Please check the end time format.");
            }

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("insert into consultation (staff_id, day, start, end) values (" + id + ", " + day + ", " + start + ", " + end + ")", conn);
                rdr = cmd.ExecuteReader();

            }
            catch (MySqlException ee)
            {
                Console.WriteLine("Error connecting to database: " + ee);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

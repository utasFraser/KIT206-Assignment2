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
using System.IO;

namespace KIT206_Assignment2
{
    /// <summary>
    /// Interaction logic for EditStaffDetails.xaml
    /// </summary>
    public partial class EditUnitDetails : Window
    {

        public Unit unitDetail;


        public EditUnitDetails(Unit unit, bool isEditing = true)
        {

            InitializeComponent();

            unitDetail = unit;


            codeBox.Text = unitDetail.code;
            staffIDBox.Text = unitDetail.coordinator.ToString();
            titleBox.Text = unitDetail.title;


            saveButton.Content = isEditing ? "Update Staff Member" : "Add Staff Member";
            Title = isEditing ? "Edit Staff Details" : "Add Staff Member";
        }

        private void staffIDBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
                unitDetail.coordinator = Int32.Parse(staffIDBox.Text);
            }
            catch
            {
                unitDetail.coordinator = 0;
                staffIDBox.Text = "0";
            }
        }

        private void codeBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            unitDetail.code = codeBox.Text;
        }

        private void titleBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            unitDetail.title = titleBox.Text;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.UploadNewUnit(unitDetail);
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

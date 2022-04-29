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
    public partial class EditStaffDetails : Window
    {

        public Staff staffMember;


        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public EditStaffDetails(Staff staff)
        {
            staffMember = staff;

            InitializeComponent();
            
            staffIDBox.Text             = staff.id.ToString();
            nameBox.Text                = staff.given_name;
            lNameBox.Text               = staff.family_name;
            titleBox.Text               = staff.title;
            campusBox.SelectedIndex     = (int)staff.campus;
            phoneBox.Text               = staff.phone;
            roomBox.Text                = staff.room;
            emailBox.Text               = staff.email;
            categoryBox.SelectedIndex   = (int)staff.category;

            if (staff.photo.Length > 0)
                photo.Source = ToImage(staff.photo);
        }

        private void staffIDBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
                staffMember.id = Int32.Parse(staffIDBox.Text);
            }
            catch
            {
                staffMember.id = 0;
                staffIDBox.Text = "0";
            }
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.given_name = nameBox.Text;
        }

        private void lNameBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.family_name = lNameBox.Text;
        }

        private void titleBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.title = titleBox.Text;
        }

        private void CampusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campusBox.SelectedIndex == -1)
                return;

            staffMember.campus = (Staff.Campus)campusBox.SelectedIndex;
        }

        private void phoneBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.phone = phoneBox.Text;
        }

        private void roomBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.room = roomBox.Text;
        }

        private void emailBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            staffMember.email = emailBox.Text;
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryBox.SelectedIndex == -1)
                return;

            staffMember.category = (Staff.Category)categoryBox.SelectedIndex;
        }

        private void changeImgButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            //For any other formats
            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (dialog.ShowDialog() == true)
            {
                staffMember.photo = File.ReadAllBytes(dialog.FileName);

                if (staffMember.photo.Length > 0)
                    photo.Source = ToImage(staffMember.photo);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.UploadStaffMember(staffMember);
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

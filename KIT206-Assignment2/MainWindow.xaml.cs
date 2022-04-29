using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace KIT206_Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StaffView staffView;
        public UnitView unitView;
        public ClassView classView;
        public ConsultationView consultationView;

        public MainWindow()
        {
            InitializeComponent();

            staffView = new StaffView(this);
            unitView = new UnitView(this);
            classView = new ClassView(this);
            consultationView = new ConsultationView(this);

            viewGrid.Children.Add(staffView);
        }
    }
}

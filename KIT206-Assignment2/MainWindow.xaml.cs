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
        // List of all staff members
        public static List<Staff> staffList = new List<Staff>();
        public static List<Consultation> consultationList = new List<Consultation>();

        public StaffView staffView;
        public UnitView unitView;
        public ConsultationView consultationView;

        public MainWindow()
        {
            InitializeComponent();

            consultationList = sqlConn.LoadAllConsultations();

            staffView = new StaffView(this);
            unitView = new UnitView(this);
            consultationView = new ConsultationView(this);

            viewGrid.Children.Add(staffView);
        }
    }
}

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
        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
        private const string db = "hris";
        private const string user = "kit206g11a";
        private const string pass = "group11a";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static List<Staff> LoadAllStaff()
        {
            List<Staff> staff = new List<Staff>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, campus, phone, room, email, photo, category from staff", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var campus = Staff.Campus.Hobart;
                    var category = Staff.Category.casual;
                    var photo = "";
                    try
                    {
                        campus = ParseEnum<Staff.Campus>(rdr.GetString(4));
                    }
                    catch { }

                    try
                    {
                        photo = rdr.GetString(8);
                    }
                    catch { }

                    try
                    {
                        category = ParseEnum<Staff.Category>(rdr.GetString(9));
                    }
                    catch { }

                    staff.Add(new Staff
                    {
                        id = rdr.GetInt32(0),
                        given_name = rdr.GetString(1),
                        family_name = rdr.GetString(2),
                        title = rdr.GetString(3),
                        campus = campus,
                        phone = rdr.GetString(5),
                        room = rdr.GetString(6),
                        email = rdr.GetString(7),
                        photo = photo,
                        category = category,
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
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

            return staff;
        }

        public static List<Class> LoadAllClasses()
        {
            List<Class> classes = new List<Class>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select unit_code, campus, day, start, end, type, room, staff from class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    classes.Add(new Class
                    {
                        unit_code = rdr.GetString(0),
                        campus = ParseEnum<Class.Campus>(rdr.GetString(1)),
                        day = ParseEnum<Class.Day>(rdr.GetString(2)),
                        start = rdr.GetTimeSpan(3),
                        end = rdr.GetTimeSpan(4),
                        type = ParseEnum<Class.Type>(rdr.GetString(5)),
                        room = rdr.GetString(6),
                        staff = rdr.GetInt32(7),
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
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

            return classes;
        }

        public static List<Unit> LoadAllUnits()
        {
            List<Unit> units = new List<Unit>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select code, title, coordinator from unit", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    units.Add(new Unit
                    {
                        code = rdr.GetString(0),
                        title = rdr.GetString(1),
                        coordinator = rdr.GetInt32(2),
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
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

            return units;
        }

        public static List<Consultation> LoadAllConsultations()
        {
            List<Consultation> consultations = new List<Consultation>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select staff_id, day, start, end from consultation", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    consultations.Add(new Consultation
                    {
                        staff_id = rdr.GetInt32(0),
                        day = ParseEnum<Consultation.Day>(rdr.GetString(1)),
                        start = rdr.GetTimeSpan(2),
                        end = rdr.GetTimeSpan(3),
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
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

            return consultations;
        }

        // List of all staff members
        public static List<Staff> staffList = new List<Staff>();

        public MainWindow()
        {
            InitializeComponent();

            staffList = LoadAllStaff();
            // LoadAllClasses();
            // LoadAllConsultations();
            // LoadAllUnits();

            staffListBox.Items.Clear();
            foreach (var staff in staffList)
            {
                staffListBox.Items.Add(staff);
            }
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            uint staffIndex = (uint)staffListBox.SelectedIndex;
            if (staffIndex >= staffList.Count)
                return; // don't select any invalid staff members

            // TODO: add code to open the staff details window
            Console.WriteLine($"Staff {staffIndex} Details Pressed");
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
    }
}

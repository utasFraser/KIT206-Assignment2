using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KIT206_Assignment2
{
    public static class sqlConn
    {
        private const string db = "hris";
        private const string user = "kit206g11a";
        private const string pass = "group11a";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        public static MySqlConnection GetConnection()
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
                    byte[] photo = null;
                    try
                    {
                        campus = ParseEnum<Staff.Campus>(rdr.GetString(4));
                    }
                    catch { }

                    try
                    {
                        photo = (byte[])(rdr["photo"]);
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

        public static void UploadStaffMember(Staff staff, bool isEditing = false)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                if (isEditing)
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = $"UPDATE staff SET given_name = '{staff.given_name}', family_name = '{staff.family_name}', title = '{staff.title}', photo = ?photo, category = '{staff.category}' WHERE id = {staff.id};";

                        MySqlParameter photoParam = new MySqlParameter();
                        photoParam.ParameterName = "?photo";
                        photoParam.MySqlDbType = MySqlDbType.MediumBlob;
                        photoParam.Size = staff.photo.Length;
                        photoParam.Value = staff.photo;
                        command.Parameters.Add(photoParam);

                        command.ExecuteNonQuery();

                    }
                }
                else
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = $"INSERT INTO staff (id, given_name, family_name, title, campus, phone, room, email, photo, category) VALUES ('{staff.id}', '{staff.given_name}', '{staff.family_name}', '{staff.title}', '{staff.campus}', '{staff.phone}', '{staff.room}', '{staff.email}', ?photo, '{staff.category}');";

                        MySqlParameter photoParam = new MySqlParameter();
                        photoParam.ParameterName = "?photo";
                        photoParam.MySqlDbType = MySqlDbType.MediumBlob;
                        photoParam.Size = staff.photo.Length;
                        photoParam.Value = staff.photo;
                        command.Parameters.Add(photoParam);

                        command.ExecuteNonQuery();

                    }
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
        }

        //dont touch, its working
        public static void AddConsultation(Consultation consultation)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"insert into consultation values ('{consultation.staff_id}', '{consultation.day}', '{consultation.start}', '{consultation.end}') ;";
                    command.ExecuteNonQuery();
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
        }
        public static void UploadConsultation(Consultation consultation)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"update consultation set staff_id = '{consultation.staff_id}', day = '{consultation.day}', start = '{consultation.start}', end = '{consultation.end}' WHERE staff_id = '{consultation.staff_id}' and day = '{consultation.day}';";
                    MessageBox.Show(command.CommandText);  //for debugging
                    command.ExecuteNonQuery();
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
        }

        //dont touch, its working
        public static void RemoveConsultation(Consultation consultation)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"delete from consultation where staff_id = '{consultation.staff_id}' and day = '{consultation.day}' and start = '{consultation.start}' and end = '{consultation.end}';";
                    command.ExecuteNonQuery();
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
        }


    }
}

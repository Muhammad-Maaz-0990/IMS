using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;



namespace MDmobile
{
    class sql_con
    {

        public static string connectionString = "Data Source=MDdb.db;Version=3;";
        public static SQLiteConnection conn = new SQLiteConnection(connectionString);

        public static bool delete_table(string t_name)
        {
            try
            {
                open_connection(); // Open the connection

                string query = $"DELETE FROM {t_name}";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery(); // Execute the query

                    // Return true if one row is affected
                    return rowsAffected == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK);
                return false; // Return false if an exception occurs
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }


        public static bool insert_query(string username, string password, string email)
        {
            try
            {
                open_connection(); // Open the connection

                string query = "INSERT INTO login (username, password, email) VALUES(@username, @password, @email)";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    // Add parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);

                    int rowsAffected = command.ExecuteNonQuery(); // Execute the query

                    // Return true if one row is affected
                    return rowsAffected == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return false; // Return false if an exception occurs
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        public static int select_query(string query, string user, string pass_value,string check)
        {
            try
            {
                open_connection(); // Open the connection

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    if(check == "Login")
                    {
                        // Bind parameters to the query
                        command.Parameters.AddWithValue("@username", user);
                        command.Parameters.AddWithValue("@password", pass_value);
                        SQLiteDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            Form1.Email = reader["email"].ToString();
                            Form1.user_permissions = reader["permission"].ToString();
                            if (reader.Read())
                            {
                                return 0;
                            }
                            return 1;
                        }
                        return 0;
                    }
                    else if (check == "Sign_up")
                    {
                        // Bind parameters to the query
                        command.Parameters.AddWithValue("@username", user);
                        command.Parameters.AddWithValue("@email", pass_value);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count > 0)
                        {
                            return 1; // Record found
                        }
                        else
                        {
                            return 0; // No matching record
                        }
                    }
                    else if (check == "Forget")
                    {
                        command.Parameters.AddWithValue("@email", pass_value);
                        SQLiteDataReader reader = command.ExecuteReader();
                        if(reader.Read())
                        {
                            Form1.Password = reader["password"].ToString();
                            if(reader.Read())
                            {
                                return 0; 
                            }
                            return 1;
                        }
                        return 0;
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // Show error message if any exception occurs
                MessageBox.Show(ex.Message, "123Error", MessageBoxButtons.OK);
                return 2; // Error occurred
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        public static bool insert_address_query(string username, string pass_address)
        {
            try
            {
                open_connection(); // Open the connection

                string query = "INSERT INTO user_log (username, mac_address) VALUES(@username, @address)";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    // Add parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@address", pass_address);

                    int rowsAffected = command.ExecuteNonQuery(); // Execute the query

                    // Return true if one row is affected
                    return rowsAffected == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return false; // Return false if an exception occurs
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        public static int select_address_query(string user, string pass_address)
        {
            try
            {
                open_connection(); // Open the connection
                string query = "SELECT COUNT(*) FROM user_log WHERE username = @username AND mac_address = @address";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {

                    // Bind parameters to the query
                    command.Parameters.AddWithValue("@username", user);
                    command.Parameters.AddWithValue("@address", pass_address);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        return 1; // Record found
                    }
                    else
                    {
                        return 0; // No matching record
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error message if any exception occurs
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                return 2; // Error occurred
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        public static void open_connection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        public static void close_connection()
        {
            conn.Close();
        }

    }
}

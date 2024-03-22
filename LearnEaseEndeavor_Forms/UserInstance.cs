using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LearnEaseEndeavor_Forms
{
    class UserInstance
    {
        private static UserInstance obj = null;
        private User user;

        private UserInstance() 
        {
            user = null;
        }

        public static UserInstance getInstance()
        {
            if (obj == null)
                obj = new UserInstance();
            return obj;
        }

        public User getUser()
        {
            return user;
        }

        public User setUser(string email, string password)
        {
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            string query = "SELECT * FROM [User] WHERE [email] = '" + email + "' AND [password] = '" + password + "'";

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count == 1)
                {
                    DataRow row = dtable.Rows[0];
                    string userType = row["type"].ToString();

                    if (userType == "Student")
                    {
                        query = "SELECT * FROM [Student] WHERE [email] = '" + email + "'";
                        try
                        {
                            sda = new SqlDataAdapter(query, connection);
                            dtable = new DataTable();
                            sda.Fill(dtable);
                            row = dtable.Rows[0];
                            int rollNo = int.Parse(row["roll_number"].ToString());
                            int batch = int.Parse(row["batch"].ToString());
                            string name = row["name"].ToString();
                            string phoneNo = row["phone_number"].ToString();
                            user = new Student(rollNo, batch, name, phoneNo, email, password);
                        }
                        catch (Exception ex)
                        {
                            // Log the exception for debugging purposes
                            Console.WriteLine("An error occurred: " + ex.Message);
                            return null;
                        }
                    }
                    else if (userType == "Teacher")
                    {
                        query = "SELECT * FROM [Teacher] WHERE [email] = '" + email + "'";
                        try
                        {
                            sda = new SqlDataAdapter(query, connection);
                            dtable = new DataTable();
                            sda.Fill(dtable);
                            row = dtable.Rows[0];
                            int rollNo = int.Parse(row["roll_number"].ToString());
                            bool visiting = (bool)row["visiting"]; // Assuming visiting is a boolean column
                            string name = row["name"].ToString();
                            string phoneNo = row["phone_number"].ToString();
                            user = new Teacher(rollNo, visiting, name, phoneNo, email, password);
                        }
                        catch (Exception ex)
                        {
                            // Log the exception for debugging purposes
                            Console.WriteLine("An error occurred: " + ex.Message);
                            return null;
                        }
                        
                    }

                    // Return the user object here
                    return user;
                }
                else if (dtable.Rows.Count == 0)
                {
                    // No user found with provided credentials
                    Console.WriteLine("No user found with provided credentials.");
                    return null;
                }
                else
                {
                    // More than one user found with provided credentials (shouldn't happen)
                    Console.WriteLine("More than one user found with provided credentials.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

    }
}

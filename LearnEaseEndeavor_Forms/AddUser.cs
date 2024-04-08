using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LearnEaseEndeavor_Forms
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection DBinstance = DBConnection.getInstance();
            SqlConnection connection = DBinstance.getConnection();

            if (!radioButton1.Checked && !radioButton2.Checked)
                return;
            string Name = textBox1.Text;
            string PhoneNumber = textBox2.Text;
            string email = textBox3.Text;
            int batch_or_visiting = int.Parse( textBox4.Text );
            string password = textBox5.Text;
            if (radioButton1.Checked)
            {
                string query = "INSERT INTO [User] ([email], [password], [type]) VALUES('" + email + "', '" + password + "', 'Student'); ";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Rows inserted successfully
                        Console.WriteLine("Record inserted successfully in Users");
                        query = "INSERT INTO [Student] ([name], [phone_number], [batch], [email]) VALUES('" + Name + "', '" + PhoneNumber + "', " + batch_or_visiting.ToString() + ", '" + email + "'); ";
                        command = new SqlCommand(query, connection);
                    }
                    else
                    {
                        // No rows were inserted
                        Console.WriteLine("No rows were inserted");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.WriteLine("An error occurred while inserting record: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Rows inserted successfully
                        Console.WriteLine("Record inserted successfully on Student");
                    }
                    else
                    {
                        // No rows were inserted
                        Console.WriteLine("No rows were inserted");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.WriteLine("An error occurred while inserting record: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }
            if (radioButton2.Checked)
            {
                if (batch_or_visiting != 0 && batch_or_visiting != 1)
                {
                    return;
                    Console.WriteLine("invalid visiting detected");
                }
                string query = "INSERT INTO [User] ([email], [password], [type]) VALUES('" + email + "', '" + password + "', 'Teacher'); ";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Rows inserted successfully
                        Console.WriteLine("Record inserted successfully in Users");
                        query = "INSERT INTO [Teacher] ([name], [phone_number], [visiting], [email]) VALUES('" + Name + "', '" + PhoneNumber + "', " + batch_or_visiting.ToString() + ", '" + email + "'); ";
                        command = new SqlCommand(query, connection);
                    }
                    else
                    {
                        // No rows were inserted
                        Console.WriteLine("No rows were inserted");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.WriteLine("An error occurred while inserting record: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Rows inserted successfully
                        Console.WriteLine("Record inserted successfully on Teacher");
                    }
                    else
                    {
                        // No rows were inserted
                        Console.WriteLine("No rows were inserted");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.WriteLine("An error occurred while inserting record: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

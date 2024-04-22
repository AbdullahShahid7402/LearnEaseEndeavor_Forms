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
    public partial class SubmitAssignment : Form
    {
        private DataTable courses;
        private int selectedCourse;

        private DataTable assignment;
        private int selectedAssignment;

        public SubmitAssignment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SelectaCourse.Items.Clear();
            UserInstance userInstance = UserInstance.getInstance();
            User user = userInstance.getUser();
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            connection.Open();
            try
            {
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT [Study].*,[Course].[name] FROM [Course] join [Study] on [Study].course_id= [Course].[id] WHERE [email_student] = '" + user.Email + "'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                courses = new DataTable();
                adapter.Fill(courses);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in courses.Rows)
                {
                    string courseName = row["name"].ToString(); // Assuming "name" is the column name for the course name
                    SelectaCourse.Items.Add(courseName);
                    Console.WriteLine(courseName + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (SelectaCourse.Items.Count > 0)
                {
                    SelectaCourse.SelectedIndex = 0;
                    selectedCourse = SelectaCourse.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            UserInstance userInstance = UserInstance.getInstance();
            User user = userInstance.getUser();
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            try
            {
                connection.Open();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT [Assignment].* from [Study] join [Assignment] on [Assignment].study_id = [Study].[id] where [Study].[email_student] = '" + user.Email + "' and [Assignment].submitted = 0";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                assignment = new DataTable();
                adapter.Fill(assignment);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in assignment.Rows)
                {
                    string courseName = row["name"].ToString(); // Assuming "name" is the column name for the course name
                    comboBox1.Items.Add(courseName);
                    Console.WriteLine(courseName + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    selectedAssignment = comboBox1.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SelectaCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourse = SelectaCourse.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAssignment = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            DataRow row = assignment.Rows[selectedAssignment];
            string description = textBox1.Text;
            string id = row["id"].ToString();
            string query = "UPDATE [Assignment] SET [submitted]= 1, [submission] = '" + description + "' WHERE [id] = " + id;
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
                    Console.WriteLine("Record successfully updated");
                }
                else
                {
                    // No rows were inserted
                    Console.WriteLine("No rows were altered");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine("An error occurred while updating assignment record: " + ex.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new StudentHome();
            form.Show();
            this.Hide();
        }
    }
}

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
    public partial class AnnouncementAdd : Form
    {
        private DataTable courses;
        private int selectedCourse;

        private DataTable section;
        private int selectedSection;
        public AnnouncementAdd()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new TeacherHome();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SelectaCourse.Items.Clear();
            UserInstance userInstance = UserInstance.getInstance();
            User user = userInstance.getUser();
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            try
            {
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT DISTINCT [Course].[name], [Course].[id] FROM [Course] join [Study] on [Study].course_id= [Course].[id] WHERE [email_teacher] = '" + user.Email + "'";

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
            if(connection.State != ConnectionState.Open)
                connection.Open();
            try
            {
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT Distinct [Study].section FROM [Course] join [Study] on [Study].course_id= [Course].[id] WHERE [Course].[name] = '" + courses.Rows[SelectaCourse.SelectedIndex]["name"].ToString() + "'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                section = new DataTable();
                adapter.Fill(section);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in section.Rows)
                {
                    string courseName = row["section"].ToString(); // Assuming "name" is the column name for the course name
                    comboBox1.Items.Add(courseName);
                    Console.WriteLine(courseName + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    selectedSection = comboBox1.SelectedIndex;
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
            selectedSection = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                // If any of the text boxes are empty, return without executing the query
                return;
            }

            // Get the subject ID corresponding to the selected course and section

            // Initialize connection outside the loop
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            try
            {
                // Open the connection outside the loop
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                DataRow r = courses.Rows[selectedCourse];
                string id = r["id"].ToString();
                UserInstance instance = UserInstance.getInstance();
                User user = instance.getUser();
                Teacher t = (Teacher)user;
                string teacher_id = t.RollNo.ToString();
                
                // Get the current date in the required format

                // Construct the INSERT query with parameters to avoid SQL injection
                string querynew = "insert into [Announcement]([description],[date],[course_id],[teacher_id]) values ('"+textBox2.Text+"', GETDATE(), "+ id +", " + teacher_id + ")";

                // Create a SqlCommand with the query and connection
                SqlCommand command = new SqlCommand(querynew, connection);

                try
                {
                    // Open the connection
                    //connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Rows inserted successfully
                        Console.WriteLine("Record inserted successfully");
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
                    //connection.Close();
                }

            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine("An error occurred while inserting Announcement records: " + ex.Message);
            }
        }
    }
}

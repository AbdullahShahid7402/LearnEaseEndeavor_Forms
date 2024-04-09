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
    public partial class MarkAssignment : Form
    {

        private DataTable courses;
        private int selectedCourse;

        private DataTable section;
        private int selectedSection;

        public MarkAssignment()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                string query = "SELECT DISTINCT [Course].[name] FROM [Course] join [Study] on [Study].course_id= [Course].[id] WHERE [email_teacher] = '" + user.Email + "'";

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

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            string query = "SELECT [Assignment].total,[Assignment].Weightage,[Assignment].submission,[Assignment].id  FROM [Assignment] join [Study] on [Study].id = [Assignment].[study_id] join [Course] on [Course].id = [Study].[course_id] where [section] = '"+ section.Rows[selectedSection]["section"].ToString() + "' and [Course].[name] = '" + courses.Rows[selectedCourse]["name"].ToString() + "' and [submitted] = 1";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Save_Click(object sender, EventArgs e)
        {

            // Initialize connection outside the loop
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            try
            {
                // Open the connection outside the loop
                connection.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["obtained"] is DataGridViewTextBoxCell textBoxCell && textBoxCell.Value != null)
                    {
                        string obtained = textBoxCell.Value.ToString();
                        string id = row.Cells["id"].Value.ToString();
                        // Get the current date in the required format

                        // Construct the INSERT query with parameters to avoid SQL injection
                        string querynew = "UPDATE [Assignment] SET [obtained]= " + obtained + " WHERE [id] = " + id;

                        // Create a SqlCommand with the query and connection
                        SqlCommand command = new SqlCommand(querynew, connection);

                        // Execute the INSERT query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Rows inserted successfully
                            Console.WriteLine("Assignment record for id = {0} updated successfully.", id);
                        }
                        else
                        {
                            // No rows were inserted
                            Console.WriteLine("No Assignment record for id = {0} updated successfully.", id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine("An error occurred while inserting attendance records: " + ex.Message);
            }
        }
    }
}

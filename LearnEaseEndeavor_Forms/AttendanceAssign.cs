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
    public partial class AttendanceAssign : Form
    {
        private string course;
        private string section;
        private int subject_id;
        DBConnection connectionInstance;
        PageInstance instance;
        public AttendanceAssign()
        {
            InitializeComponent();
        }

        private void SelectCourse(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                UserInstance userInstance = UserInstance.getInstance();
                User user = userInstance.getUser();
                DBConnection connectionInstance = DBConnection.getInstance();
                SqlConnection connection = connectionInstance.getConnection();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT DISTINCT [name] FROM [Subject] WHERE [email_teacher] = '" + user.Email + "'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in table.Rows)
                {
                    string courseName = row["name"].ToString(); // Assuming "name" is the column name for the course name
                    SelectaCourse.Items.Add(courseName);
                    Console.WriteLine(courseName + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (SelectaCourse.Items.Count > 0)
                {
                    SelectaCourse.SelectedIndex = 0;
                    course = SelectaCourse.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            string query = "Select [Student].[roll_number],[Student].[name] from [Student] where [Student].[email] in (Select [Subject].[email_student] from [Subject] where [Subject].[name] = '" + course + "' and [Subject].[section] = '" + section + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            subject_id = -1;
            query = "SELECT * FROM [Subject] WHERE [Subject].[name] = '" + course + "' AND [Subject].[section] = '" + section + "'";
            sda = new SqlDataAdapter(query, connection);
            dt = new DataTable();
            sda.Fill(dt);
            DataRow row = dt.Rows[0];
            subject_id = int.Parse(row["id"].ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                UserInstance userInstance = UserInstance.getInstance();
                User user = userInstance.getUser();
                DBConnection connectionInstance = DBConnection.getInstance();
                SqlConnection connection = connectionInstance.getConnection();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT DISTINCT [section] FROM [Subject] WHERE [Subject].[email_teacher] = '" + user.Email + "' and [Subject].[name] = '" + SelectaCourse.SelectedItem.ToString() + "'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in table.Rows)
                {
                    string section = row["section"].ToString(); // Assuming "name" is the column name for the course name
                    comboBox1.Items.Add(section);
                    Console.WriteLine(section + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    section = comboBox1.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (row.Cells["Attendance"] is DataGridViewTextBoxCell textBoxCell && textBoxCell.Value != null)
                    {
                        string attendance = textBoxCell.Value.ToString();
                        string studentName = row.Cells["name"].Value.ToString();
                        int rollno = int.Parse(row.Cells["roll_number"].Value.ToString());
                        // Get the current date in the required format

                        // Construct the INSERT query with parameters to avoid SQL injection
                        string querynew = "INSERT INTO Attendance (status, date, student_id, subject_id) VALUES (@status, GETDATE(), @student_id, @subject_id)";

                        // Create a SqlCommand with the query and connection
                        SqlCommand command = new SqlCommand(querynew, connection);

                        // Add parameters to the SqlCommand
                        command.Parameters.AddWithValue("@status", attendance);
                        command.Parameters.AddWithValue("@student_id", rollno);
                        command.Parameters.AddWithValue("@subject_id", subject_id);

                        // Execute the INSERT query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Rows inserted successfully
                            Console.WriteLine("Attendance record for student {0} inserted successfully.", studentName);
                        }
                        else
                        {
                            // No rows were inserted
                            Console.WriteLine("No rows were inserted for student {0}.", studentName);
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

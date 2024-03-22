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
        public AttendanceAssign()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            SelectaSection.Items.Clear();
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

                string query = "SELECT * FROM [Subject] WHERE [Subject].[email_teacher] = '" + user.Email + "'";

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
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SelectCourse(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SelectaSection.Items.Clear();
            try
            {
                UserInstance userInstance = UserInstance.getInstance();
                User user = userInstance.getUser();
                DBConnection connectionInstance = DBConnection.getInstance();
                SqlConnection connection = connectionInstance.getConnection();
                if(user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT * FROM [Subject] WHERE [Subject].[email_teacher] = '" + user.Email + "'";

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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string selectedCourse = SelectaCourse.SelectedItem.ToString();
                string selectedSection = SelectaSection.SelectedItem.ToString();

                // Fetch students for the selected course and section
                List<Student> students = GetStudentsForCourseAndSection(selectedCourse, selectedSection);

                // Clear existing rows in DataGridView
                dataGridView1.Rows.Clear();

                // Populate DataGridView with student data
                foreach (Student student in students)
                {
                    dataGridView1.Rows.Add(student.RollNo, student.Name, student.PhoneNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Student> GetStudentsForCourseAndSection(string course, string section)
        {
            List<Student> students = new List<Student>();

            try
            {
                // Fetch students from database based on course and section
                string query = "Select* from[Student] where[Student].[email] in (Select[Subject].[email_student] from[Subject] where[Subject].[name] = '@Course' and[Subject].[section] = '@Section')";
                using (SqlConnection connection = DBConnection.getInstance().getConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Course", course);
                    command.Parameters.AddWithValue("@Section", section);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int rollNo = Convert.ToInt32(reader["roll_number"]);
                        int batch = Convert.ToInt32(reader["batch"]);
                        string name = reader["name"].ToString();
                        string phoneNo = reader["phone_number"].ToString();
                        string email = reader["email"].ToString();

                        students.Add(new Student(rollNo, batch, name, phoneNo, email, ""));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return students;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SelectaSection_SelectedIndexChanged(object sender, EventArgs e)
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

                string query = "SELECT * FROM [Subject] WHERE [Subject].[email_teacher] = '" + user.Email + "' and [Subject].[name] = '"+ SelectaCourse.SelectedItem.ToString() +"'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                SelectaCourse.Items.Clear();

                // Iterate through the rows of the DataTable and add each course to the ComboBox
                foreach (DataRow row in table.Rows)
                {
                    string section = row["section"].ToString(); // Assuming "name" is the column name for the course name
                    SelectaSection.Items.Add(section);
                    Console.WriteLine(section + "Added");
                }

                // Optionally, select the first item in the ComboBox
                if (SelectaCourse.Items.Count > 0)
                {
                    SelectaCourse.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click()
        {

        }
        private void label4_Click()
        {

        }
    }

}
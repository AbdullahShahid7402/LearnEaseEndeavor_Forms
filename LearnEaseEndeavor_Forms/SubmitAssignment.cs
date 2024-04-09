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
            try
            {
                UserInstance userInstance = UserInstance.getInstance();
                User user = userInstance.getUser();
                DBConnection connectionInstance = DBConnection.getInstance();
                SqlConnection connection = connectionInstance.getConnection();
                connection.Open();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT * FROM [Course] WHERE [Course].id in (SELECT DISTINCT [Course_id] FROM [Study] WHERE [email_student] = '" + user.Email + "')";

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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SelectaCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourse = SelectaCourse.SelectedIndex;
        }
    }
}

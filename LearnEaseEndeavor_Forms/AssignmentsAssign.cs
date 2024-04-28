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
    public partial class AssignmentsAssign : Form
    {
        private string course;
        private string section;
        private int subject_id;
        public AssignmentsAssign()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT [name],[id] FROM [Course] WHERE [Course].id in (SELECT DISTINCT [Course_id] FROM [Study] WHERE [email_teacher] = '" + user.Email + "')";

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

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                UserInstance userInstance = UserInstance.getInstance();
                User user = userInstance.getUser();
                DBConnection connectionInstance = DBConnection.getInstance();
                SqlConnection connection = connectionInstance.getConnection();
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                if (user == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }
                Console.WriteLine(user.Email);

                string query = "SELECT DISTINCT [section] FROM [Study] where [course_id] in ((SELECT [id] FROM [Course] WHERE [Course].id in (SELECT DISTINCT [Course_id] FROM [Study] WHERE [email_teacher] = '" + user.Email + "')))";

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

        private void SelectaCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = SelectaCourse.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            section = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                // If any of the text boxes are empty, return without executing the query
                return;
            }

            // Get the subject ID corresponding to the selected course and section
            DBConnection connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            string query = "SELECT * from [Study] where [Study].[section] = '" + section + "' and [Study].[course_id] in (select [id] from [Course] where [name]='" + course + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Check if any rows were returned
            foreach (DataRow row in dt.Rows)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                int subject_id = int.Parse(row["id"].ToString());

                // Construct the INSERT query
                string querynew = "INSERT INTO Assignment (name, description, total, obtained, Weightage, study_id, submitted, submission) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox3.Text + ", 0, " + textBox4.Text + ", " + subject_id + ", 0, '')";

                // Create a SqlCommand with the query and connection
                SqlCommand command = new SqlCommand(querynew, connection);

                try
                {
                    // Open the connection
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

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
                    connection.Close();
                }
            }
        }

        private void AssignmentsAssign_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new TeacherHome();
            form.Show();
            this.Hide();
        }
    }
}

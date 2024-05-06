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
    public partial class Login : Form
    {
        DBConnection connectionInstance;
        PageInstance instance;
        User user;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Validate_Click(object sender, EventArgs e)
        {
            connectionInstance = DBConnection.getInstance();
            SqlConnection connection = connectionInstance.getConnection();
            UserInstance userInstance = UserInstance.getInstance();
            string email, password;
            email = EmailTextBox.Text;
            password = PasswordTextBox.Text;
            ErrorLable.Text = "";
            if(EmailTextBox.Text.Length>30 || EmailTextBox.Text.Length < 1)
            {
            ErrorLable.Text += " ::Email Length out of bounds:: ";
            }
            if (PasswordTextBox.Text.Length > 15 || PasswordTextBox.Text.Length < 1)
            {
                ErrorLable.Text += " ::Password Length out of bounds:: ";
            }
            user = userInstance.setUser(email, password);
            if (user == null)
                ErrorLable.Text = ":: User Not Found ::";
            else
            {
                if (user is Student)
                {
                    Student s = (Student)user;
                    ErrorLable.Text = ":: Welcome " + s.Name + " ::";
                    Form form = new StudentHome();
                    form.Show();
                    Console.WriteLine("Scene shifted");
                    this.Hide();
                }
                else if (user is Teacher)
                {
                    Teacher t = (Teacher)user;
                    ErrorLable.Text = ":: Welcome " + t.Name + " ::";
                    //Form form = new AttendanceAssign();
                    //Form form = new AssignmentsAssign();
                    Form form = new TeacherHome();
                    form.Show();
                    Console.WriteLine("Scene shifted");
                    this.Hide();
                }
                else
                {
                    ErrorLable.Text = ":: Welcome Admin ::";
                    Form form = new AdminHome();
                    form.Show();
                    Console.WriteLine("Scene shifted");
                    this.Hide();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

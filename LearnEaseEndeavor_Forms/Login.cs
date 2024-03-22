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

        SqlConnection connection = new SqlConnection(@"Data Source=ABDULLAH-LAPTOP\SQLEXPRESS;Initial Catalog=LEE;Integrated Security=True");
        PageInstance instance;

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
            string email, password;
            email = EmailTextBox.Text;
            password = PasswordTextBox.Text;
            try 
            {
                string query = "SELECT* FROM [User] where [email] = '" + email + "' AND [password] = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if(dtable.Rows.Count>0)
                {
                    instance = PageInstance.getInstance();
                    ErrorLable.Text = "";
                    AttendanceAssign form = instance.getAttendanceAssign();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    ErrorLable.Text = "No Entry Found";
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

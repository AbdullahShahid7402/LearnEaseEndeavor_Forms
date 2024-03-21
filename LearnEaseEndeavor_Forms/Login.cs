using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEaseEndeavor_Forms
{
    public partial class Login : Form
    {
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
            if(EmailTextBox.Text == "Fatima")
            {
                if(PasswordTextBox.Text == "grant me access")
                {
                    ErrorLable.Text = ":: Login Successful ::";
                }
                else
                {
                    ErrorLable.Text = ":: Wrong Password ::";
                }
            }
            else
            {
                ErrorLable.Text = ":: Email Not Found ::";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

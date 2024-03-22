using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEaseEndeavor_Forms
{
    class User
    {
        private string email = null;
        private string password = null;

        public User(string email_, string password_)
        {
            email = email_;
            password = password_;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEaseEndeavor_Forms
{
    class Teacher:User
    {
        private int rollNo = -1;
        private bool visiting = false;
        private string name = null;
        private string phone_no = null;

        public Teacher(int rollNo_, bool visiting_, string name_, string phone_no_, string email_, string password_)
            : base(email_, password_)
        {
            rollNo = rollNo_;
            visiting = visiting_;
            name = name_;
            phone_no = phone_no_;
        }

        public int RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }

        public bool Visiting
        {
            get { return visiting; }
            set { visiting = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
    }
}

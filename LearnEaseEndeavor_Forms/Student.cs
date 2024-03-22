using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEaseEndeavor_Forms
{
    class Student:User
    {
        private int rollNo = -1;
        private int batch = -1;
        private string name = null;
        private string phone_no = null;

        public Student(int rollNo_, int Batch_, string name_, string phone_no_, string email_, string password_)
            :base(email_,password_)
        {
            rollNo = rollNo_;
            batch = Batch_;
            name = name_;
            phone_no = phone_no_;
        }

        public int RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }

        public int Batch
        {
            get { return batch; }
            set { batch = value; }
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

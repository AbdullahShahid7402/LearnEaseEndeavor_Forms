using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEaseEndeavor_Forms
{
    // this class is responsible of making sure the pages created are saved in mamory for future use and
    // no pointless memory is wasted in creating duplicate pages
    class PageInstance
    {
        private static PageInstance obj = null;
        public Login loginInstance = null;

        private PageInstance() { }

        public static PageInstance getInstance()
        {
            if (obj == null)
                obj = new PageInstance();
            return obj;
        }
        public void destroyInstance()
        {
            obj = null;
        }

        public Login getLogin()
        {
            if (loginInstance == null)
                loginInstance = new Login();
            return loginInstance;
        }
        public void resetLogin()
        {
            loginInstance = null;
        }
    }
}

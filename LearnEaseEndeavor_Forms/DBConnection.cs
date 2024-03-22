using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LearnEaseEndeavor_Forms
{
    class DBConnection
    {
        private static DBConnection obj = null;
        private SqlConnection connection;

        private DBConnection() 
        {
            connection = new SqlConnection(@"Data Source=ABDULLAH-LAPTOP\SQLEXPRESS;Initial Catalog=LEE;Integrated Security=True");
        }
        
        public static DBConnection getInstance()
        {
            if (obj == null)
                obj = new DBConnection();
            return obj;
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}

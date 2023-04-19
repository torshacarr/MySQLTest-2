using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLTest
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "20.45.181.29";
            int port = 3306;
            string database = "socrobotic";
            string username = "socrobotic";
            string password = "pmDglWIy+dl0yfO+EHv+yA==";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}

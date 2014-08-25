using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DBOperation.Class
{
    public static class DBControl
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=192.168.0.66;Database=BaseDB;uid=sa;pwd=root;Connect Timeout=30");
        }
    }
}

using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace StudentUI
{
    public static class CustomDependencyInjection
    {
        public static Func<DbConnection> DbConnection => 
            new Func<DbConnection>(() => new SqlConnection(File.ReadAllText("connection.txt")));
    }
}

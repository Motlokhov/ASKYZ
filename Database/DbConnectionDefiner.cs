using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class DbConnectionDefiner
    {
        internal static DbConnection Define()
        {

#if DEBUG
            string localDataBasePath = @"LocalKnowlageVerification.db";

            StringBuilder stringBuilder = new StringBuilder()
                .Append(@"Data Source = ").Append(localDataBasePath).Append(";")
                .Append("Version = 3;");

            if( !File.Exists(localDataBasePath))
                SQLiteConnection.CreateFile(localDataBasePath);

            return new SQLiteConnection(stringBuilder.ToString());
#else
    return new SqlConnection(File.ReadAllText("connection.txt"));
#endif
        }
    }
}

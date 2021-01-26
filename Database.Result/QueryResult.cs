using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Database.Result
{
    public static class QueryResult
    {
        public static (byte id, string name)[] LoadAllDirections()
        {
            using( Query query = new Query() )
            {
                DbDataReader dbDataReader = query.ReadData("SELECT Id,Name FROM Direction");

                List<(byte, string)> result = new List<(byte, string)>();

                while( dbDataReader.Read() )
                    result.Add((Convert.ToByte(dbDataReader["ID"]), dbDataReader["Name"].ToString()));

                return result.ToArray();
            }
        }

        public static ulong? GetUserId(string id, string password)
        {
            using( Query query = new Query() )
            {
                object result = query.ExecuteScalar("SELECT ID FROM [User] WHERE ID = " + id + " AND Password = '" + password + "'");
                return result == null ? default(ulong?) : Convert.ToUInt64(result);
            }
        }
    }
}

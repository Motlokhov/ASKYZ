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
    }
}

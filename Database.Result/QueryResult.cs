using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Database.Result
{
    public static class QueryResult
    {
        public static (byte id, string name)[] LoadAllDirections()
        {
            using(Query query = new Query())
            {
                DbDataReader dbDataReader = query.ReadData("SELECT Id,Name FROM Direction");

                List<(byte, string)> result = new List<(byte, string)>();

                while(dbDataReader.Read())
                    result.Add((Convert.ToByte(dbDataReader["ID"]), dbDataReader["Name"].ToString()));

                return result.ToArray();
            }
        }

        public static ulong? GetUserId(string id, string password)
        {
            using(Query query = new Query())
            {
                object result = query.ExecuteScalar("SELECT ID FROM [User] WHERE ID = " + id + " AND Password = '" + password + "'");
                return result == null ? default(ulong?) : Convert.ToUInt64(result);
            }
        }

        public static string LoadDirectionName(byte programGroupId)
        {
            using(Query query = new Query())
                return query.ExecuteScalar("SELECT Direction.[Name] FROM Direction INNER JOIN ProgramGroup ON Direction.ID = ProgramGroup.DirectionID WHERE ProgramGroup.ID = " + programGroupId).ToString();
        }

        public static (byte id, string name, byte number)[] LoadProgramsByDirecionAndType(byte directionID, int testType)
        {
            List<(byte, string, byte)> result = new List<(byte, string, byte)>();
            using(Query query = new Query())
            {
                using(DbDataReader reader =
                    query.ReadData("SELECT ProgramGroup.ID,Name,Number FROM ProgramGroup INNER JOIN Test ON Test.ProgramGroupID = ProgramGroup.ID WHERE DirectionID = " + directionID + " AND Test.[Type] = " + (int)testType))
                {
                    while(reader.Read())
                        result.Add((Convert.ToByte(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToByte(reader["Number"])));

                    return result.ToArray();
                }
            }
        }

        public static (string name, byte number)? LoadProgramByProgramGroupId(byte programGroupId)
        {
            using(Query query = new Query())
                using(DbDataReader reader = query.ReadData("SELECT Name,Number FROM ProgramGroup WHERE ID = " + programGroupId))
                    if(reader.Read())
                        return (Convert.ToString(reader["Name"]), Convert.ToByte(reader["Number"]));

            return null;
        }
    }
}

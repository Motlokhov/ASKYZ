using System;

namespace Core
{
    using Query;
    using Common;
    using Testing;
    using System.Data.SqlClient;

    public static class Core
    {
        static public readonly Random Random;
        static public byte DirectionID { get; private set; }
        static public string DirectionName { get; private set; }
        static public byte ProgramGroupID { get; private set; }
        static public byte ProgramNumber { get; private set; }
        static public string ProgramName { get; private set; }
        static public User User { get; private set; }
        static public Test Test { get; private set; }

        static Core()
        {
            Random = new Random();
        }

        static public bool CheckPassword(string id , string password)
        {
            Test = null;
            User = null;
            var query = new Query();
            var result = query.ExecuteScalar("SELECT ID FROM [User] WHERE ID = " + id + " AND Password = '" + password + "'");
            if( result != null )
            {
                ulong userID = Convert.ToUInt64(result);
                User = new User(userID);
                ProgramGroupID = User.GetProgramGroupID();
                LoadDirectionName();
                LoadProgram();
                Test = new ControlTest(ProgramGroupID);
                return true;
            }
            return false;
        }

        public static SqlDataReader LoadDirections()
        {
            var query = new Query();
            return query.ReadData("SELECT Id,Name FROM Direction");
        }
        
        public static void LoadDirectionName()
        {
            var query = new Query();
            var result = query.ExecuteScalar("SELECT Direction.[Name] FROM Direction INNER JOIN ProgramGroup ON Direction.ID = ProgramGroup.DirectionID WHERE ProgramGroup.ID = " + ProgramGroupID);
            DirectionName = result.ToString();
        }

        public static void SetDirection(byte id , string name)
        {
            DirectionID = id;
            DirectionName = name;
        }
        
        public static SqlDataReader LoadPrograms(byte directionID,TestType testType)
        {
            var query = new Query();
            return query.ReadData("SELECT ProgramGroup.ID,Name,Number FROM ProgramGroup INNER JOIN Test ON Test.ProgramGroupID = ProgramGroup.ID WHERE DirectionID = " + directionID + " AND Test.[Type] = "+(int)testType);
        }

        public static void SetProgramGroupID(byte id)
        {
            ProgramGroupID = id;
        }

        public static void LoadProgram()
        {
            var query = new Query();
            var reader =  query.ReadData("SELECT Name,Number FROM ProgramGroup WHERE ID = " + ProgramGroupID);
            if( reader.Read() )
            {
                ProgramNumber = Convert.ToByte(reader["Number"]);
                ProgramName = Convert.ToString(reader["Name"]);
            }
        }

        public static void CreateTrainingTest(ulong programGroupID)
        {
            Test = null;
            Test = new TrainingTest(programGroupID);
        }
    }
}

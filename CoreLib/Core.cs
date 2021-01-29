using System;
using Database;
using CoreLib.Common;
using CoreLib.Testing;
using System.Data.SqlClient;
using System.Data.Common;
using Database.Result;

namespace CoreLib.Main
{
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
            ulong? userId = QueryResult.GetUserId(id, password);
            if( userId.HasValue )
            {
                User = new User(userId.Value);
                ProgramGroupID = User.GetProgramGroupID();
                LoadDirectionName();
                LoadProgram();
                Test = new ControlTest(ProgramGroupID);
                return true;
            }
            return false;
        }

        public static void LoadDirectionName()
        {
            DirectionName = QueryResult.LoadDirectionName(ProgramGroupID);
        }

        public static void SetDirection(byte id , string name)
        {
            DirectionID = id;
            DirectionName = name;
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

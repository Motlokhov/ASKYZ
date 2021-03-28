using System;
using CoreLib.Model;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Main
{
    public static class Core
    {
        public static readonly Random Random;
        public static byte DirectionID { get; private set; }
        public static string DirectionName { get; private set; }
        public static byte ProgramGroupID { get; private set; }
        public static byte ProgramNumber { get; private set; }
        public static string ProgramName { get; private set; }
        public static User User { get; private set; }
        public static ExerciseSet Exercises { get; private set; }

        static Core()
        {
            Random = new Random();
        }

        public static bool CheckPassword(IQueryResult queryResult, string id , string password)
        {
            Exercises = null;
            User = null;
            ulong? userId = queryResult.GetUserId(id, password);
            if( userId.HasValue )
            {
                User = new User(queryResult, userId.Value);
                ProgramGroupID = User.GetProgramGroupID();
                LoadDirectionName(queryResult);
                LoadProgram(queryResult);
                Exercises = new GrandExerciseSet(queryResult,ProgramGroupID);
                return true;
            }
            return false;
        }

        public static void LoadDirectionName(IQueryResult queryResult)
        {
            DirectionName = queryResult.LoadDirectionName(ProgramGroupID);
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

        public static void LoadProgram(IQueryResult queryResult)
        {
            (string name, byte number)? program = queryResult.LoadProgramByProgramGroupId(ProgramGroupID);

            if(program.HasValue)
            {
                ProgramNumber = program.Value.number;
                ProgramName = program.Value.name;
            }
        }

        public static void CreateTrainingTest(IQueryResult queryResult, ulong programGroupID)
        {
            Exercises = null;
            Exercises = new TrainingExerciseSet(queryResult, programGroupID);
        }
    }
}

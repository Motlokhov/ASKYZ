using System;
using CoreLib.Common;
using Database;


namespace CoreLib.Testing
{
    public class Result
    {
        public byte TrueAnswers { get;  set; }
        public byte FalseAnswers { get;  set; }
        public byte Points { get;  set; }

        public Result()
        {

        }
        public Result(ulong testingDateID,ExerciseType exerciseType)
        {
            Load(testingDateID , exerciseType);
        }
        public ExerciseType ExerciseType { get; set; }
        public void CalculateFalseAnswers(int parentCountQuestions)
        {
            FalseAnswers = Convert.ToByte(parentCountQuestions - TrueAnswers);
        }

        private void Load(ulong testingDateID,ExerciseType exerciseType)
        {
            ExerciseType = exerciseType;
            var query = new Query();
            var reader = query.ReadData("SELECT TrueAnswers,FalseAnswers,Points FROM TestingResult WHERE TestingDateID = " + testingDateID + " AND ExerciseType = " + (int) ExerciseType);
            if( reader.Read() )
            {
                TrueAnswers = Convert.ToByte(reader["TrueAnswers"]);
                FalseAnswers = Convert.ToByte(reader["FalseAnswers"]);
                Points = Convert.ToByte(reader["Points"]);
                return;
            }
            throw new Exception("Нет данных по результатам тестирования.");
        }
    }
}
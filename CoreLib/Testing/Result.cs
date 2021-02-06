using System;
using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class Result
    {
        private readonly QueryResult _queryResult;

        public byte TrueAnswers { get;  set; }
        public byte FalseAnswers { get;  set; }
        public byte Points { get;  set; }

        public Result(QueryResult queryResult)
        {
            _queryResult = queryResult;
        }
        public Result(QueryResult queryResult, ulong testingDateID,ExerciseType exerciseType)
        {
            _queryResult = queryResult;
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

            (byte trueAnswersCount, byte falseAnswerCount, byte points)? testResult = _queryResult.LoadTestResult(testingDateID, (int)exerciseType);
            
            if(testResult.HasValue)
            {
                TrueAnswers = testResult.Value.trueAnswersCount;
                FalseAnswers = testResult.Value.falseAnswerCount;
                Points = testResult.Value.points;
                return;
            }
            throw new Exception("Нет данных по результатам тестирования.");
        }
    }
}
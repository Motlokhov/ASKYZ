using System;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public class Result
    {
        private readonly IQueryResult _queryResult;

        public byte TrueAnswers { get; set; }
        public byte FalseAnswers { get; set; }
        public byte Points { get; set; }

        public Result(IQueryResult queryResult)
        {
            _queryResult = queryResult;
        }
        public Result(IQueryResult queryResult, ulong testingDateID, ExerciseType exerciseType)
        {
            _queryResult = queryResult;
            Load(testingDateID, exerciseType);
        }
        public ExerciseType ExerciseType { get; set; }
        public void CalculateFalseAnswers(int parentCountQuestions)
        {
            FalseAnswers = Convert.ToByte(parentCountQuestions - TrueAnswers);
        }

        private void Load(ulong testingDateID, ExerciseType exerciseType)
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
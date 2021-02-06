using System;
using System.Data.Common;
using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    class TrainingTest : Test
    {
        public TrainingTest(QueryResult queryResult, ulong programGroupID) : base(queryResult,TestType.training)
        {
            _name = "Обучающее тестирование";
            _id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)Type);

            Exercises.Add(new CommonExercise(queryResult, _id));
            Exercises.Add(new ThemenExercise(queryResult, _id));
            Exercises.Add(new PracticalExercise(queryResult, _id));
        }

        public override bool VerifyQuestion(ulong[] answersIds)
        {
            byte points = QueryResult.LoadSumPoints(answersIds);
            return Exercise.MaxPoints == points;
        }
    }
}

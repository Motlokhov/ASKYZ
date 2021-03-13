using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    class TrainingTest : Test
    {
        public TrainingTest(IQueryResult queryResult, ulong programGroupID) : base(queryResult,TestType.training)
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

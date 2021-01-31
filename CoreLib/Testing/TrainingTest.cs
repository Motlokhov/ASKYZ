using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    class TrainingTest : Test
    {
        public TrainingTest(ulong programGroupID) : base()
        {
            _type = TestType.training;
            _name = "Обучающее тестирование";
            _id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)_type);

            Exercises.Add(new CommonExercise(_id));
            Exercises.Add(new ThemenExercise(_id));
            Exercises.Add(new PracticalExercise(_id));
        }

        public override bool VerifyQuestion(ulong[] answersIds)
        {
            byte points = QueryResult.LoadSumPoints(answersIds);
            return Exercise.MaxPoints == points;
        }
    }
}

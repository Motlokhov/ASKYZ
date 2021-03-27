using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    class TrainingExerciseSet : ExerciseSet
    {
        public TrainingExerciseSet(IQueryResult queryResult, ulong programGroupID) : base(queryResult,ExerciseSetType.Training)
        {
            Name = "Обучающее тестирование";
            Id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)Type);

            Exercises.Add(new CommonExercise(queryResult, Id));
            Exercises.Add(new ThemenExercise(queryResult, Id));
            Exercises.Add(new PracticalExercise(queryResult, Id));
        }

        public override bool VerifyQuestion(ulong[] answersIds)
        {
            byte points = QueryResult.LoadSumPoints(answersIds);
            return Exercise.MaxPoints == points;
        }
    }
}

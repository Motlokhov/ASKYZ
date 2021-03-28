using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public class TrainingExerciseSet : ExerciseSet
    {
        public TrainingExerciseSet(IQueryResult queryResult, ulong programGroupID) : base(queryResult, ExerciseSetType.Training, programGroupID)
        {
            Name = "Обучающее тестирование";
        }

        public override bool IsNextQuestionAvailable(ulong[] answersIds)
        {
            byte points = QueryResult.LoadSumPoints(answersIds);
            return Exercise.MaxPoints == points;
        }
    }
}

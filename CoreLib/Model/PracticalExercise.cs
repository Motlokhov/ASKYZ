using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public class PracticalExercise : Exercise
    {
        public PracticalExercise(IQueryResult queryResult, ulong testID): base(queryResult)
        {
            Type = ExerciseType.practical;
            RequiredNumberQuestions =2;
            MaxPoints = 20;
            Name = "Практические задачи";
            Load(testID);
        }
    }
}
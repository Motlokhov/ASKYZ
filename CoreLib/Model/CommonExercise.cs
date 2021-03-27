using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public class CommonExercise : Exercise
    {
        public CommonExercise(IQueryResult queryResult, ulong testID): base(queryResult)
        {
            Type = ExerciseType.common;
            RequiredNumberQuestions = 50;
            MaxPoints = 1;
            Name = "Тестовые вопросы";
            Load(testID);
        }
    }
}
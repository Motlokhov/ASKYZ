using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    public class CommonExercise : Exercise
    {
        public CommonExercise(IQueryResult queryResult, ulong testID): base(queryResult)
        {
            SetType(ExerciseType.common);
            SetRequiredNumberQuestions(50);
            SetMaxPoints(1);
            _name = "Тестовые вопросы";
            Load(testID);
        }
    }
}
using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class CommonExercise : Exercise
    {
        public CommonExercise(QueryResult queryResult, ulong testID): base(queryResult)
        {
            SetType(ExerciseType.common);
            SetRequiredNumberQuestions(50);
            SetMaxPoints(1);
            _name = "Тестовые вопросы";
            Load(testID);
        }
    }
}
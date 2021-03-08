using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class PracticalExercise : Exercise
    {
        public PracticalExercise(QueryResult queryResult, ulong testID): base(queryResult)
        {
            SetType(ExerciseType.practical);
            SetRequiredNumberQuestions(2);
            SetMaxPoints(20);
            _name = "Практические задачи";
            Load(testID);
        }
    }
}
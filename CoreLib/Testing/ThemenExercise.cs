using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class ThemenExercise : Exercise
    {
        public ThemenExercise(QueryResult queryResult, ulong testID) : base(queryResult)
        {
            SetType(ExerciseType.themen);
            SetRequiredNumberQuestions(3);
            SetMaxPoints(10);
            _name = "Тематические вопросы";
            Load(testID);
        }
    }
}
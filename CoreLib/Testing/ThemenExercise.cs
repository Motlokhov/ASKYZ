using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    public class ThemenExercise : Exercise
    {
        public ThemenExercise(IQueryResult queryResult, ulong testID) : base(queryResult)
        {
            SetType(ExerciseType.themen);
            SetRequiredNumberQuestions(3);
            SetMaxPoints(10);
            _name = "Тематические вопросы";
            Load(testID);
        }
    }
}
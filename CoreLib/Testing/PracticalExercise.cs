using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    public class PracticalExercise : Exercise
    {
        public PracticalExercise(IQueryResult queryResult, ulong testID): base(queryResult)
        {
            SetType(ExerciseType.practical);
            SetRequiredNumberQuestions(2);
            SetMaxPoints(20);
            _name = "Практические задачи";
            Load(testID);
        }
    }
}
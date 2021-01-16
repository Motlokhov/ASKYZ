using CoreLib.Common;

namespace CoreLib.Testing
{
    public class PracticalExercise : Exercise
    {
        public PracticalExercise(ulong testID): base()
        {
            SetType(ExerciseType.practical);
            SetRequiredNumberQuestions(2);
            SetMaxPoints(20);
            _name = "Практические задачи";
            Load(testID);
        }
    }
}
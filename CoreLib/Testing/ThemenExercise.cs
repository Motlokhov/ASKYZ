using CoreLib.Common;

namespace CoreLib.Testing
{
    public class ThemenExercise : Exercise
    {
        public ThemenExercise(ulong testID) : base()
        {
            SetType(ExerciseType.themen);
            SetRequiredNumberQuestions(3);
            SetMaxPoints(10);
            _name = "Тематические вопросы";
            Load(testID);
        }
      
    }
}
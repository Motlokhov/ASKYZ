namespace Core.Testing
{
    using System;
    using Common;
    using Query;
    public class CommonExercise : Exercise
    {
        
        public CommonExercise(ulong testID): base()
        {
            SetType(ExerciseType.common);
            SetRequiredNumberQuestions(50);
            SetMaxPoints(1);
            _name = "Тестовые вопросы";
            Load(testID);
        }
        


    }
}
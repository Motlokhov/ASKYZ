using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Testing
{
    using Common;
    using Query;
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
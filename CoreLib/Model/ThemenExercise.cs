using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public class ThemenExercise : Exercise
    {
        public ThemenExercise(IQueryResult queryResult, ulong testID) : base(queryResult)
        {
            Type = ExerciseType.themen;
            RequiredNumberQuestions =3;
            MaxPoints = 10;
            Name = "Тематические вопросы";
            Load(testID);
        }
    }
}
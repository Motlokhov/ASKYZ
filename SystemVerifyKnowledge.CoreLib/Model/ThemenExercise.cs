using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
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
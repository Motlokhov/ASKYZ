using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public class CommonExercise : Exercise
    {
        public CommonExercise(IQueryResult queryResult, ulong testID) : base(queryResult)
        {
            Type = ExerciseType.common;
            RequiredNumberQuestions = 50;
            CorrectAnswerNumberPoints = 1;
            Name = "Тестовые вопросы";
            Load(testID);
        }
    }
}
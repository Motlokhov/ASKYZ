using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public abstract class Exercise : Entity
    {
        private readonly IQueryResult _queryResult;
        public ExerciseType Type { get; protected set; }
        public byte RequiredNumberQuestions { get; protected set; }
        public byte CorrectAnswerNumberPoints { get; protected set; }

        public Result Result { get; set; }

        public ChildrenList<Question> Questions { get; private set; } = new ChildrenList<Question>();
        public Question Question => Questions.Current();

        public Exercise(IQueryResult queryResult)
        {
            _queryResult = queryResult;
        }

        public bool NextQuestion()
        {
            if(Questions.HasNext)
            {
                Questions.SetNext();
                return true;
            }
            return false;
        }

        public void DeleteQuestions()
        {
            var count = Questions.Count - RequiredNumberQuestions;
            Questions.RemoveRange(RequiredNumberQuestions, count);
        }

        protected void SwapQuestions()
        {
            int questionsCount = Questions.Count;
            for(var i = 0; i < questionsCount / 2; i++)
            {
                var random = Core.Random;
                int randomNumber = random.Next(questionsCount);

                var tempQuestion = Questions[i];
                Questions[i] = Questions[randomNumber];
                Questions[randomNumber] = tempQuestion;

            }
        }

        protected void Load(ulong testID)
        {
            ulong[] questionIds = _queryResult.LoadQuestionIds(testID, (int)Type);
            foreach(ulong questionId in questionIds)
                Questions.Add(new Question(_queryResult, questionId));

            SwapQuestions();
        }

        public bool IsAnswerCorrect(byte points) => CorrectAnswerNumberPoints == points;
    }
}


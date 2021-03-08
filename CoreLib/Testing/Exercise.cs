using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class Exercise:Entity
    {
        private readonly QueryResult _queryResult;
        public ExerciseType Type { get; private set; }
        public byte RequiredNumberQuestions { get; private set; }
        public byte MaxPoints { get; private set; }

        public Result Result { get; set; }

        public ChildrenList<Question> Questions { get; private set; } = new ChildrenList<Question>();
        public Question Question
        {
            get
            {
                return Questions.Current();
            }
        }

        public Exercise(QueryResult queryResult)
        {
            _queryResult = queryResult;
        }

        public bool NextQuestion()
        {
            if( Questions.GetIndex() + 1 < Questions.Count )
            {
                Questions.Next();
                return true;
            }
            return false;
        }

        public void DeleteQuestions()
        {
            var count = Questions.Count - RequiredNumberQuestions;
            Questions.RemoveRange(RequiredNumberQuestions , count);
        }

        protected void SwapQuestions()
        {
            int questionsCount = Questions.Count;
            for( var i = 0 ; i < questionsCount / 2 ; i++ )
            {
                var random = Main.Core.Random;
                int randomNumber = random.Next(questionsCount);

                var tempQuestion = Questions[i];
                Questions[i] = Questions[randomNumber];
                Questions[randomNumber] = tempQuestion;
                
            }
        }

        protected void SetType(ExerciseType type)
        {
            Type = type;
        }
       
        protected void SetMaxPoints(byte points)
        {
            MaxPoints = points;
        }

        protected void SetRequiredNumberQuestions(byte number)
        {
            RequiredNumberQuestions = number;
        }

        protected void Load(ulong testID)
        {
            ulong[] questionIds = _queryResult.LoadQuestionIds(testID, (int)Type);
                foreach(ulong questionId in questionIds)
                    Questions.Add(new Question(_queryResult, questionId));
                
            SwapQuestions();
        }
    }
}


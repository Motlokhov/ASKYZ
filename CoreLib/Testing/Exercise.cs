using Database;
using CoreLib.Common;
using System;
using Database.Result;

namespace CoreLib.Testing
{
    public class Exercise:Entity
    {
        public ExerciseType Type { get; private set; }
        public byte RequiredNumberQuestions { get; private set; }
        public byte MaxPoints { get; private set; }

        public Result Result { get; set; }

        public ChildrenList Questions { get; private set; }
        public Question Question
        {
            get
            {
                return Questions.Current() as Question;
            }
        }

        public Exercise()
        {
            Questions = new ChildrenList();       

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
                var random = CoreLib.Main.Core.Random;
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
            ulong[] questionIds = QueryResult.LoadQuestionIds(testID, (int)Type);
                foreach(ulong questionId in questionIds)
                    Questions.Add(new Question(questionId));
                
            SwapQuestions();
        }
    }
}


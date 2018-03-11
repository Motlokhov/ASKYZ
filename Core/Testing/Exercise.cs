using Query;
namespace Core.Testing
{
    using Query;
    using Common;
    using System;

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
                var random = Core.Random;
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
            using( var query = new Query() )
            {
                var reader = query.ReadData("SELECT ID FROM Question WHERE TestID = " + testID + " AND Type = " + (int) Type);

                while( reader.Read() )
                {
                    ulong questionID = Convert.ToUInt64(reader["ID"]);
                    Questions.Add(new Question(questionID));
                }
                SwapQuestions();
            }
        }
    }
}


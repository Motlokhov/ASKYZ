using CoreLib.Common;

namespace CoreLib.Testing
{
    public class Test:Entity
    {     
        protected TestType _type;

        public ChildrenList Exercises { get; private set; }

        public delegate void TestEnding();
        public event TestEnding testEnding;

        public Exercise Exercise
        {
            get
            {
                return Exercises.Current() as Exercise;
            }
        }

        public new TestType GetType()
        {
            return _type;
        }

        public Test()
        {
            Exercises = new ChildrenList();
        }

        public virtual bool VerifyQuestion(ulong[] answersID)
        {
            Question.Verify(answersID);
            return true;
        }


        public bool NextQuestion()
        {
            if( !Exercise.NextQuestion() )
            {
                if( !NextExercise() )
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool NextExercise()
        {
            if( Exercises.HasNextIndex() )
            {
                Exercises.Next();
                return true;
            }
            return false;
        }

        public bool PreviousExercise()
        {
            if( Exercises.GetIndex() != 0 )
            {
                Exercises.Previous();
                return true;
            }
            return false;
        }

        public void PassQuestion()
        {
            var question = Exercise.Question;
            Exercise.Questions.Remove(question);
            Exercise.Questions.Add(question);
        }

        public virtual void TestEnd()
        {
            testEnding();
        }

        public string GetNextExerciseName()
        {
            Exercise exercise = (Exercise) Exercises[Exercises.GetIndex() + 1];
            return exercise.GetName();
        }

        public string GetPreviousExerciseName()
        {
            Exercise exercise = (Exercise) Exercises[Exercises.GetIndex() - 1];
            return exercise.GetName();
        }

        public byte GetAllPoints()
        {
            byte points = 0;
            foreach(Exercise exercise in Exercises )
            {
                points += exercise.Result.Points;
            }
            return points;
        }
    }
}

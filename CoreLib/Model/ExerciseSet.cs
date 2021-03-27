using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public abstract class ExerciseSet : Entity
    {
        protected readonly IQueryResult QueryResult;
        protected readonly ExerciseSetType Type;

        public ChildrenList<Exercise> Exercises { get; private set; } = new ChildrenList<Exercise>();

        public delegate void TestEndingDelegate();
        public event TestEndingDelegate TestEnding;

        public ExerciseSet(IQueryResult queryResult, ExerciseSetType exerciseSetType)
        {
            QueryResult = queryResult;
            Type = exerciseSetType;
        }

        public Exercise Exercise
        {
            get
            {
                return Exercises.Current() as Exercise;
            }
        }

        public new ExerciseSetType GetType()
        {
            return Type;
        }

        public virtual bool VerifyQuestion(ulong[] answersIds)
        {
            QueryResult.LoadSumPoints(answersIds);
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
            TestEnding();
        }

        public string GetNextExerciseName()
        {
            Exercise exercise = (Exercise) Exercises[Exercises.GetIndex() + 1];
            return exercise.Name;
        }

        public string GetPreviousExerciseName()
        {
            Exercise exercise = (Exercise) Exercises[Exercises.GetIndex() - 1];
            return exercise.Name;
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

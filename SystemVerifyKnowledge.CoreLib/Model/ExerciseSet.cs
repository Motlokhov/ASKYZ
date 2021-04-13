using System;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public abstract class ExerciseSet : Entity
    {
        public ExerciseSetType Type { get; protected set; }
        public Exercise Exercise => Exercises.Current();
        public Exercise this[int index] => Exercises[index];
        public bool HasNextExercise => Exercises.HasNext;
        public bool HasPreviousExercise => Exercises.HasPrevious;
        public string GetNextExerciseName => Exercises[Exercises.Index + 1].Name;
        public string GetPreviousExerciseName => Exercises[Exercises.Index - 1].Name;

        public event Action KnowledgeVerifyingEnded;

        protected ChildrenList<Exercise> Exercises = new ChildrenList<Exercise>();
        protected readonly IQueryResult QueryResult;

        public ExerciseSet(IQueryResult queryResult, ExerciseSetType exerciseSetType, ulong programGroupID)
        {
            QueryResult = queryResult;
            Type = exerciseSetType;
            Id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)Type);

            Exercises.Add(new CommonExercise(queryResult, Id));
            Exercises.Add(new ThemenExercise(queryResult, Id));
            Exercises.Add(new PracticalExercise(queryResult, Id));
        }

        public abstract bool IsNextQuestionAvailable(ulong[] answersIds);
        public virtual void TestEnd() => KnowledgeVerifyingEnded();

        public bool NextQuestion()
        {
            if(!Exercise.NextQuestion())
            {
                if(!NextExercise())
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool NextExercise()
        {
            if(Exercises.HasNext)
            {
                Exercises.SetNext();
                return true;
            }
            return false;
        }

        public bool PreviousExercise()
        {
            if(Exercises.HasPrevious)
            {
                Exercises.SetPrevious();
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

        public byte GetAllPoints()
        {
            byte points = 0;
            foreach(Exercise exercise in Exercises)
            {
                points += exercise.Result.Points;
            }
            return points;
        }
    }
}

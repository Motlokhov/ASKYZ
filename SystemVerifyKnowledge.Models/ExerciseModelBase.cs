using System;
using System.Linq;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public abstract class ExerciseModelBase : Entity
    {
        public ExerciseSetType Type { get; protected set; }
        public Exercise Exercise => Exercises.Current();
        public Exercise this[int index] => Exercises[index];
        public bool HasNextExercise => Exercises.HasNext;
        public bool HasPreviousExercise => Exercises.HasPrevious;
        public string GetNextExerciseName => Exercises[Exercises.Index + 1].Name;
        public string GetPreviousExerciseName => Exercises[Exercises.Index - 1].Name;

        public event Action KnowledgeVerifyingEnded;

        protected ChildrenList<Exercise> Exercises = new();
        protected readonly IQueryResult QueryResult;

        public ExerciseModelBase(IQueryResult queryResult, ExerciseSetType exerciseSetType)
        {
            QueryResult = queryResult;
            Type = exerciseSetType;
        }

        public void Load(ulong programGroupID)
        {
            Id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)Type);

            Exercises.Add(new CommonExercise(QueryResult, Id));
            Exercises.Add(new ThemenExercise(QueryResult, Id));
            Exercises.Add(new PracticalExercise(QueryResult, Id));
        }

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

        public byte GetAllPoints() => (byte)Exercises.Sum(e => e.Result.Points);
    }
}

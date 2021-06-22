using System.Linq;
using SystemVerifyKnowledge.Common;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;
using SystemVerifyKnowledge.CoreLib.Model;

namespace SystemVerifyKnowledge.Models
{
    public class GrandExerciseModel : ExerciseModelBase, IGrandExerciseModel
    {
        public Student Student { get; private set; }

        public GrandExerciseModel(IQueryResult queryResult) 
            : base(queryResult, ExerciseSetType.Grand)
        {
            Name = "Итоговая аттестация"; 
        }

        public void LoadFor(Student student)
        {
            Student = student;
            Load(student.ProgramGroupId);
            foreach(Exercise exercise in Exercises)
            {
                exercise.DeleteQuestions();
                exercise.Result = new Result(QueryResult);
            }
        }

        public void VerifyAnswers(ulong[] answersIds)
        {
            byte points = QueryResult.LoadSumPoints(answersIds);
            Exercise.Result.Points += points;

            if(Exercise.IsAnswerCorrect(points))
                Exercise.Result.TrueAnswers += 1;
        }

        public void TestEnd()
        {
            foreach(Exercise exercise in Exercises)
            {
                int countQuestions = exercise.Questions.Count;
                exercise.Result.CalculateFalseAnswers(countQuestions);
            }
            SaveResults();
        }

        private void SaveResults()
        {
            QueryResult.WriteTestResults
            (Student.Id,
            Student.ProgramGroupId,
            Exercises.Select(e => ((int)e.Type, e.Result.Points, e.Result.TrueAnswers, e.Result.FalseAnswers)).ToArray());
        }
    }
}

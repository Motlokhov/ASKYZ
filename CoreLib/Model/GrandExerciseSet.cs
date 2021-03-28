using System.Linq;
using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Model
{
    public class GrandExerciseSet : ExerciseSet
    {
        public GrandExerciseSet(IQueryResult queryResult, ulong programGroupID) : base(queryResult, ExerciseSetType.Grand, programGroupID)
        {
            Name = "Итоговая аттестация";

            foreach( Exercise exercise in Exercises )
            {
                exercise.DeleteQuestions();
                exercise.Result = new Result(QueryResult);
            }
        }

        public override bool IsNextQuestionAvailable(ulong[] answersIds)
        {
            //[todo] Метод частично врет, что он также манипулирует TrueAnswers
            byte points = QueryResult.LoadSumPoints(answersIds);
            Exercise.Result.Points += points;
            if( Exercise.MaxPoints == points )
                Exercise.Result.TrueAnswers += 1;
            
            return true;
        }

        public override void TestEnd()
        {
            foreach( Exercise exercise in Exercises )
            {
                int countQuestions = exercise.Questions.Count;
                exercise.Result.CalculateFalseAnswers(countQuestions);
            }
            SaveResults();
            base.TestEnd();
        }

        private void SaveResults()
        {
            QueryResult.WriteTestResults
            (Main.Core.User.Id, 
            Main.Core.ProgramGroupID, 
            Exercises.Select(e => ((int)e.Type,e.Result.Points,e.Result.TrueAnswers,e.Result.FalseAnswers)).ToArray());
        }
    }
}

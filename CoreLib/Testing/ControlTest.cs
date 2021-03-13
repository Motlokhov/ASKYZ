using System.Linq;
using CoreLib.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    public class ControlTest : Test
    {
        public ControlTest(IQueryResult queryResult, ulong programGroupID) : base(queryResult, TestType.control)
        {
            Name = "Итоговая аттестация";
            Id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)Type);

            Exercises.Add(new CommonExercise(queryResult, Id));
            Exercises.Add(new ThemenExercise(queryResult, Id));
            Exercises.Add(new PracticalExercise(queryResult, Id));

            foreach( Exercise exercise in Exercises )
            {
                exercise.DeleteQuestions();
                exercise.Result = new Result(QueryResult);
            }
        }

        public override bool VerifyQuestion(ulong[] answersIds)
        {
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

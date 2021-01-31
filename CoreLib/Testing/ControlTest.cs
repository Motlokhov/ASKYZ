using System.Linq;
using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
    public class ControlTest : Test
    {

        public ControlTest(ulong programGroupID) : base()
        {
            _type = TestType.control;
            _name = "Итоговая аттестация";
            _id = QueryResult.LoadTestIdByProgramGroupIdAndType(programGroupID, (int)_type);

            Exercises.Add(new CommonExercise(_id));
            Exercises.Add(new ThemenExercise(_id));
            Exercises.Add(new PracticalExercise(_id));

            foreach( Exercise exercise in Exercises )
            {
                exercise.DeleteQuestions();
                exercise.Result = new Result();
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
                var result = exercise.Result;
                exercise.Result.CalculateFalseAnswers(countQuestions);
            }
            SaveResults();
            base.TestEnd();
        }

        private void SaveResults()
        {
            QueryResult.WriteTestResults
            (Main.Core.User.GetID(), 
            Main.Core.ProgramGroupID, 
            Exercises.Select(e => ((int)e.Type,e.Result.Points,e.Result.TrueAnswers,e.Result.FalseAnswers)).ToArray());
        }
    }
}

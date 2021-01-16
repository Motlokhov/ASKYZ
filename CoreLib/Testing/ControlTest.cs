using System;
using CoreLib.Common;
using Database;

namespace CoreLib.Testing
{
    public class ControlTest : Test
    {

        public ControlTest(ulong programGroupID) : base()
        {
            _type = TestType.control;
            _name = "Итоговая аттестация";

            using( var query = new Query() )
            {
                var reader = query.ReadData("SELECT ID FROM Test WHERE ProgramGroupID =" + programGroupID + "AND Type = " + (int) _type);
                reader.Read();
                _id = Convert.ToUInt64(reader["ID"]);
            }
            Exercises.Add(new CommonExercise(_id));
            Exercises.Add(new ThemenExercise(_id));
            Exercises.Add(new PracticalExercise(_id));

            foreach( Exercise exercise in Exercises )
            {
                exercise.DeleteQuestions();
                exercise.Result = new Result();
            }

        }

        public override bool VerifyQuestion(ulong[] answersID)
        {
            byte points = Question.Verify(answersID);
            var result = Exercise.Result;
            result.Points += points;
            if( Exercise.MaxPoints == points )
            {
                result.TrueAnswers += 1;
            }
            Exercise.Result = result;
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
            byte programGroupID = CoreLib.Main.Core.ProgramGroupID;
            ulong userID = CoreLib.Main.Core.User.GetID();

            var today = DateTime.Today.ToString("d");
            var query = new Query();
            var testingDateID = query.ExecuteScalar("INSERT INTO TestingDate (UserID,ProgramGroupID,Date) VALUES(" + userID + "," + programGroupID + ",'" + today + "') SELECT @@IDENTITY");

            foreach( Exercise exercise in Exercises )
            {
                var exerciseType = (int) exercise.Type;
                var points = exercise.Result.Points;
                var trueAnswers = exercise.Result.TrueAnswers;
                var falseAnswers = exercise.Result.FalseAnswers;
                query.ExecuteNonQuery("INSERT INTO TestingResult(TestingDateID,ExerciseType,Points,TrueAnswers,FalseAnswers) VALUES(" + testingDateID + "," + exerciseType + "," + points + "," + trueAnswers + "," + falseAnswers + ")");
            }
        }
    }
}

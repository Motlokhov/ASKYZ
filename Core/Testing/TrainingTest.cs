using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Testing
{
    using Query;
    class TrainingTest : Test
    {
        public TrainingTest(ulong programGroupID) : base()
        {
            _type = TestType.training;
            _name = "Обучающее тестирование";

            using( var query = new Query() )
            {
                var reader = query.ReadData("SELECT ID FROM Test WHERE ProgramGroupID =" + programGroupID + "AND Type = " + (int)_type);
                reader.Read();
                _id = Convert.ToUInt64(reader["ID"]);
            }

            Exercises.Add(new CommonExercise(_id));
            Exercises.Add(new ThemenExercise(_id));
            Exercises.Add(new PracticalExercise(_id));
        }

        public override bool VerifyQuestion(ulong[] answersID)
        {
            byte points = Question.Verify(answersID);
            if( Exercise.MaxPoints == points )
            {
                return true;
            }
            return false;
        }


    }
}

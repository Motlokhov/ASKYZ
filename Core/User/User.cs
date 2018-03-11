using System;

namespace Core
{
    using Query;
    using Common;
    using System.Text;
    using Testing;

    public class User : Entity
    {
        private byte _programGroupID;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private uint _passportNumber;
        private ushort _passportSerie;
        private ChildrenList _results;
        private ulong _testingDateID;

        public Result GetResult(int index)
        {
            return (Result)_results[index];
        }
        public byte GetProgramGroupID()
        {
            return _programGroupID;
        }

        public void SetTestingDateID(ulong testingDateID)
        {
            _testingDateID = testingDateID;
        }

        public DateTime GetDateStart()
        {
            return _dateStart;
        }

        public DateTime GetDateEnd()
        {
            return _dateEnd;
        }
        public User(ulong id)
        {
            _id = id;
            var query = new Query();
            var reader = query.ReadData("SELECT * FROM [User] WHERE ID = " + id);
            if( reader.Read() )
            {
                _name = reader["Surname"] + " " + reader["Firstname"] + " " + reader["Lastname"];
                _programGroupID = Convert.ToByte(reader["ProgramGroupID"]);
                _dateStart = Convert.ToDateTime(reader["DateStartTest"]);
                _dateEnd = Convert.ToDateTime(reader["DateEndTest"]);
                _passportNumber = Convert.ToUInt32(reader["PassportNumber"]);
                _passportSerie = Convert.ToUInt16(reader["PassportSerie"]);
                return;
            }
            throw new Exception("Не удалось загрузить пользователя");
        }

        public void LoadResults()
        {
            _results = new ChildrenList();
            _results.Add(new Result(_testingDateID , ExerciseType.common));
            _results.Add(new Result(_testingDateID , ExerciseType.common));
            _results.Add(new Result(_testingDateID , ExerciseType.practical));
        }


        private static void NormingWord(ref string word)
        {
            // Function provides tranlation of the word to the normal form where first char is upper-case and each other are lower-case.
            word = word.ToLower();
            string symbol = word[0].ToString().ToUpper();
            word = word.Remove(0 , 1);
            word = symbol + word;
        }

        public byte GetProgramNumber()
        {
            var query = new Query();
            var result = query.ExecuteScalar("SELECT Number FROM ProgramGroup WHERE ID = " + _programGroupID);
            return Convert.ToByte(result);
        }

        public static bool Registration(string firstname , string surname , string lastname ,
           ushort passportSerie , uint passportNumber , DateTime startDate , DateTime endDate ,
           string password , ulong programGroupID)
        {
            NormingWord(ref firstname);
            NormingWord(ref surname);
            NormingWord(ref lastname);

            ulong id = Convert.ToUInt64(passportSerie.ToString() + passportNumber.ToString());

            string commandText = "INSERT INTO [User] (Firstname,Surname,Lastname,PassportSerie,PassportNumber,DateStartTest,DateEndTest,Password,ProgramGroupId,ID) ";
            commandText += String.Format("VALUES ('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},{9})" , new object[] { firstname , surname , lastname , passportSerie , passportNumber , startDate , endDate , password , programGroupID , id });
            var query = new Query();
            int affectedRows = query.ExecuteNonQuery(commandText);
            if( affectedRows > 0 )
            {
                return true;
            }
            return false;
        }
    }
}

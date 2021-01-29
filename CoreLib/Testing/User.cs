using System;
using Database;
using CoreLib.Common;
using Database.Result;

namespace CoreLib.Testing
{
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
            (string surname, 
                string firstname, 
                string lastname, 
                byte programGroupId, 
                DateTime dateStartTest, 
                DateTime dateEndTest, 
                uint passportNumber, 
                ushort passportSerie)? result = QueryResult.LoadUserById(id);

            if(result.HasValue)
            {
                _name = string.Concat(result.Value.surname, " ", result.Value.firstname, " ", result.Value.lastname);
                _programGroupID = result.Value.programGroupId;
                _dateStart = result.Value.dateStartTest;
                _dateEnd = result.Value.dateEndTest;
                _passportNumber = result.Value.passportNumber;
                _passportSerie = result.Value.passportSerie;
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

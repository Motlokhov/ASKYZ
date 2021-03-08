using System;
using Database;
using CoreLib.Common;
using Database.Result;
using System.Data.Common;

namespace CoreLib.Testing
{
    public class User : Entity
    {
        private readonly QueryResult _queryResult;

        private byte _programGroupID;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private uint _passportNumber;
        private ushort _passportSerie;
        private ChildrenList<Result> _results;
        private ulong _testingDateID;

        public Result GetResult(int index)
        {
            return _results[index];
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
        public User(QueryResult queryResult, ulong id)
        {
            _queryResult = queryResult;

            _id = id;
            (string surname, 
                string firstname, 
                string lastname, 
                byte programGroupId, 
                DateTime dateStartTest, 
                DateTime dateEndTest, 
                uint passportNumber, 
                ushort passportSerie)? result = _queryResult.LoadUserById(id);

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
            _results = new ChildrenList<Result>
            {
                new Result(_queryResult, _testingDateID, ExerciseType.common),
                new Result(_queryResult, _testingDateID, ExerciseType.common),
                new Result(_queryResult, _testingDateID, ExerciseType.practical)
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Database.Result
{
    public class QueryResult
    {
        private readonly Func<DbConnection> _connectionFunction;
        
        public QueryResult(Func<DbConnection> connectionFunction)
        {
            _connectionFunction = connectionFunction;
        }

        /// <summary>
        /// Returns all testing directions
        /// </summary>
        /// <returns>A tuple collection (id,name) of directions</returns>
        public (byte id, string name)[] LoadAllDirections()
        {
            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                string command = "SELECT Id,Name FROM Direction";
                using(DbDataReader dbDataReader = query.ReadData(command))
                {
                    List<(byte, string)> result = new List<(byte, string)>();

                    while(dbDataReader.Read())
                        result.Add((Convert.ToByte(dbDataReader["ID"]), dbDataReader["Name"].ToString()));

                    return result.ToArray();
                }
            }
        }

        /// <summary>
        /// Returns user's id from database if <paramref name="id"/> and <paramref name="password"/> are exists;
        /// </summary>
        /// <param name="id">User's id</param>
        /// <param name="password">User's password</param>
        /// <returns>If exists returns id else null.</returns>
        /// <exception cref="ArgumentException">Throws if <paramref name="id"/> or <paramref name="password"/> is null or empty</exception>
        public ulong? GetUserId(string id, string password)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentException($"Parameter {nameof(id)} can't be null or empty in {nameof(GetUserId)}");

            if(string.IsNullOrEmpty(password))
                throw new ArgumentException($"Parameter {nameof(password)} can't be null or empty in {nameof(GetUserId)}");

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("@id", DbType.Int64, id);
                query.AddParameter("@password", DbType.String, password);
                object result = query.ExecuteScalar("SELECT ID FROM [User] WHERE ID = @id AND Password = @password");
                return result == null ? default(ulong?) : Convert.ToUInt64(result);
            }
        }

        /// <summary>
        /// Returns direction name of program group
        /// </summary>
        /// <param name="programGroupId"></param>
        /// <returns>If exists returns direction name otherwise <see langword="null"/></returns>
        public string LoadDirectionName(byte programGroupId)
        {
            string command = 
            @"SELECT Direction.[Name] 
            FROM Direction 
            JOIN ProgramGroup ON Direction.ID = ProgramGroup.DirectionID 
            WHERE ProgramGroup.ID = @programGroupId;";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("programGroupId", DbType.Byte, programGroupId);
                return query.ExecuteScalar(command)?.ToString();
            }
        }

        /// <summary>
        /// Returns a collection of education programs
        /// </summary>
        /// <param name="directionID">Education direction id</param>
        /// <param name="testType">Education test type</param>
        /// <returns>A collection of education programs</returns>
        public (byte id, string name, byte number)[] LoadProgramsByDirecionAndType(byte directionID, int testType)
        {
            string command =
            @"SELECT 
                ProgramGroup.ID
                ,Name
                ,Number 
            FROM ProgramGroup 
            JOIN Test ON Test.ProgramGroupID = ProgramGroup.ID 
            WHERE DirectionID = @directionID AND Test.[Type] = @testType";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("directionId", DbType.Byte, directionID);
                query.AddParameter("testType", DbType.Byte, testType);
                using(DbDataReader reader = query.ReadData(command))
                {
                    List<(byte, string, byte)> result = new List<(byte, string, byte)>();
                    while(reader.Read())
                        result.Add(
                            (Convert.ToByte(reader["ID"]), 
                            Convert.ToString(reader["Name"]), 
                            Convert.ToByte(reader["Number"])));

                    return result.ToArray();
                }
            }
        }

        /// <summary>
        /// Returns name and number an education program 
        /// </summary>
        /// <param name="programGroupId">Education's program group id</param>
        /// <returns>A tuple(name,number) an education program if exists otherwise <see langword="null"/></returns>
        public (string name, byte number)? LoadProgramByProgramGroupId(byte programGroupId)
        {
            string command = "SELECT Name,Number FROM ProgramGroup WHERE ID = @programGroupId";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("programGroupId", DbType.String, programGroupId);
                using(DbDataReader reader = query.ReadData(command))
                    if(reader.Read())
                        return (Convert.ToString(reader["Name"]), Convert.ToByte(reader["Number"]));
            }

            return null;
        }

        /// <summary>
        /// Return array of all test's dates ordered by nearest to oldest
        /// </summary>
        /// <returns>Datetime array</returns>
        public DateTime[] LoadTestingDates()
        {
            string commandString = "SELECT distinct [Date] FROM TestingDate ORDER BY [Date] DESC";
            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                List<DateTime> result = new List<DateTime>();
                using(var reader = query.ReadData(commandString))
                    while(reader.Read())
                        result.Add(Convert.ToDateTime(reader["Date"]));

                return result.ToArray();
            }
        }

        /// <summary>
        /// Return a user data.
        /// </summary>
        /// <param name="userId">User's id</param>
        /// <returns>A tuple(surname,firstname,lastname,programGroupId,dateStartTest,dateEndTest,passportNumber,passportSerie) if exists otherwise null.</returns>
        public 
            (string surname
            , string firstname
            , string lastname
            , byte programGroupId
            , DateTime dateStartTest
            , DateTime dateEndTest
            , uint passportNumber
            , ushort passportSerie)?
            LoadUserById(ulong userId)
        {
            string command = "SELECT * FROM[User] WHERE ID = @id";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("id", DbType.Int64, userId);
                using(DbDataReader reader = query.ReadData(command))
                {
                    if(reader.Read())
                        return
                            (reader["Surname"]?.ToString(),
                            reader["Firstname"]?.ToString(),
                            reader["Lastname"]?.ToString(),
                            Convert.ToByte(reader["ProgramGroupID"]),
                            Convert.ToDateTime(reader["DateStartTest"]),
                            Convert.ToDateTime(reader["DateEndTest"]),
                            Convert.ToUInt32(reader["PassportNumber"]),
                            Convert.ToUInt16(reader["PassportSerie"]));

                    return null;
                }
            }
        }

        private void NormingWord(ref string word)
        {
            // Function provides tranlation of the word to the normal form where first char is upper-case and each other are lower-case.
            word = word.ToLower();
            string symbol = word[0].ToString().ToUpper();
            word = word.Remove(0, 1);
            word = symbol + word;
        }

        /// <summary>
        /// Insert new user into database.
        /// Several things are done before insertion:
        /// <para>Values 'firstname', 'surname', 'lastname' transform to 'Firstname', 'Surname', 'Lastname'.</para>
        /// <para>Id is concat of <paramref name="passportSerie"/> and <paramref name="passportNumber"/>."/></para>
        /// </summary>
        /// <param name="firstname">First name. (Petr)</param>
        /// <param name="surname">Surname. (Petrov)</param>
        /// <param name="lastname">Lastname (Petrovich)</param>
        /// <param name="passportSerie">Passport serie (xxxx)</param>
        /// <param name="passportNumber">Passport number (yyyyyy)</param>
        /// <param name="startDate">Start date test</param>
        /// <param name="endDate">End date test</param>
        /// <param name="password">User password</param>
        /// <param name="programGroupID">Program group.</param>
        /// <returns></returns>
        public bool InsertNewUser(string firstname, 
            string surname, 
            string lastname,
           ushort passportSerie, 
           uint passportNumber, 
           DateTime startDate, 
           DateTime endDate,
           string password, 
           ulong programGroupID)
        {
            NormingWord(ref firstname);
            NormingWord(ref surname);
            NormingWord(ref lastname);

            ulong id = Convert.ToUInt64(passportSerie.ToString() + passportNumber.ToString());

            string commandText = $@"INSERT INTO [User] (
            Firstname
            ,Surname
            ,Lastname
            ,PassportSerie
            ,PassportNumber
            ,DateStartTest
            ,DateEndTest
            ,Password
            ,ProgramGroupId
            ,ID)
            VALUES(
            @firstname
            ,@surname
            ,@lastName
            ,@serie
            ,@number
            ,@datestart
            ,@dateend
            ,@password
            ,@programgroupId
            ,@id)";

            using(var query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("firstname", DbType.String, firstname);
                query.AddParameter("surname", DbType.String, surname);
                query.AddParameter("lastname", DbType.String, lastname);
                query.AddParameter("serie", DbType.UInt16, passportSerie);
                query.AddParameter("number", DbType.UInt32, passportNumber);
                query.AddParameter("datestart", DbType.DateTime, startDate);
                query.AddParameter("dateend", DbType.DateTime, endDate);
                query.AddParameter("password", DbType.String, password);
                query.AddParameter("programgroupid", DbType.Byte, programGroupID);
                query.AddParameter("id", DbType.Int64, id);

                return query.ExecuteNonQuery(commandText) > 0;
            }
        }

        /// <summary>
        /// Returns user's id and and user's password if <paramref name="passportSerie"/> and <paramref name="passportNumber"/> are exists.
        /// </summary>
        /// <param name="passportSerie">User's passport serie</param>
        /// <param name="passportNumber">User's passport number</param>
        /// <returns>User's tuple(id,password) if exists otherwise null.</returns>
        public (ulong id, string password)? FindPassword(uint passportSerie, uint passportNumber)
        {
            string commandString = "SELECT Id,Password FROM [User] WHERE PassportSerie = @passportSerie and PassportNumber = @passportNumber";
            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("passportSerie", DbType.Int32, passportSerie);
                query.AddParameter("passportNumber", DbType.Int32, passportNumber);
                using(DbDataReader reader = query.ReadData(commandString))
                {
                    reader.Read();
                    if(reader.HasRows)
                        return (Convert.ToUInt64(reader["Id"]), reader["Password"]?.ToString());
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns a test's collection question id.
        /// </summary>
        /// <param name="testId">Test id</param>
        /// <param name="exerciseType">Excercise type</param>
        /// <returns>A collection question id</returns>
        public ulong[] LoadQuestionIds(ulong testId, int exerciseType)
        {
            string command = "SELECT ID FROM Question WHERE TestID = @testId AND Type = @exerciseType";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("testId", DbType.Int64, testId);
                query.AddParameter("exerciseType", DbType.Int32, exerciseType);

                List<ulong> result = new List<ulong>();
                using(DbDataReader reader = query.ReadData(command))
                    while(reader.Read())
                        result.Add(Convert.ToUInt64(reader["ID"]));
                return result.ToArray();
            }
        }

        /// <summary>
        /// Return an array (userId, testingDateId) for the defined date.
        /// </summary>
        /// <param name="testingDate">Date of testing</param>
        /// <returns>An array (userId,testingDateId)</returns>
        public (ulong userID,ulong testingDateId)[] LoadUsersResultByTestingDate(string testingDate)
        {
            if(string.IsNullOrEmpty(testingDate))
                throw new ArgumentException($"Parameter {nameof(testingDate)} can't be null or empty in {nameof(LoadUsersResultByTestingDate)}");

            string command = "SELECT UserID,ID FROM TestingDate WHERE Date = @testingDate";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                List<(ulong, ulong)> result = new List<(ulong, ulong)>();

                query.AddParameter("testingDate", DbType.String, testingDate);
                using(DbDataReader reader = query.ReadData(command))
                    while(reader.Read())
                        result.Add((Convert.ToUInt64(reader["UserID"]), Convert.ToUInt64(reader["ID"])));

                return result.ToArray();
            }
            
        }

        /// <summary>
        /// Returns test id with program group id and test type.
        /// </summary>
        /// <param name="programGroupID">Program group id</param>
        /// <param name="testType">Test type</param>
        /// <returns>Test id</returns>
        /// <exception cref="InvalidDataException">If with <paramref name="programGroupID"/> and <paramref name="testType"/> has't value.</exception>
        public ulong LoadTestIdByProgramGroupIdAndType(ulong programGroupID, int testType)
        {
            string command = "SELECT ID FROM Test WHERE ProgramGroupID = @programGroupID AND Type = @testType";

            using(var query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("programGroupId", DbType.Int64, programGroupID);
                query.AddParameter("testType", DbType.Int32, testType);
                using(DbDataReader reader = query.ReadData(command))
                {
                    if(reader.Read())
                        return Convert.ToUInt64(reader["ID"]);
                    throw new InvalidDataException($"Query returns no value. In {nameof(LoadTestIdByProgramGroupIdAndType)} with programGroupId: '{programGroupID}' and type: {testType}");
                }
            }
        }

        /// <summary>
        /// Returns the number of correct and incorrect answers,
        /// as well as the amount of points for correct answers received during the control test for defined exercise
        /// </summary>
        /// <param name="testingDateId">Id testing date</param>
        /// <param name="exerciseType">Type of exercise</param>
        /// <returns>A tuple(numberCorrectAnswer,numberIncorrectanswers,points)</returns>
        public (byte numberCorrectAnswer, byte numberIncorrectanswers, byte points)? LoadTestResult(ulong testingDateId, int exerciseType)
        {
            string command = $@"
            SELECT 
                TrueAnswers
                ,FalseAnswers
                ,Points 
            FROM TestingResult 
            WHERE TestingDateID = testingDateId 
                AND ExerciseType = @exerciseType";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("testingDateId", DbType.Int64, testingDateId);
                query.AddParameter("exerciseType", DbType.Int64, exerciseType);
                using(DbDataReader reader = query.ReadData(command))
                {
                    if(reader.Read())
                        return (
                        Convert.ToByte(reader["TrueAnswers"]),
                        Convert.ToByte(reader["FalseAnswers"]),
                        Convert.ToByte(reader["Points"]));

                    return null;
                }
            }
        }

        /// <summary>
        /// Return test's question
        /// </summary>
        /// <param name="questionId">Question id</param>
        /// <returns>A tuple(description,image) if exists otherwise null</returns>
        public (string description, Image image)? LoadQuestion(ulong questionId)
        {
            string command = "SELECT Description,Picture FROM Question WHERE ID =  @questionId";
            using(var query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("questionId", DbType.Int64, questionId);
                using(DbDataReader reader = query.ReadData(command))
                {
                    if(reader.Read())
                    {
                        Image image = null;
                        try
                        {
                            byte[] buf = Convert.FromBase64String(Convert.ToBase64String((byte[])reader["Picture"]));
                            image = Image.FromStream(new MemoryStream(buf));
                        }
                        catch
                        { }

                        return (Convert.ToString(reader["Description"]), image);
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns a collection of question answers
        /// </summary>
        /// <param name="questionId">Asnwer's questionId</param>
        /// <returns>An question's answers tuple collection(id,description)</returns>
        public (ulong id,string description)[] LoadAnswers(ulong questionId)
        {
            using(var query = new Query(_connectionFunction.Invoke()))
            {
                using(DbDataReader reader = query.ReadData("SELECT Id,Description FROM Answer WHERE QuestionID = " + questionId))
                {
                    List<(ulong, string)> result = new List<(ulong, string)>();
                    while(reader.Read())
                        result.Add((Convert.ToUInt64(reader["ID"]), Convert.ToString(reader["Description"])));

                    return result.ToArray();
                }
            }
        }

        /// <summary>
        /// Return sum points for answers within a collection <paramref name="answerIds"/>.
        /// </summary>
        /// <param name="answerIds">A collection answer ids</param>
        /// <returns>Sum points</returns>
        /// <exception cref="ArgumentException">If <paramref name="answerIds"/> is null or empty</exception>
        /// <exception cref="InvalidDataException">If <paramref name="answerIds"/> no one id is exists or all have null values in database.</exception>
        public byte LoadSumPoints(ulong[] answerIds)
        {
            if(answerIds is null || !answerIds.Any())
                throw new ArgumentException($"Parameter '{nameof(answerIds)}' can't be null or empty in '{nameof(LoadSumPoints)}'");

            string answerIdsArray = string.Empty;
            for(var i = 0; i < answerIds.Length; i++)
            {
                answerIdsArray += answerIds[i];
                if(i + 1 < answerIds.Length)
                {
                    answerIdsArray += ",";
                }
            }

            string command = "SELECT SUM(Points) FROM Answer WHERE ID IN (@answerIdsArray)";

            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                query.AddParameter("answerIdsArray", DbType.String, answerIdsArray);
                object result = query.ExecuteScalar(command);
                if(result.Equals(DBNull.Value))
                    throw new InvalidDataException($"Query returns no value. In '{nameof(LoadSumPoints)}' for array '{answerIdsArray}'");

                return Convert.ToByte(result);
            }
        }

        public void WriteTestResults(ulong userId, ulong programGroupId, (int type, byte points, byte trueAnswers, byte falseAnswers)[] exercises)
        {
            using(Query query = new Query(_connectionFunction.Invoke()))
            {
                using(DbTransaction transaction = query.BeginTransaction())
                {
                    object testingDateID = query.ExecuteScalar("INSERT INTO TestingDate (UserID,ProgramGroupID,Date) VALUES(" + userId + "," + programGroupId + ",'" + DateTime.Today.ToString("d") + "') SELECT @@IDENTITY");

                    foreach(var exercise in exercises)
                        query.ExecuteNonQuery("INSERT INTO TestingResult(TestingDateID,ExerciseType,Points,TrueAnswers,FalseAnswers) VALUES(" + testingDateID + "," + exercise.type + "," + exercise.points + "," + exercise.trueAnswers + "," + exercise.falseAnswers + ")");

                    transaction.Commit();
                }
            }
        }

        public void WriteQuestions(int testID, int questionType, string question, byte[] picture, List<string> answers, List<short> trueAnswers)
        {
            ulong questionID = 0;
            using(var query = new Query(_connectionFunction.Invoke(), CommandType.StoredProcedure))
            {
                query.AddParameter("@TestID", DbType.Int32, testID);
                query.AddParameter("@description", DbType.String, question);
                query.AddParameter("@type", DbType.Int16, questionType);
                query.AddParameter("@picture", DbType.Binary, picture);
                questionID = Convert.ToUInt64(query.ExecuteScalar("AddQuestion"));
            }
            using(var query = new Query(_connectionFunction.Invoke()))
            {
                for(var i = 0; i < answers.Count; i++)
                {
                    short points = 0;
                    for(var j = 0; j < trueAnswers.Count; j++)
                    {
                        if(i + 1 == trueAnswers[j])
                        {
                            if(questionType == 0)
                            {
                                if(j == 0)
                                {
                                    points = 1;
                                }
                            }
                            else if(questionType == 1)
                            {
                                if(j == 0)
                                {
                                    points = 10;
                                }
                                else if(j == 1)
                                {
                                    points = 5;
                                }
                            }
                            else if(questionType == 2)
                            {
                                if(j == 0)
                                {
                                    points = 20;
                                }
                                else if(j == 1)
                                {
                                    points = 10;
                                }
                            }
                            else
                            {
                                throw new Exception("Выход за предел количества типов вопроса");
                            }
                        }

                    }
                    query.ExecuteNonQuery("INSERT INTO Answer (QuestionID,Description,Points) VALUES (" + questionID + ",N'" + answers[i] + "'," + points + ")");
                }
            }
        }
    }
}

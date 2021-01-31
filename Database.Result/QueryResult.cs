using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;

namespace Database.Result
{
    public static class QueryResult
    {
        public static (byte id, string name)[] LoadAllDirections()
        {
            using(Query query = new Query())
            {
                DbDataReader dbDataReader = query.ReadData("SELECT Id,Name FROM Direction");

                List<(byte, string)> result = new List<(byte, string)>();

                while(dbDataReader.Read())
                    result.Add((Convert.ToByte(dbDataReader["ID"]), dbDataReader["Name"].ToString()));

                return result.ToArray();
            }
        }

        public static ulong? GetUserId(string id, string password)
        {
            using(Query query = new Query())
            {
                object result = query.ExecuteScalar("SELECT ID FROM [User] WHERE ID = " + id + " AND Password = '" + password + "'");
                return result == null ? default(ulong?) : Convert.ToUInt64(result);
            }
        }

        public static string LoadDirectionName(byte programGroupId)
        {
            using(Query query = new Query())
                return query.ExecuteScalar("SELECT Direction.[Name] FROM Direction INNER JOIN ProgramGroup ON Direction.ID = ProgramGroup.DirectionID WHERE ProgramGroup.ID = " + programGroupId).ToString();
        }

        public static (byte id, string name, byte number)[] LoadProgramsByDirecionAndType(byte directionID, int testType)
        {
            List<(byte, string, byte)> result = new List<(byte, string, byte)>();
            using(Query query = new Query())
            {
                using(DbDataReader reader =
                    query.ReadData("SELECT ProgramGroup.ID,Name,Number FROM ProgramGroup INNER JOIN Test ON Test.ProgramGroupID = ProgramGroup.ID WHERE DirectionID = " + directionID + " AND Test.[Type] = " + (int)testType))
                {
                    while(reader.Read())
                        result.Add((Convert.ToByte(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToByte(reader["Number"])));

                    return result.ToArray();
                }
            }
        }

        public static (string name, byte number)? LoadProgramByProgramGroupId(byte programGroupId)
        {
            using(Query query = new Query())
                using(DbDataReader reader = query.ReadData("SELECT Name,Number FROM ProgramGroup WHERE ID = " + programGroupId))
                    if(reader.Read())
                        return (Convert.ToString(reader["Name"]), Convert.ToByte(reader["Number"]));

            return null;
        }

        public static DateTime[] LoadTestingDates()
        {
            string commandString = "SELECT distinct [Date] FROM TestingDate ORDER BY [Date] DESC";
            using(Query query = new Query())
            {
                List<DateTime> result = new List<DateTime>();
                using(var reader = query.ReadData(commandString))
                    while(reader.Read())
                        result.Add(Convert.ToDateTime(reader["Date"]));

                return result.ToArray();
            }
        }

        public static 
            (string surname
            , string firstname
            , string lastname
            , byte programGroupId
            , DateTime dateStartTest
            , DateTime dateEndTest
            , uint passportNumber
            , ushort passportSerie)?
            LoadUserById(ulong id)
        {
            using(Query query = new Query())
            {
                using(DbDataReader reader = query.ReadData("SELECT * FROM [User] WHERE ID = " + id))
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

        private static void NormingWord(ref string word)
        {
            // Function provides tranlation of the word to the normal form where first char is upper-case and each other are lower-case.
            word = word.ToLower();
            string symbol = word[0].ToString().ToUpper();
            word = word.Remove(0, 1);
            word = symbol + word;
        }

        public static bool AddNewUser(string firstname, 
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

            string commandText = $@"INSERT INTO [User] (Firstname,Surname,Lastname,PassportSerie,PassportNumber,DateStartTest,DateEndTest,Password,ProgramGroupId,ID) 
                                   VALUES('{firstname}','{surname}','{lastname}',{passportSerie},{passportNumber},'{startDate}','{endDate}','{password}',{programGroupID},{id})";

            using(var query = new Query())
                return query.ExecuteNonQuery(commandText) > 0;
        }

        public static (ulong id, string password)? FindPassword(uint serialOfPassport, uint numberOfPassport)
        {
            string commandString = "SELECT Id,Password FROM [User] ";
            commandString += "WHERE PassportSerie = " + serialOfPassport + " and PassportNumber = " + numberOfPassport;
            using(Query query = new Query())
            {
                using(DbDataReader reader = query.ReadData(commandString))
                {
                    reader.Read();
                    if(reader.HasRows)
                        return (Convert.ToUInt64(reader["Id"]), reader["Password"]?.ToString());
                    return null;
                }
            }
        }

        public static ulong[] LoadQuestionIds(ulong testId, int exerciseType)
        {
            using(Query query = new Query())
            {
                List<ulong> result = new List<ulong>();
                using(DbDataReader reader = query.ReadData("SELECT ID FROM Question WHERE TestID = " + testId + " AND Type = " + exerciseType))
                    while(reader.Read())
                        result.Add(Convert.ToUInt64(reader["ID"]));
                return result.ToArray();
            }
        }

        public static (ulong userID,ulong testingDateId)[] LoadUsersResultByTestingDate(string testingDate)
        {
            List<(ulong, ulong)> result = new List<(ulong, ulong)>();
            using(Query query = new Query())
            using(DbDataReader reader = query.ReadData("SELECT UserID,ID FROM TestingDate WHERE Date = '" + testingDate + "'"))
                while(reader.Read())
                    result.Add((Convert.ToUInt64(reader["UserID"]), Convert.ToUInt64(reader["ID"])));
            return result.ToArray();
        }

        public static ulong LoadTestIdByProgramGroupIdAndType(ulong programGroupID, int type)
        {
            using(var query = new Query())
            {
                using(DbDataReader reader = query.ReadData("SELECT ID FROM Test WHERE ProgramGroupID =" + programGroupID + "AND Type = " + type))
                {
                    reader.Read();
                    return Convert.ToUInt64(reader["ID"]);
                }
            }
        }

        public static (byte trueAnswersCount, byte falseAnswerCount, byte points)? LoadTestResult(ulong testingDateId, int exerciseType)
        {
            string command = $"SELECT TrueAnswers,FalseAnswers,Points FROM TestingResult WHERE TestingDateID = {testingDateId} AND ExerciseType = {exerciseType}";
            using(Query query = new Query())
            using(DbDataReader reader = query.ReadData(command))
            {
                if(reader.Read())
                    return (Convert.ToByte(reader["TrueAnswers"]),
                    Convert.ToByte(reader["FalseAnswers"]),
                    Convert.ToByte(reader["Points"]));

                return null;
            }
        }

        public static (string description, Image image) LoadQuestion(ulong questionId)
        {
            using(var query = new Query())
            {
                using(DbDataReader reader = query.ReadData("SELECT Description,Picture FROM Question WHERE ID = " + questionId))
                {
                    reader.Read();
                    string name = Convert.ToString(reader["Description"]);
                    Image image = null;
                    byte[] buf;
                    try
                    {
                        buf = Convert.FromBase64String(Convert.ToBase64String(((byte[])reader["Picture"])));
                        image = Image.FromStream(new MemoryStream(buf));
                    }
                    catch
                    { }

                    return (name, image);
                }
            }
        }

        public static (ulong,string)[] LoadAnswers(ulong questionId)
        {
            using(var query = new Query())
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

        public static byte LoadSumPoints(ulong[] answerIds)
        {
            string stringVerification = string.Empty;
            for(var i = 0; i < answerIds.Length; i++)
            {
                stringVerification += answerIds[i];
                if(i + 1 < answerIds.Length)
                {
                    stringVerification += ",";
                }
            }

            using(Query query = new Query())
            {
                object result = query.ExecuteScalar("SELECT SUM(Points) FROM Answer WHERE ID IN (" + stringVerification + ")");
                return Convert.ToByte(result);
            }
        }

        public static void WriteQuestions(int testID, int questionType, string question, byte[] picture, List<string> answers, List<short> trueAnswers)
        {
            ulong questionID = 0;
            using(var query = new Query(CommandType.StoredProcedure))
            {
                query.AddParameter("@TestID", DbType.Int32, testID);
                query.AddParameter("@description", DbType.String, question);
                query.AddParameter("@type", DbType.Int16, questionType);
                query.AddParameter("@picture", DbType.Binary, picture);
                questionID = Convert.ToUInt64(query.ExecuteScalar("AddQuestion"));
            }
            using(var query = new Query())
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

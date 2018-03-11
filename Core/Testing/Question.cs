using System;
using System.Collections.Generic;
using System.Drawing;

namespace Core.Testing
{
    using Query;
    using Common;
    using System.IO;

    public class Question : Entity
    {
        private Image _image;
        public ChildrenList Answers;

        public Question(ulong questionID)
        {
            using( var query = new Query() )
            {
                var reader = query.ReadData("SELECT Description,Picture FROM Question WHERE ID = " + questionID);
                reader.Read();
                _name = Convert.ToString(reader["Description"]);
                byte[] buf;
                try
                {
                    buf = Convert.FromBase64String(Convert.ToBase64String(( (byte[]) reader["Picture"] )));
                    _image = Image.FromStream(new MemoryStream(buf));
                }
                catch
                {
                    _image = null;
                }
            }
            _id = questionID;
            LoadAnswers();
        }

        private void LoadAnswers()
        {
            Answers = new ChildrenList();
            using( var query = new Query() )
            {
                var reader = query.ReadData("SELECT Id,Description FROM Answer WHERE QuestionID = " + _id);
                while( reader.Read() )
                {
                    string answerName = Convert.ToString(reader["Description"]);
                    ulong answerId = Convert.ToUInt64(reader["ID"]);
                    Answers.Add(new Answer(answerId , answerName));
                }
            }
        }

        public Image GetImage()
        {
            if( _image != null )
                return _image;
            return null;
        }


        public static byte Verify(ulong[] answersID)
        {
            string stringVerification = string.Empty;
            for( var i = 0 ; i < answersID.Length ; i++ )
            {
                stringVerification += answersID[i];
                if( i + 1 < answersID.Length )
                {
                    stringVerification += ",";
                }
            }

            var query = new Query();
            var result = query.ExecuteScalar("SELECT SUM(Points) FROM Answer WHERE ID IN (" + stringVerification + ")");
            return Convert.ToByte(result);
        }

        static private byte[] ConvertImageToBase64(string imagePath)
        {
            Image image = Image.FromFile(imagePath);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream , System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        static private void WriteWriteQuestionToDatabase(int testID , int questionType , string question , byte[] picture , List<string> answers , List<short> trueAnswers)
        {
            ulong questionID = 0;
            using( var query = new Query(System.Data.CommandType.StoredProcedure) )
            {


                query.AddParameter("@TestID" , System.Data.SqlDbType.Int , testID);
                query.AddParameter("@description" , System.Data.SqlDbType.NVarChar , question);
                query.AddParameter("@type" , System.Data.SqlDbType.SmallInt , questionType);
                query.AddParameter("@picture" , System.Data.SqlDbType.Image , picture);
                questionID = Convert.ToUInt64(query.ExecuteScalar("AddQuestion"));
            }
            using( var query = new Query() )
            {
                for( var i = 0 ; i < answers.Count ; i++ )
                {
                    short points = 0;
                    for( var j = 0 ; j < trueAnswers.Count ; j++ )
                    {
                        if( i + 1 == trueAnswers[j] )
                        {
                            if( questionType == 0 )
                            {
                                if( j == 0 )
                                {
                                    points = 1;
                                }
                            }
                            else if( questionType == 1 )
                            {
                                if(j == 0 || j==1)
                                {
                                    points = 5;
                                }
                            }
                            else if( questionType == 2 )
                            {
                                if( j == 0 )
                                {
                                    points = 20;
                                }
                                else if( j == 1 )
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

        static public void ParseQuestionDocument(string filePath)
        {
            string[] file = File.ReadAllLines(filePath , System.Text.Encoding.Default);
            filePath = filePath + ".txt";
            string question = string.Empty;
            byte[] picture = null;

            List<string> answers = new List<string>();
            List<short> trueAnswers = new List<short>();

            for( var l = 0 ; l < file.Length - 1 ; l++ )
            {
                int currentAnswer;
                while( l != file.Length || !int.TryParse(file[l][0].ToString() , out currentAnswer) ||  file[l].Contains("Вопрос"))
                {
                    answers.Clear();
                    trueAnswers.Clear();
                    question = file[l];
                    question = question.Remove(0 , "вопрос".Length + 1);
                    while(question[0] != 32 )
                    {
                        question = question.Remove(0 , 1);
                    }
                    question = question.Remove(0 , 1);
                    int index = 0;
                    currentAnswer = 0;
                    l++;
                    var currentLine = file[l];

                    if( int.TryParse(currentLine[0].ToString() , out currentAnswer) )
                    {
                        answers.Add("");
                        do
                        {
                            answers[answers.Count - 1] += currentLine + " ";
                            l++;
                            currentLine = file[l];
                            if( int.TryParse(currentLine[0].ToString() , out currentAnswer) )
                            {
                                answers.Add("");
                            }
                        } while( !currentLine.Contains("ОТВЕТ") );
                        if( currentLine.ToLower().Contains("вложение") )
                        {
                            string imagePath = currentLine.Remove(0 , "вложение".Length);
                            picture = ConvertImageToBase64(imagePath);
                            currentLine = file[l];
                            l++;
                        }
                        while( currentLine.Contains("ОТВЕТ") )
                        {
                            currentLine = currentLine.Trim();
                            if(currentLine[currentLine.Length-1].ToString() == "0")
                            {
                                throw new Exception("Ошибка");
                            }
                            trueAnswers.Add(Convert.ToInt16(currentLine[currentLine.Length - 1].ToString()));

                            l++;
                            index++;
                            if(l >= file.Length )
                            {
                                break;
                            }
                            currentLine = file[l];
                        };
                    }
                    bool isParseOK = true;
                    int maxString = 3999;
                    if(question.Length > maxString )
                    {
                        isParseOK = false;
                    }
                    for(var i = 0 ;i<answers.Count ;i++ )
                    {
                        if(answers[i].Length > maxString )
                        {
                            isParseOK = false;
                            break;
                        }
                    }
                    if( isParseOK )
                    {
                       WriteWriteQuestionToDatabase(25,(int)ExerciseType.themen,question,picture,answers,trueAnswers);
                    }
                    else
                    {

                        File.AppendAllText(filePath , "Вопрос: " + question + "\f" , System.Text.Encoding.Default);
                        File.AppendAllLines(filePath , answers , System.Text.Encoding.Default);
                        foreach( var trueAnswer in trueAnswers )
                        {
                            File.AppendAllText(filePath , "Ответ -" + trueAnswer + "\f" , System.Text.Encoding.Default);
                        }
                        File.AppendAllText(filePath , "\f" , System.Text.Encoding.Default);
                    }
                }
            }
        }
    }
}


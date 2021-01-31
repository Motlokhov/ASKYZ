using System;
using System.Collections.Generic;
using System.Drawing;
using Database;
using CoreLib.Common;
using System.IO;
using System.Data;
using Database.Result;
using System.Linq;

namespace CoreLib.Testing
{
    public class Question : Entity
    {
        private Image _image;
        public ChildrenList<Answer> Answers = new ChildrenList<Answer>();


        public Question(ulong questionID)
        {
            (string description, Image image) question = QueryResult.LoadQuestion(questionID);
            _name = question.description;
            _image = question.image;
            _id = questionID;
            LoadAnswers();
        }

        private void LoadAnswers()
        {
            (ulong, string)[] loadedAnswers = QueryResult.LoadAnswers(_id);
            Answers.AddRange(loadedAnswers.Select(a => new Answer(a.Item1, a.Item2)));
        }

        public Image GetImage()
        {
            return _image;
        }

        static private byte[] ConvertImageToBase64(string imagePath)
        {
            Image image = Image.FromFile(imagePath);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        static private void WriteQuestionToDatabase(int testID, int questionType, string question, byte[] picture, List<string> answers, List<short> trueAnswers)
        {
            ulong questionID = 0;
            using( var query = new Query(CommandType.StoredProcedure) )
            {
                query.AddParameter("@TestID", DbType.Int32, testID);
                query.AddParameter("@description", DbType.String, question);
                query.AddParameter("@type", DbType.Int16, questionType);
                query.AddParameter("@picture", DbType.Binary, picture);
                questionID = Convert.ToUInt64(query.ExecuteScalar("AddQuestion"));
            }
            using( var query = new Query() )
            {
                for( var i = 0; i < answers.Count; i++ )
                {
                    short points = 0;
                    for( var j = 0; j < trueAnswers.Count; j++ )
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
                                if( j == 0 )
                                {
                                    points = 10;
                                }
                                else if( j == 1 )
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
            List<string> questions = new List<string>();
            string[] file = File.ReadAllLines(filePath, System.Text.Encoding.Default);
            string question = string.Empty;
            byte[] picture = null;

            List<string> answers = new List<string>();
            List<short> trueAnswers = new List<short>();

            for( var l = 0; l < file.Length - 1; l++ )
            {
                int currentAnswer;
                while( l < file.Length - 1 )
                {
                    if( !file[l].Contains("Вопрос") )
                    {
                        l++;
                        continue;
                    }

                    question = file[l];
                    question = question.Remove(0, "вопрос".Length + 1);
                    while( question[0] != 32 )
                    {
                        question = question.Remove(0, 1);
                    }
                    question = question.Remove(0, 1);
                    int index = 0;
                    currentAnswer = 0;
                    l++;
                    var currentLine = file[l];

                    if( int.TryParse(currentLine[0].ToString(), out currentAnswer) )
                    {
                        answers.Add("");
                        do
                        {
                            answers[answers.Count - 1] += currentLine + " ";
                            l++;
                            currentLine = file[l];
                            if( int.TryParse(currentLine[0].ToString(), out currentAnswer) )
                            {
                                answers.Add("");
                            }
                            if( currentLine.ToLower().Contains("вложение") )
                            {
                                break;
                            }
                        } while( !currentLine.Contains("ОТВЕТ") );
                        if( currentLine.ToLower().Contains("вложение") )
                        {
                            string imagePath = currentLine.Remove(0, "вложение".Length);
                            picture = ConvertImageToBase64(imagePath);
                            l++;
                            currentLine = file[l];

                        }
                        while( currentLine.Contains("ОТВЕТ") )
                        {
                            currentLine = currentLine.Trim();
                            if( currentLine[currentLine.Length - 1].ToString() == "0" )
                            {
                                throw new Exception("Ошибка");
                            }
                            trueAnswers.Add(Convert.ToInt16(currentLine[currentLine.Length - 1].ToString()));

                            l++;
                            index++;
                            if( l >= file.Length )
                            {
                                break;
                            }
                            currentLine = file[l];
                        };
                    }

                    if( answers.Count != 4 | trueAnswers.Count != 1 )
                    {
                        throw new Exception();
                    }
                    if( picture != null )
                    {
                        //throw new Exception();
                    }

                    questions.Add(question);
                    //WriteQuestionToDatabase(25,(int)ExerciseType.common,question,picture,answers,trueAnswers);
                    answers.Clear();
                    trueAnswers.Clear();
                    picture = null;
                }
            }
        }
    }
}


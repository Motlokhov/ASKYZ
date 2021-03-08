using System;
using System.Collections.Generic;
using System.Drawing;
using CoreLib.Common;
using System.IO;
using System.Data;
using Database.Result;
using System.Linq;

namespace CoreLib.Testing
{
    public class Question : Entity
    {
        private readonly QueryResult _queryResult;
        private readonly Image _image;

        public ChildrenList<Answer> Answers = new ChildrenList<Answer>();

        public Question(QueryResult queryResult, ulong questionID)
        {
            _queryResult = queryResult;
            (string description, Image image)? question = _queryResult.LoadQuestion(questionID);

            if(!question.HasValue)
                throw new InvalidDataException($"Question {questionID} is not exists. Class {nameof(Question)}");

            _name = question.Value.description;
            _image = question.Value.image;
            _id = questionID;
            LoadAnswers();
        }

        private void LoadAnswers()
        {
            (ulong id, string description)[] loadedAnswers = _queryResult.LoadAnswers(_id);
            Answers.AddRange(loadedAnswers.Select(a => new Answer(a.id, a.description)));
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

        //ToDo unusable
        static public void ParseQuestionDocument(string filePath)
        {
            List<string> questions = new List<string>();
            string[] file = File.ReadAllLines(filePath, System.Text.Encoding.Default);
            byte[] picture = null;

            List<string> answers = new List<string>();
            List<short> trueAnswers = new List<short>();

            for( var l = 0; l < file.Length - 1; l++ )
            {
                while( l < file.Length - 1 )
                {
                    if( !file[l].Contains("Вопрос") )
                    {
                        l++;
                        continue;
                    }

                    string question = file[l];
                    question = question.Remove(0, "вопрос".Length + 1);
                    while( question[0] != 32 )
                    {
                        question = question.Remove(0, 1);
                    }
                    question = question.Remove(0, 1);
                    int index = 0;
                    l++;
                    var currentLine = file[l];

                    if( int.TryParse(currentLine[0].ToString(), out _) )
                    {
                        answers.Add("");
                        do
                        {
                            answers[answers.Count - 1] += currentLine + " ";
                            l++;
                            currentLine = file[l];
                            if( int.TryParse(currentLine[0].ToString(), out _) )
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


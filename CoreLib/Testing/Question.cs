using System;
using System.Collections.Generic;
using System.Drawing;
using CoreLib.Common;
using System.IO;
using System.Data;
using System.Linq;
using SystemVerifyKnowledge.Common.Interface;

namespace CoreLib.Testing
{
    public class Question : Entity
    {
        private readonly IQueryResult _queryResult;
        private readonly Image _image;

        public ChildrenList<Answer> Answers = new ChildrenList<Answer>();

        public Question(IQueryResult queryResult, ulong questionID)
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
    }
}


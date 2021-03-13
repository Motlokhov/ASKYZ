using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using CoreLib.Testing;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
using Xunit;

namespace SystemVerifyKnowledge.CoreTest
{
    public class Question_Test
    {
        [Fact]
        public void When_QueryResultHasResult_Then_QuestionLoadCorrect_And_QueryResultIsUsed()
        {
            //Arrange
            const string excpectedDescription = "expected this";
            Image excpectedImage = Image.FromFile("testImage.jpg");
            const ulong expectedQuestionId = 2;
            (ulong id, string name)[] expectedAnswers = new (ulong, string)[]
            {
                (2,"answer2"),
                (3, "answer3"),
                (4, "answer4"),
                (5, "answer5")
            };

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
                .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
                .Returns((excpectedDescription, Image.FromFile("testImage.jpg")))
                .Verifiable();

            mockQueryResult
                .Setup(_ => _.LoadAnswers(It.IsAny<ulong>()))
                .Returns(expectedAnswers);

            //Act
            Question question = new Question(mockQueryResult.Object, expectedQuestionId);

            //Assert
            mockQueryResult.Verify(_ => _.LoadQuestion(expectedQuestionId), Times.Once);
            mockQueryResult.Verify(_ => _.LoadAnswers(expectedQuestionId), Times.Once);

            Assert.Equal(question.Id, expectedQuestionId);
            Assert.Equal(question.Name, excpectedDescription);;

            Image questionImage = question.GetImage();
            Assert.NotSame(excpectedImage, questionImage);
            Assert.Equal(excpectedImage.Width, questionImage.Width);
            Assert.Equal(excpectedImage.Height, questionImage.Height);
            Assert.Equal(excpectedImage.Size, questionImage.Size);
            Assert.Equal(excpectedImage.HorizontalResolution, questionImage.HorizontalResolution);
            Assert.Equal(excpectedImage.VerticalResolution, questionImage.VerticalResolution);
            Assert.Equal(excpectedImage.FrameDimensionsList, questionImage.FrameDimensionsList);
            Assert.Equal(excpectedImage.PhysicalDimension, questionImage.PhysicalDimension);
            Assert.Equal(excpectedImage.RawFormat.Guid, questionImage.RawFormat.Guid);

            Assert.NotSame(question.Answers, expectedAnswers);
            Assert.Equal(expectedAnswers, question.Answers.Select(_ => (_.Id, _.Name)).ToArray());
        }

        [Fact]
        public void When_LoadQuestionHasNoResult_Then_InvalidDataException()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
                .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
                .Returns(() => null);

            const ulong questionId = 0;

            //Act and Assert
            Assert.Throws<InvalidDataException>(() => new Question(mockQueryResult.Object, questionId));
        }
    }
}

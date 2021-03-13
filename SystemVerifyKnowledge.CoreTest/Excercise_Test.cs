using System;
using System.Collections.Generic;
using System.Text;
using CoreLib.Testing;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
using Xunit;

namespace SystemVerifyKnowledge.CoreTest
{
    public class Excercise_Test
    {
        public class FakeExcercise : Exercise
        {
            public FakeExcercise(IQueryResult queryResult, ulong questionCount, byte requiredNumberQuestoins) : base(queryResult)
            {
                for(ulong i = 0; i < questionCount; i++)
                {
                    Questions.Add(new Question(queryResult, i + 1));
                }

                SetRequiredNumberQuestions(requiredNumberQuestoins);
            }
        }

        [Fact]
        public void FaceExcerciseSelfTest()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int questionCount = 3;
            const byte requeredQuestionNumber = 4;

            //Act
            Exercise exercise = new FakeExcercise(mockQueryResult.Object, questionCount, requeredQuestionNumber);

            //Assert
            Assert.Equal(exercise.RequiredNumberQuestions, requeredQuestionNumber);
            Assert.Equal(exercise.Questions.Count, questionCount);
        }

        [Fact]
        public void When_QuestionCountLargerThanRequred_Then_QuestionCountEqual_Requred()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int questionCount = 10;
            const byte requeredQuestionNumber = 3;

            Exercise exercise = new FakeExcercise(mockQueryResult.Object, questionCount, requeredQuestionNumber);

            //Act
            exercise.DeleteQuestions();

            //Assert
            Assert.Equal(exercise.Questions.Count, requeredQuestionNumber);
        }

        [Fact]
        public void When_QuestionCountLesserThanRequred_Then_ArgumentOutOfRangeException()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int questionCount = 4;
            const byte requeredQuestionNumber = 6;

            Exercise exercise = new FakeExcercise(mockQueryResult.Object, questionCount, requeredQuestionNumber);

            //Act
            Assert.Throws<ArgumentOutOfRangeException>(() => exercise.DeleteQuestions());
        }
    }
}

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
        public class FakeExcercisePublicFunctoinTestClass : Exercise
        {
            public FakeExcercisePublicFunctoinTestClass(IQueryResult queryResult, ulong questionCount, byte requiredNumberQuestoins) : this(queryResult, questionCount)
            {
                SetRequiredNumberQuestions(requiredNumberQuestoins);
            }

            public FakeExcercisePublicFunctoinTestClass(IQueryResult queryResult, ulong questionCount) : base(queryResult)
            {
                for(ulong i = 0; i < questionCount; i++)
                {
                    Questions.Add(new Question(queryResult, i + 1));
                }
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
            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, questionCount, requeredQuestionNumber);

            //Assert
            Assert.Equal(exercise.RequiredNumberQuestions, requeredQuestionNumber);
            Assert.Equal(exercise.Questions.Count, questionCount);
        }

        [Theory]
        [InlineData(10,3)]
        [InlineData(4,4)]
        public void WhenDeletingQuestionsEndnessEqualRequaredCount(ulong initialCount, byte requeredCount)
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, initialCount, requeredCount);

            //Act
            exercise.DeleteQuestions();

            //Assert
            Assert.Equal(exercise.Questions.Count, requeredCount);
        }

        [Fact]
        public void When_DeleteQuestionAndQuestionCountLesserThanRequred_Then_ArgumentOutOfRangeException()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int questionCount = 4;
            const byte requeredQuestionNumber = 6;

            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, questionCount, requeredQuestionNumber);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => exercise.DeleteQuestions());
        }

        [Theory]
        [InlineData(0,false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        public void When_NextQuestionExists_Then_TrueOtherwiseFalse(ulong questionCount, bool expectedResult)
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, questionCount);

            //Act and Assert
            Assert.Equal(expectedResult, exercise.NextQuestion());
        }
    }
}

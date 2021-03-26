using System;
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
            public FakeExcercisePublicFunctoinTestClass(IQueryResult queryResult, ulong questionCount, byte requiredNumberQuestoins) 
                : this(queryResult, questionCount)
            {
                RequiredNumberQuestions = requiredNumberQuestoins;
            }

            public FakeExcercisePublicFunctoinTestClass(IQueryResult queryResult, ulong questionCount) : base(queryResult)
            {
                for(ulong i = 0; i < questionCount; i++)
                {
                    Questions.Add(new Question(queryResult, i + 1));
                }
            }

            public new void SwapQuestions() => base.SwapQuestions();

        }

        [Fact]
        public void FaceExcerciseSelfTest()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int initialCount = 3;
            const byte requiredCount = 4;

            //Act
            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, initialCount, requiredCount);

            //Assert
            Assert.Equal(exercise.RequiredNumberQuestions, requiredCount);
            Assert.Equal(exercise.Questions.Count, initialCount);
        }

        [Theory]
        [InlineData(10,3)]
        [InlineData(4,4)]
        public void WhenDeletingQuestionsEndnessEqualRequaredCount(ulong initialCount, byte requiredCount)
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, initialCount, requiredCount);

            //Act
            exercise.DeleteQuestions();

            //Assert
            Assert.Equal(exercise.Questions.Count, requiredCount);
        }

        [Fact]
        public void When_DeleteQuestionAndQuestionCountLesserThanRequred_Then_ArgumentOutOfRangeException()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int initialCount = 4;
            const byte requiredCount = 6;

            Exercise exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, initialCount, requiredCount);

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

        [Fact]
        public void When_SwapQuestions_Then_InitialSequenceNotEqualResultSequence()
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            mockQueryResult
            .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
            .Returns((null, null));

            const int questionCount = 1000;

            FakeExcercisePublicFunctoinTestClass exercise = new FakeExcercisePublicFunctoinTestClass(mockQueryResult.Object, questionCount);

            Question[] initialSequence = new Question[exercise.Questions.Count];
            exercise.Questions.CopyTo(initialSequence);

            //Act
            exercise.SwapQuestions();

            //Assert
            Assert.NotEqual(exercise.Questions.ToArray(), initialSequence);
        }
    }
}

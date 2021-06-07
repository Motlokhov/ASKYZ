using System;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;
using SystemVerifyKnowledge.CoreLib.Model;
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

        private void SetupQueryResult(Mock<IQueryResult> mockQueryResult, int exerciseType)
        {
            mockQueryResult
                .Setup(_ => _.LoadQuestionIds(It.IsAny<ulong>(), exerciseType))
                .Returns(new ulong[100]);

            mockQueryResult
                .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
                .Returns((null, null));
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

        //Each heir type has defined set of properties
        [Theory]
        [InlineData(typeof(CommonExercise), 1, ExerciseType.common, 50)]
        [InlineData(typeof(ThemenExercise), 10, ExerciseType.themen, 3)]
        [InlineData(typeof(PracticalExercise), 20, ExerciseType.practical, 2)]
        public void CreateExerciseTypeTest(Type type, int correctAnswerNumberPoints, ExerciseType exerciseType, int requiredQuestionCount)
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, (int)exerciseType);

            const ulong testId = 300;

            //Act
            Exercise exercise = (Exercise)Activator.CreateInstance(type, mockQueryResult.Object, testId);

            //Assert
            Assert.Equal(correctAnswerNumberPoints, exercise.CorrectAnswerNumberPoints);
            Assert.Equal(exerciseType, exercise.Type);
            Assert.Equal(requiredQuestionCount, exercise.RequiredNumberQuestions);
        }

        [Theory]
        [InlineData(typeof(CommonExercise), 1, ExerciseType.common, true)]
        [InlineData(typeof(ThemenExercise), 10, ExerciseType.themen, true)]
        [InlineData(typeof(PracticalExercise), 20, ExerciseType.practical, true)]
        [InlineData(typeof(CommonExercise), 100, ExerciseType.common, false)]
        [InlineData(typeof(ThemenExercise), 100, ExerciseType.themen, false)]
        [InlineData(typeof(PracticalExercise), 100, ExerciseType.practical, false)]
        public void When_CorrectAnswerNumberPointsEqualPoints_Then_True_OtherwiseFalse(Type type, byte points, ExerciseType exerciseType, bool expectedResult)
        {
            //Arrange
            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, (int)exerciseType);

            const ulong testId = 300;

            //Act
            Exercise exercise = (Exercise)Activator.CreateInstance(type, mockQueryResult.Object, testId);

            //Assert
            Assert.Equal(expectedResult, exercise.IsAnswerCorrect(points));
        }
    }
}

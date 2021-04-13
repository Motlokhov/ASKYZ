using System;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Common;
using SystemVerifyKnowledge.CoreLib.Model;
using Xunit;

namespace SystemVerifyKnowledge.CoreTest
{
    public class ExerciseSet_Test
    {
        private void SetupQueryResult(Mock<IQueryResult> mockQueryResult, int questionCount, ulong testId)
        {
            mockQueryResult
                .Setup(_ => _.LoadQuestionIds(It.IsAny<ulong>(), It.IsAny<int>()))
                .Returns(new ulong[questionCount]);

            mockQueryResult
                .Setup(_ => _.LoadQuestion(It.IsAny<ulong>()))
                .Returns((null, null));

            mockQueryResult
                .Setup(_ => _.LoadTestIdByProgramGroupIdAndType(It.IsAny<ulong>(), It.IsAny<int>()))
                .Returns(testId);
        }

        // If Exercise type grand then RequiredQuestionCount equal questionCount
        [Theory]
        [InlineData(typeof(GrandExerciseSet), ExerciseSetType.Grand)]
        [InlineData(typeof(TrainingExerciseSet), ExerciseSetType.Training)]
        public void CreateExerciseSetTypeTest(Type type, ExerciseSetType exerciseSetType)
        {
            //Arrange

            int questionFromDBCount = 100;
            ulong testId = 500;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult,questionFromDBCount, testId);

            ulong programGroupId = 10;

            //Act
            ExerciseSet exerciseSet = (ExerciseSet)Activator.CreateInstance(type, mockQueryResult.Object, programGroupId);

            CommonExercise commonExercise = (CommonExercise)exerciseSet[0];
            ThemenExercise themenExercise = (ThemenExercise)exerciseSet[1];
            PracticalExercise practicalExercise = (PracticalExercise)exerciseSet[2];

            //Assert
            Assert.Equal(testId, exerciseSet.Id);
            Assert.Equal(exerciseSetType, exerciseSet.Type);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : commonExercise.RequiredNumberQuestions, commonExercise.Questions.Count);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : themenExercise.RequiredNumberQuestions, themenExercise.Questions.Count);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : practicalExercise.RequiredNumberQuestions, practicalExercise.Questions.Count);
        }

        [Theory]
        [InlineData(typeof(GrandExerciseSet), 50, 54)]
        [InlineData(typeof(TrainingExerciseSet), 2, 5)]
        [InlineData(typeof(TrainingExerciseSet), 1, 2)]
        [InlineData(typeof(TrainingExerciseSet), 0, 2)]
        public void When_HasNextQuestion_Then_True_Otherwise_False(Type type, int questionFromDBCount, int iterationUntilFalse)
        {
            //Arrange
            ulong testId = 500;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, questionFromDBCount, testId);

            ulong programGroupId = 10;

            //Act
            ExerciseSet exerciseSet = (ExerciseSet)Activator.CreateInstance(type, mockQueryResult.Object, programGroupId);
            int actualIterationCount = 0;

            while(exerciseSet.NextQuestion())
                actualIterationCount++;

            Assert.Equal(iterationUntilFalse, actualIterationCount);
        }

        [Theory]
        [InlineData(typeof(GrandExerciseSet))]
        [InlineData(typeof(TrainingExerciseSet))]
        public void ExerciseSetHasExactlyThreeExcercises(Type type)
        {
            //Arrange
            ulong testId = 500;
            int questionFromDBCount = 50;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, questionFromDBCount, testId);

            ulong programGroupId = 10;

            //Act
            ExerciseSet exerciseSet = (ExerciseSet)Activator.CreateInstance(type, mockQueryResult.Object, programGroupId);

            //Assert
            Assert.True(exerciseSet.NextExercise());
            Assert.True(exerciseSet.NextExercise());
            Assert.False(exerciseSet.NextExercise());

            Assert.True(exerciseSet.PreviousExercise());
            Assert.True(exerciseSet.PreviousExercise());
            Assert.False(exerciseSet.PreviousExercise());
        }

        [Theory]
        [InlineData(typeof(GrandExerciseSet))]
        public void When_PassCurrentQuestion_Then_QuestionGoToEndArray(Type type)
        {
            //Arrange
            ulong testId = 500;
            int questionFromDBCount = 50;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, questionFromDBCount, testId);

            ulong programGroupId = 10;

            //Act
            ExerciseSet exerciseSet = (ExerciseSet)Activator.CreateInstance(type, mockQueryResult.Object, programGroupId);

            Question questionBeforePass = exerciseSet.Exercise.Question;

            exerciseSet.PassQuestion();

            Question questionAfterPass = exerciseSet.Exercise.Question;


            //Assert
            Assert.Equal(questionAfterPass, exerciseSet.Exercise.Questions[0]);
            Assert.Equal(questionBeforePass, exerciseSet.Exercise.Questions[exerciseSet.Exercise.Questions.Count - 1]);
            Assert.NotSame(questionBeforePass, questionAfterPass);
        }
    }
}

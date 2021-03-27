using System;
using CoreLib.Common;
using CoreLib.Model;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
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

            CommonExercise commonExercise = (CommonExercise)exerciseSet.Exercises[0];
            ThemenExercise themenExercise = (ThemenExercise)exerciseSet.Exercises[1];
            PracticalExercise practicalExercise = (PracticalExercise)exerciseSet.Exercises[2];

            //Assert
            Assert.Equal(testId, exerciseSet.Id);
            Assert.Equal(exerciseSetType, exerciseSet.Type);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : commonExercise.RequiredNumberQuestions, commonExercise.Questions.Count);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : themenExercise.RequiredNumberQuestions, themenExercise.Questions.Count);
            Assert.Equal(exerciseSet.Type == ExerciseSetType.Training ? questionFromDBCount : practicalExercise.RequiredNumberQuestions, practicalExercise.Questions.Count);
        }
    }
}

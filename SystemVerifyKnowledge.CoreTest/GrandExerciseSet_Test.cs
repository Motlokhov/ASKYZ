using Moq;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Model;
using Xunit;

namespace SystemVerifyKnowledge.CoreTest
{
    public class GrandExerciseSet_Test
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

        [Theory]
        [InlineData(20,0,0,1)]
        [InlineData(10,0,1,0)]
        [InlineData(1,1,0,0)]
        public void When_ExerciseMaxPointsEqualAnswersPoint_Then_AddTrueAnswersCount(byte points, int commonTrueAnswersCount, int themenTrueAnswersCount, int practicalTrueAnswersCount)
        {
            //Arrange
            const ulong testId = 500;
            const int questionFromDBCount = 50;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, questionFromDBCount, testId);

            mockQueryResult.Setup(_ => _.LoadSumPoints(It.IsAny<ulong[]>()))
                            .Returns(points);

            const ulong programGroupId = 10;

            //Act
            GrandExerciseSet grandExerciseSet = new GrandExerciseSet(mockQueryResult.Object, programGroupId);
            grandExerciseSet.IsNextQuestionAvailable(new ulong[] { 1, 2, 3, 4 });
            grandExerciseSet.NextExercise();
            grandExerciseSet.IsNextQuestionAvailable(new ulong[] { 1, 2, 3, 4 });
            grandExerciseSet.NextExercise();
            grandExerciseSet.IsNextQuestionAvailable(new ulong[] { 1, 2, 3, 4 });

            //Assert
            Assert.Equal(commonTrueAnswersCount, grandExerciseSet[0].Result.TrueAnswers);
            Assert.Equal(themenTrueAnswersCount, grandExerciseSet[1].Result.TrueAnswers);
            Assert.Equal(practicalTrueAnswersCount, grandExerciseSet[2].Result.TrueAnswers);
        }
    }
}

using System;
using Moq;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib;
using SystemVerifyKnowledge.CoreLib.Common;
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

        [Fact]
        public void When_TestEnd_Then_SaveResult()
        {
            //Arrange
            const ulong testId = 500;
            const int questionFromDBCount = 50;
            const byte programGroupId = 10;
            const ulong userId = 2;

            Mock<IQueryResult> mockQueryResult = new Mock<IQueryResult>();
            SetupQueryResult(mockQueryResult, questionFromDBCount, testId);

            mockQueryResult.Setup(_ => _.LoadUserById(It.IsAny<ulong>()))
                            .Returns((null, null, null, programGroupId, DateTime.Now, DateTime.Now, 0, 0));

            mockQueryResult.Setup(_ => _.GetUserId(It.IsAny<string>(), It.IsAny<string>()))
                            .Returns(userId);

            Core.CheckPassword(mockQueryResult.Object, new UserSignIn() { Login = userId.ToString(), Password = "password" });

            byte commonTrueAnswersCount = 30;
            byte commonTrueAnswersPoints = 30;
            byte themenTrueAnswersCount = 1;
            byte themenTrueAnswersPoints = 10;
            byte practicalTrueAnswersCount = 2;
            byte practicalTrueAnswersPoints = 40;

            GrandExerciseSet grandExerciseSet = Core.Exercises as GrandExerciseSet;
            grandExerciseSet[0].Result.TrueAnswers = commonTrueAnswersCount;
            grandExerciseSet[0].Result.Points = commonTrueAnswersPoints;
            grandExerciseSet[1].Result.TrueAnswers = themenTrueAnswersCount;
            grandExerciseSet[1].Result.Points = themenTrueAnswersPoints;
            grandExerciseSet[2].Result.TrueAnswers = practicalTrueAnswersCount;
            grandExerciseSet[2].Result.Points = practicalTrueAnswersPoints;

            byte commonExpectedFalseAnswersCount = 20;
            byte thementExpectedFalseAnswersCount = 2;
            byte practicalFalseAnswersCount = 0;

            //Act
            grandExerciseSet.TestEnd();

            //Assert
            (int, byte, byte, byte)[] expectedWriteResult = new (int, byte, byte, byte)[]
            {
                ((int)ExerciseType.common, commonTrueAnswersPoints, commonTrueAnswersCount, commonExpectedFalseAnswersCount),
                ((int)ExerciseType.themen, themenTrueAnswersPoints, themenTrueAnswersCount, thementExpectedFalseAnswersCount),
                ((int)ExerciseType.practical, practicalTrueAnswersPoints, practicalTrueAnswersCount, practicalFalseAnswersCount)
            };

            mockQueryResult.Verify(_ => _.WriteTestResults(userId, programGroupId, expectedWriteResult));
        }
    }
}

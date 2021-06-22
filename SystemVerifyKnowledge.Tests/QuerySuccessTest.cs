using Database.Result;
using System;
using System.IO;
using SystemVerifyKnowledge.Common;
using Xunit;

namespace SystemVerifyKnowledge.Tests
{
    [Collection(nameof(SystemVerifyKnowledgeFixture))]
    public class QuerySuccess
    {
        private readonly SystemVerifyKnowledgeFixture _fixture;
        private readonly QueryResult _queryResult;

        public QuerySuccess(SystemVerifyKnowledgeFixture fixture)
        {
            _fixture = fixture;
            _queryResult = new QueryResult(_fixture.Connection);
        }

        [Theory]
        [InlineData(0, null, typeof(ArgumentException))]
        [InlineData(0, "", typeof(ArgumentException))]
        public void TestGetUserIdWrongParameters(ulong id, string password, Type exceptedException)
        {
            Assert.Throws(exceptedException, () => { _queryResult.GetUserId(new SignIn(id, password)); });
        }

        [Fact]
        public void TestGetUserIdNullValue()
        {
            Assert.Null(_queryResult.GetUserId(new SignIn(0, "0")));
        }

        [Fact]
        public void TestFindPasswordNullValue()
        {
            Assert.Null(_queryResult.FindPassword(0, 0));
        }

        [Fact]
        public void TestLoadAllDirectionNotEmptyCollection()
        {
            //Arrange
            const int countDirections = 2;

            //Act
            (byte id, string name)[] directions = _queryResult.LoadAllDirections();

            //Assert
            Assert.Equal(countDirections, directions.Length);
            Assert.Equal(1, directions[0].id);
            Assert.Equal("Росавтодор", directions[0].name);
            Assert.Equal(2, directions[1].id);
            Assert.Equal("Росжелдор", directions[1].name);
        }

        [Fact]
        public void TestLoadAnswersEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadAnswers(0));
        }

        [Fact]
        public void TestLoadDirectionNameNullValue()
        {
            Assert.Null(_queryResult.LoadDirectionName(0));
        }

        [Fact]
        public void TestLoadProgramByProgramGroupIdNullValue()
        {
            Assert.Null(_queryResult.LoadProgramByProgramGroupId(0));
        }

        [Fact]
        public void TestLoadProgramsByDirecionAndTypeEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadProgramsByDirecionAndType(0, 0));
        }

        [Fact]
        public void TestLoadQuestionNullValue()
        {
            Assert.Null(_queryResult.LoadQuestion(0));
        }

        [Fact]
        public void TestLoadQuestionIdsEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadQuestionIds(0, 0));
        }

        [Theory]
        [InlineData(null, typeof(ArgumentException))]
        [InlineData(new ulong[0], typeof(ArgumentException))]
        [InlineData(new ulong[] { 0 }, typeof(InvalidDataException))]
        [InlineData(new ulong[] { 0, 0 }, typeof(InvalidDataException))]
        public void TestLoadSumPointsWithWrongParameters(ulong[] answerIds, Type expectedException)
        {
            Assert.Throws(expectedException, () => { _queryResult.LoadSumPoints(answerIds); });
        }

        [Fact]
        public void TestLoadTestIdByProgramGroupIdAndTypeWithWrondValues()
        {
            Assert.Throws<InvalidDataException>(() => { _queryResult.LoadTestIdByProgramGroupIdAndType(0, 0); });
        }

        [Fact]
        public void TestLoadTestingDatesEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadTestingDates());
        }

        [Fact]
        public void TestLoadTestResultNullValue()
        {
            Assert.Null(_queryResult.LoadTestResult(0, 0));
        }

        [Fact]
        public void TestLoadUserByIdNullValue()
        {
            Assert.Null(_queryResult.LoadUserById(0));
        }

        [Fact]
        public void TestLoadUsersResultByTestingDateEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadUsersResultByTestingDate(DateTime.Now.ToString()));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TestLoadUsersResultByTestingDateArgumentException(string testingDate)
        {
            Assert.Throws<ArgumentException>(() => { _queryResult.LoadUsersResultByTestingDate(testingDate); });
        }

        [Fact]
        public void TestInsertNewUserAllFields()
        {
            const string firstname = "имя";
            const string lastname = "фамилия";
            const string surname = "отчество";
            const ushort passportSerie = 1234;
            const ushort passportNumber = 5678;
            DateTime startDateTest = new DateTime(2021, 2, 23, 15, 05, 06, 0);
            DateTime endDateTest = new DateTime(2021, 2, 23, 19, 07, 09, 0);
            const string password = "pass";
            const ulong programGroupId = 1;

            Assert.True(_queryResult.InsertNewUser(
                                    firstname,
                                    surname,
                                    lastname,
                                    passportSerie,
                                    passportNumber,
                                    startDateTest,
                                    endDateTest,
                                    password,
                                    programGroupId));

            (string surname,
            string firstname,
            string lastname,
            byte programGroupId,
            DateTime dateStartTest,
            DateTime dateEndTest,
            uint passportNumber,
            ushort passportSerie)? user = _queryResult.LoadUserById(12345678);

            Assert.NotNull(user);

            Assert.Equal("Имя", user.Value.firstname);
            Assert.Equal("Фамилия", user.Value.lastname);
            Assert.Equal("Отчество", user.Value.surname);
            Assert.Equal(passportSerie, user.Value.passportSerie);
            Assert.Equal(passportNumber, user.Value.passportNumber);
            Assert.Equal(startDateTest, user.Value.dateStartTest);
            Assert.Equal(endDateTest, user.Value.dateEndTest);
            Assert.Equal(programGroupId, user.Value.programGroupId);
        }
    }
}

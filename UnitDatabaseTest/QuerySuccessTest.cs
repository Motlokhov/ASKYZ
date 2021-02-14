using System;
using System.IO;
using Database.Result;
using Xunit;

namespace DataBaseTest
{
    [Collection(nameof(SystemVerifyKnowledgeFixture))]
    public class QuerySuccess
    {
        private readonly SystemVerifyKnowledgeFixture _fixture;
        private readonly QueryResult _queryResult;

        public QuerySuccess(SystemVerifyKnowledgeFixture fixture)
        {
            _fixture = fixture;
            _queryResult = new QueryResult(_fixture.FunctionConnection);
        }

        [Theory]
        [InlineData(null, "0", typeof(ArgumentException))]
        [InlineData("0", null, typeof(ArgumentException))]
        [InlineData("", "0", typeof(ArgumentException))]
        [InlineData("0", "", typeof(ArgumentException))]
        public void TestGetUserIdWrongParameters(string id, string password, Type exceptedException)
        {
            Assert.Throws(exceptedException, () => { _queryResult.GetUserId(id, password); });
        }

        [Fact]
        public void TestGetUserIdNullValue()
        {
            Assert.Null(_queryResult.GetUserId("0", "0"));
        }

        [Fact]
        public void TestFindPasswordNullValue()
        {
            Assert.Null(_queryResult.FindPassword(0, 0));
        }

        [Fact]
        public void TestLoadAllDirectionEmptyCollection()
        {
            Assert.Empty(_queryResult.LoadAllDirections());
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
        public void TestLoadTestingDates()
        {
            Assert.Empty(_queryResult.LoadTestingDates());
        }

        [Fact]
        public void TestLoadTestResult()
        {
            Assert.Null(_queryResult.LoadTestResult(0, 0));
        }

        [Fact]
        public void TestLoadUserById()
        {
            Assert.Null(_queryResult.LoadUserById(0));
        }

        [Fact]
        public void TestLoadUsersResultByTestingDate()
        {
            Assert.Empty(_queryResult.LoadUsersResultByTestingDate(DateTime.Now.ToString()));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TestLoadUsersResultByTestingDateWithWrongParameters(string testingDate)
        {
            Assert.Throws<ArgumentException>(() => { _queryResult.LoadUsersResultByTestingDate(testingDate); });
        }
    }
}

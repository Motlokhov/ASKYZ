using System;
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
        public void TestGetUserIdWrongParameters(string id, string password,Type exceptedException)
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

    }
}

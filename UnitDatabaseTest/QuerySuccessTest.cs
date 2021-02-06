using System;
using Database.Result;
using Xunit;

namespace DataBaseTest
{
    [Collection(nameof(SystemVerifyKnowledgeFixture))]
    public class QuerySuccess
    {
        private readonly SystemVerifyKnowledgeFixture _fixture;

        public QuerySuccess(SystemVerifyKnowledgeFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(null, "0", typeof(ArgumentException))]
        [InlineData("0", null, typeof(ArgumentException))]
        [InlineData("", "0", typeof(ArgumentException))]
        [InlineData("0", "", typeof(ArgumentException))]
        public void TestGetUserIdWrongParameters(string id, string password,Type exceptedException)
        {
            QueryResult queryResult = new QueryResult(_fixture.FunctionConnection);
            Assert.Throws(exceptedException, () => { queryResult.GetUserId(id, password); });
        }

        [Fact]
        public void TestGetUserIdNullValue()
        {
            QueryResult queryResult = new QueryResult(_fixture.FunctionConnection);
            Assert.Null(queryResult.GetUserId("0", "0"));
        }

        [Fact]
        public void TestFindPasswordNullValue()
        {
            QueryResult queryResult = new QueryResult(_fixture.FunctionConnection);
            Assert.Null(queryResult.FindPassword(0, 0));
        }

        [Fact]
        public void TestLoadAllDirectionEmptyCollection()
        {
            QueryResult queryResult = new QueryResult(_fixture.FunctionConnection);
            Assert.Empty(queryResult.LoadAllDirections());
        }
    }
}

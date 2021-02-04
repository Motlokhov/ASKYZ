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

        [Fact]
        public void Test1()
        {

        }
    }
}

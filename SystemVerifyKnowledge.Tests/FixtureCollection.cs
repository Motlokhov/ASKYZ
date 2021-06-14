using Xunit;

namespace DataBaseTest
{
    [CollectionDefinition(nameof(SystemVerifyKnowledgeFixture))]
    public class FixtureCollection : ICollectionFixture<SystemVerifyKnowledgeFixture>
    {
    }
}

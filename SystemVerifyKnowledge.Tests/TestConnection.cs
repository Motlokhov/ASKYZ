using System.Data.Common;
using System.Data.SqlClient;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Tests
{
    public class TestConnection : IConnection
    {
        private const string _SuperTestDatabaseConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=superTestDatabase;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public DbConnection GetConnection()
        {
            return new SqlConnection(_SuperTestDatabaseConnectionString);
        }
    }
}

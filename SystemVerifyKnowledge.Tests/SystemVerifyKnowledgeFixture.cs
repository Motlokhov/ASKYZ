using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Tests
{
    public class SystemVerifyKnowledgeFixture
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

        public readonly IConnection Connection;

        public SystemVerifyKnowledgeFixture()
        {
            Connection = new TestConnection();
            CreateSuperTestDatabase();
            CreateTables();
           FillMoqDbData();
        }

        private void CreateSuperTestDatabase()
        {
            const string _dropSuperTestDatabaseConnectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=master;
                Integrated Security=True;
                Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";

            using(DbConnection connection = new SqlConnection(_dropSuperTestDatabaseConnectionString))
            {
                connection.Open();
                using(DbCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                    @"DROP DATABASE if exists superTestDatabase
                      Create Database superTestDatabase;";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateTables()
        {
            using(DbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using(DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = File.ReadAllText("CreateTables.sql");
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void FillMoqDbData()
        {
            using(DbConnection connection = Connection.GetConnection())
            {
                connection.Open();
                using(DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = File.ReadAllText("FillTables.sql");
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}

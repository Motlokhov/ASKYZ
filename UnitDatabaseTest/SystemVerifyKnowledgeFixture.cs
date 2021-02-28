using System;
using System.Data.Common;
using System.IO;
using Microsoft.Data.SqlClient;

namespace DataBaseTest
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

        public SqlConnection Connection => new SqlConnection(_SuperTestDatabaseConnectionString);
        public Func<DbConnection> FunctionConnection => new Func<DbConnection>(() => Connection);

        public SystemVerifyKnowledgeFixture()
        {
            CreateSuperTestDatabase();
            CreateTables();
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
            using(DbConnection connection = Connection)
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
    }
}

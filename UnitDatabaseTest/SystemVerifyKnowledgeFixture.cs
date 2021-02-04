using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace DataBaseTest
{
    public class SystemVerifyKnowledgeFixture
    {
        private readonly string _connectionString;

        public SQLiteConnection Connection => new SQLiteConnection(_connectionString);

        public SystemVerifyKnowledgeFixture()
        {
            string localDataBasePath = @"LocalKnowlageVerification.db";
            SQLiteConnection.CreateFile(localDataBasePath);

            _connectionString = new StringBuilder()
                .Append(@"Data Source = ")
                .Append(localDataBasePath)
                .Append(";")
                .Append("Version = 3;")
                .ToString();

            CreateTables();
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

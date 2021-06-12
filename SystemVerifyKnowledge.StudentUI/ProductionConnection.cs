using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using SystemVerifyKnowledge.Common.Interface;

namespace StudentUI
{
    class ProductionConnection : IConnection
    {
        private string _connectionString;

        public ProductionConnection()
        {
            _connectionString = File.ReadAllText("connection.txt");
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

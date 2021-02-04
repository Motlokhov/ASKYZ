using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace Database
{
    public class Query:IDisposable
    {
        public DbConnection Connection { get; private set; }
        private DbCommand _command;

        public Query(CommandType commandType = CommandType.Text)
        {
            Connection = new SqlConnection(File.ReadAllText("connection.txt"));
            Connection.Open();
            _command = Connection.CreateCommand();
            _command.CommandType = commandType;
        }

        public DbDataReader ReadData(string _command_text)
        {
            _command.CommandText = _command_text;
            return _command.ExecuteReader();
        }

        public int ExecuteNonQuery(string commandText)
        {
            _command.CommandText = commandText;
            return _command.ExecuteNonQuery();
        }

        public object ExecuteScalar(string commandText)
        {
            _command.CommandText = commandText;
            return _command.ExecuteScalar();
        }

        private void ConnectionClose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public void AddParameter(string nameparameter ,DbType  typeparameter , object value)
        {
            DbParameter param = _command.CreateParameter();
            param.ParameterName = nameparameter;
            param.DbType = typeparameter;
            param.Value = value;
        }

        public void Dispose()
        {
            ConnectionClose();
        }
    }
}



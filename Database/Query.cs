using System;
using System.Data;
using System.Data.Common;

namespace Database
{
    public class Query:IDisposable
    {
        private readonly DbConnection _connection;// { get; private set; }
        private readonly DbCommand _command;

        public Query(DbConnection connection, CommandType commandType = CommandType.Text)
        {
            _connection = connection;
            _connection.Open();
            _command = _connection.CreateCommand();
            _command.CommandType = commandType;
        }

        public DbTransaction BeginTransaction() => _connection.BeginTransaction();

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
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }

        public void AddParameter(string nameparameter ,DbType  typeparameter , object value)
        {
            DbParameter param = _command.CreateParameter();
            param.ParameterName = nameparameter;
            param.DbType = typeparameter;
            param.Value = value;
            _command.Parameters.Add(param);
        }

        public void Dispose() => ConnectionClose();
    }
}



using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Database
{
    public class Query:IDisposable
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private byte _parameterIndex;
        public Query(CommandType commandType = CommandType.Text)
        {
            string connectionString = File.ReadAllText("connection.txt");
            _command = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = connectionString;
            _command.Connection = _connection;
            _connection.Open();
            _command.CommandType = commandType;
        }

        public SqlDataReader ReadData(string _command_text)
        {
            _command.CommandText = _command_text;
            _reader = _command.ExecuteReader();
            return _reader;
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

        private void ConnectionOpen()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        private void ConnectionClose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public void AddParameter(string nameparameter , SqlDbType typeparameter , object value)
        {
            _command.Parameters.Add(nameparameter , typeparameter);
            _command.Parameters[_parameterIndex].Value = value;
            _parameterIndex += 1;
        }

        public void Dispose()
        {
            ConnectionClose();
        }
    }
}



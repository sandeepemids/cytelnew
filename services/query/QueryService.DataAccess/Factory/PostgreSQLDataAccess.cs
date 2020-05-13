using Npgsql;
using QueryService.DataAccess.Interfaces;
using System.Data;

namespace QueryService.DataAccess.Factory
{
    class PostgreSQLDataAccess : IQueryServiceDBHandler
    {
        private string connectionString { get; set; }

        public PostgreSQLDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CloseConnection(IDbConnection connection)
        {
            var npgSqlonnection = (NpgsqlConnection)connection;
            npgSqlonnection.Close();
            npgSqlonnection.Dispose();
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new NpgsqlDataAdapter((NpgsqlCommand)command);
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new NpgsqlCommand
            {
                CommandText = commandText,
                Connection = (NpgsqlConnection)connection,
                CommandType = commandType
            };
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            NpgsqlCommand npSqlCommand = (NpgsqlCommand)command;
            return npSqlCommand.CreateParameter();
        }
    }
}

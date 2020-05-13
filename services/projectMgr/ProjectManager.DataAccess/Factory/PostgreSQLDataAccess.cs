using Npgsql;
using ProjectManager.DataAccess.Interfaces;
using System.Data;

namespace ProjectManager.DataAccess.Factory
{
    public class PostgreSQLDataAccess : IProjectDBHandler
    {
        private string connectionString { get; set; }

        public PostgreSQLDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            var npgSqlonnection = (NpgsqlConnection)connection;
            npgSqlonnection.Close();
            npgSqlonnection.Dispose();
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

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new NpgsqlDataAdapter((NpgsqlCommand)command);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            NpgsqlCommand npSqlCommand = (NpgsqlCommand)command;
            return npSqlCommand.CreateParameter();
        }
    }
}

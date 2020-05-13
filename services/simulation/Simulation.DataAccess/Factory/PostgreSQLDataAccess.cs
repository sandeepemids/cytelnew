using Npgsql;
using Simulation.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Simulation.DataAccess.Factory
{
    class PostgreSQLDataAccess : ISimulationDBHandler
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

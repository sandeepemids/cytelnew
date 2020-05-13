using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Simulation.DataAccess.Interfaces
{
    interface ISimulationDBHandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);
        IDataAdapter CreateAdapter(IDbCommand command);
        IDbDataParameter CreateParameter(IDbCommand command);
    }
}

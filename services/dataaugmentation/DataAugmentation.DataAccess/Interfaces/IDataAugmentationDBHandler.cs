using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAugmentation.DataAccess.Interfaces
{
   public interface IDataAugmentationDBHandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);
        IDataAdapter CreateAdapter(IDbCommand command);
        IDbDataParameter CreateParameter(IDbCommand command);
    }
}

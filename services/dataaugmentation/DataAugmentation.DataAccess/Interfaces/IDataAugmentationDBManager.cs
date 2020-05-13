using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAugmentation.DataAccess.Interfaces
{
   public interface IDataAugmentationDBManager
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbDataParameter CreateParameter(string name, object value, DbType dbType);
        IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType);
        IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction);
        DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null);
        DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null);
        IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection);
        void Delete(string commandText, CommandType commandType, IDbDataParameter[] parameters = null);
        void Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int lastId);
        long Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out long lastId);
        void InsertWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public void InsertWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters);
        public void Update(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public void UpdateWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public void UpdateWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters);
        public object GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[] parameters = null);

    }
}

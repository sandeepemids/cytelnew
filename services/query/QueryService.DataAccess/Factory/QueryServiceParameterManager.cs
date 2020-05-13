using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace QueryService.DataAccess.Factory
{
    class QueryServiceParameterManager
    {
        public static IDbDataParameter CreateParameter(string name, object value, NpgsqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = CreateNpgSqlParameter(name, value, dbType, direction);
            return parameter;
        }

        public static IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = CreateNpgSqlParameter(name, size, value, dbType, direction);
            return parameter;
        }

        private static IDbDataParameter CreateNpgSqlParameter(string name, object value, NpgsqlDbType dbType, ParameterDirection direction)
        {
            return new NpgsqlParameter
            {
                NpgsqlDbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateNpgSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new NpgsqlParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}

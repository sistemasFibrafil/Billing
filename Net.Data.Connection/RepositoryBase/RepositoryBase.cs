using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Net.Data.Connection
{
    public class RepositoryBase
    {
        public string GetStringValue(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType)
        {
            var result = dynamicParameters == null ? sqlConnection.Query<string>(sql, commandType: commandType).SingleOrDefault() : sqlConnection.Query<string>(sql, param: dynamicParameters, commandType: commandType).SingleOrDefault();
            return result;
        }

        public int GetIntValue(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType)
        {
            var result = dynamicParameters == null ? sqlConnection.Query<int>(sql, commandType: commandType).SingleOrDefault() : sqlConnection.Query<int>(sql, param: dynamicParameters, commandType: commandType).SingleOrDefault();
            return result;
        }

        public decimal GetDecimalValue(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType)
        {
            var result = dynamicParameters == null ? sqlConnection.Query<decimal>(sql, commandType: commandType).SingleOrDefault() : sqlConnection.Query<decimal>(sql, param: dynamicParameters, commandType: commandType).SingleOrDefault();
            return result;
        }
        public T GetData<T>(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType) where T : class
        {
            T result = default(T);
            result = dynamicParameters == null ? sqlConnection.Query<T>(sql, commandType: commandType).FirstOrDefault() : sqlConnection.Query<T>(sql, param: dynamicParameters, commandType: commandType).FirstOrDefault();
            return result;
        }

        public IEnumerable<T> GetDataList<T>(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType) where T : class
        {
            IEnumerable<T> result = null;
            result = dynamicParameters == null ? sqlConnection.Query<T>(sql, commandType: commandType) : sqlConnection.Query<T>(sql, param: dynamicParameters, commandType: commandType);
            return result;
        }

        public void Execute(SqlConnection sqlConnection, string sql, DynamicParameters dynamicParameters, CommandType commandType)
        {
            sqlConnection.Execute(sql, dynamicParameters, commandType: commandType);
        }

        public DataTable ExecuteDataTable(SqlConnection sqlConnection, string sql, CommandType commandType, params object[] parameters)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand()
            {
                CommandText = sql,
                CommandTimeout = 0,
                CommandType = commandType,
                Connection = sqlConnection
            };

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            var da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            cmd.Parameters.Clear();

            return dt;
        }
    }
}

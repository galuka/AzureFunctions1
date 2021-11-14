using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevTesting.Business.Providers
{
    public abstract class EntityProviderBase<T>
    {
        protected async Task<T> QuerySingle(string sqlQuery)
        {
            using (var connection = CreateSqlConnection())
            {
                var queryResult = await connection.QueryAsync<T>(sqlQuery);
                return queryResult.Single();
            }
        }

        protected async Task<T> QuerySingle<TFirst, TSecond>(string sqlQuery, Func<TFirst, TSecond, T> map)
        {
            using (var connection = CreateSqlConnection())
            {
                var queryResult = await connection.QueryAsync(sqlQuery, map);
                return queryResult.Single();
            }
        }

        protected async Task<T> QuerySingle<TFirst, TSecond, TThird, TFourth>(string sqlQuery, Func<TFirst, TSecond, TThird, TFourth, T> map)
        {
            using (var connection = CreateSqlConnection())
            {
                var queryResult = await connection.QueryAsync(sqlQuery, map);
                return queryResult.Single();
            }
        }

        private SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(Environment.GetEnvironmentVariable("MyConnectionString", EnvironmentVariableTarget.Process));
        }
    }
}

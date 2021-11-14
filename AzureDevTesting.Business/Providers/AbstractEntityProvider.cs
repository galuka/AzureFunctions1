using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AzureDevTesting.Business.Providers
{
    public abstract class EntityProvider<T>
    {
        protected T QuerySingle(string sqlQuery)
        {
            using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("MyConnectionString", EnvironmentVariableTarget.Process)))
            {
                return connection.QuerySingle<T>(sqlQuery);
            }
        }

        protected T QuerySingle<TFirst, TSecond>(string sqlQuery, Func<TFirst, TSecond, T> map)
        {
            using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("MyConnectionString", EnvironmentVariableTarget.Process)))
            {
                return connection.Query<TFirst, TSecond, T>(sqlQuery, map).Single();
            }
        }
    }
}

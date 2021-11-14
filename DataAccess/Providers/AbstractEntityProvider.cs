using Dapper;
using System;
using System.Data.SqlClient;

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
    }
}

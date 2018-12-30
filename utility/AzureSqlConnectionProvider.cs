
using System;
using System.Data.SqlClient;

namespace CollabList.Utility
{
    internal class AzureSqlConnectionProvider : ISqlConnectionProvider
    {
        public SqlConnection CreateConnection()
        {
            string connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_AppUser");

            return new SqlConnection(connectionString);
        }
    }
}
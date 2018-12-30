using System.Data.SqlClient;

namespace CollabList.Utility
{
    internal interface ISqlConnectionProvider
    {
        SqlConnection CreateConnection();
    }
}
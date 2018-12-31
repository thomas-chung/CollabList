using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CollabList.Model;
using CollabList.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CollabList.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            AzureSqlConnectionProvider provider= new AzureSqlConnectionProvider();

            using (SqlConnection connection = provider.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.prc_UserGet_1218";
                    command.Parameters.Add(new SqlParameter("@userId", SqlDbType.UniqueIdentifier) { Value = id} );
                    
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return this.ReadUserRow(reader);
                        }
                        else
                        {
                            // Found no record return a 404
                            return NotFound();
                        }
                    }
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Add([FromBody]string email)
        {
            AzureSqlConnectionProvider provider= new AzureSqlConnectionProvider();

            using (SqlConnection connection = provider.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.prc_UserAdd_1218";
                    command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 512) { Value = email} );
                    
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        reader.Read();

                        return this.ReadUserRow(reader);
                    }
                }
            }
        }

        private User ReadUserRow(SqlDataReader reader)
        {
            Guid foundUserId = reader.GetGuid(reader.GetOrdinal("UserId"));
            string addedEmail = reader.GetString(reader.GetOrdinal("Email"));
            DateTime createdDateTime = reader.GetDateTime(reader.GetOrdinal("CreatedDateTime"));

            return new User(foundUserId, addedEmail, createdDateTime);
        }
    }
}
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
    public class ListController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List>> Get(
            Guid id, 
            [FromQuery] bool includeListItem, 
            [FromQuery] bool onlyUncompleted)
        {
            AzureSqlConnectionProvider provider= new AzureSqlConnectionProvider();

            using (SqlConnection connection = provider.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.prc_ListGet_1218";
                    command.Parameters.Add(new SqlParameter("@listId", SqlDbType.UniqueIdentifier) { Value = id } );
                    command.Parameters.Add(new SqlParameter("@returnItems", SqlDbType.Bit) { Value = includeListItem } );
                    command.Parameters.Add(new SqlParameter("@onlyReturnUncompletedItems", SqlDbType.Bit) { Value = onlyUncompleted} );
                    
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return await this.ReadListRow(reader);
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
        public async Task<ActionResult<List>> Add([FromBody]List list)
        {
            AzureSqlConnectionProvider provider= new AzureSqlConnectionProvider();

            using (SqlConnection connection = provider.CreateConnection())
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.prc_ListAdd_1218";
                    command.Parameters.Add(new SqlParameter("@ownerId", SqlDbType.UniqueIdentifier) { Value = list.Owner.Id} );
                    command.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 2048) { Value = list.Title} );
                    command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, -1) { Value = list.Description });
                    
                    // Do the add and then return the added row
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        reader.Read();

                        return await this.ReadListRow(reader);
                    }
                }
            }
        }

        private async Task<List> ReadListRow(SqlDataReader reader)
        {
            Guid listId = reader.GetGuid(reader.GetOrdinal("ListId"));
            Guid ownerId = reader.GetGuid(reader.GetOrdinal("OwnerId"));
            DateTime createdDateTime = reader.GetDateTime(reader.GetOrdinal("CreatedDateTime"));
            string title = reader.GetString(reader.GetOrdinal("Title"));
            string description = reader.GetString(reader.GetOrdinal("Description"));

            UserController userController = new UserController();
            ActionResult<User> owner = await userController.Get(ownerId);

            return new List(listId, owner.Value, createdDateTime, title, description);
        }
    }
}
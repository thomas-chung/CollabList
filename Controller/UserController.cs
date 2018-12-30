using System.Data.SqlClient;
using System.Threading.Tasks;
using CollabList.Model;
using CollabList.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CollabList.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<User> GetUser()
        {
            AzureSqlConnectioProvider conn

            using (SqlConnection connection = )
        }
    }
}
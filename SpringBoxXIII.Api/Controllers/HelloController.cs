using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using SpringBoxXIII.Shared.Models;
using System.Reflection.Metadata.Ecma335;

namespace SpringBoxXIII.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private string _connectionString = "Server=(local);Database=UserManagement;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT UserId, UserName, Count FROM Users";

                    var results = new List<object>();
                    using (var command = new SqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new
                            {
                                Id = reader.GetValue(reader.GetOrdinal("UserId")),
                                Name = reader.GetString(reader.GetOrdinal("UserName")),
                                Count = reader.GetInt32(reader.GetOrdinal("Count"))
                            });
                        }
                    }
                    return Ok(results);
                }

            }
            catch (SqlException ex)
            {
                return BadRequest(new { Message = ex.Message, Status = "BadRequest" });
            }
        }
        [HttpPost]
        public ActionResult Post(User user)
        {
            Console.WriteLine($"Id:{user.Id}Name:{user.Name}");
            return Ok($"服务器接收到数据！数据:Id:{user.Id}Name:{user.Name}");
        }
    }
}

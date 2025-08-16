using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SpringBoxXIII.Shared.DataModels;

namespace SpringBoxXIII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string _connectionString = "Server=(local);Database=UserManagement;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 基本验证
            if (request?.UserName == null || request.Password == null)
                return BadRequest("用户名和密码不能为空");

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("spValidateUser", connection))
                {
                    connection.Open();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", request.UserName);
                    command.Parameters.AddWithValue("@Password", request.Password);

                    // 添加返回值参数
                    var returnParam = command.Parameters.Add("@ReturnVal", System.Data.SqlDbType.Int);
                    returnParam.Direction = System.Data.ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    int result = (int)returnParam.Value;

                    if (result > 0)
                        return Ok(new { UserId = result, Message = "登录成功" });
                    else
                        return Unauthorized("用户名或密码错误");
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"数据库错误: {ex.Message}");
            }
        }
    }
}

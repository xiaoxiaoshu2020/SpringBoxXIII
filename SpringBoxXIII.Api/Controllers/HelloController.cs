using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpringBoxXIII.Shared.Models;
using System.Reflection.Metadata.Ecma335;

namespace SpringBoxXIII.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // 返回一个简单的字符串
            return Ok("服务器正常通信!");
        }
        [HttpPost]
        public ActionResult Post(User user)
        {
            Console.WriteLine($"Id:{user.Id}Name:{user.Name}");
            return Ok($"服务器接收到数据！数据:Id:{user.Id}Name:{user.Name}");
        }
    }
}

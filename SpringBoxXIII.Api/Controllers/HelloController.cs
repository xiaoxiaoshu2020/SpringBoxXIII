using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SpringBoxXIII.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // 返回一个简单的字符串
            return Ok("服务器正常通信!吴宇轩虽然奸懒馋滑，道德败坏，偷鸡摸狗，声音像男娘，站起来像个圆规，躺在床上像个“大”字，但是他就是很仁济啊");
        }
    }
}

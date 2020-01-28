using Microsoft.AspNetCore.Mvc;

namespace SignalRChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRChat : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("SignalR server running.");
        }
    }
}

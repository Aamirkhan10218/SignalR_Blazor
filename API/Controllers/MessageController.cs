using API.Hubs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORSPolicy")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> hubContext;

        public MessageController(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromQuery] string Message)
        {
            await hubContext.Clients.All.SendAsync("message",$"{ Message}");
            return Ok(new
            {
                StatusCode = 200,
                Message = "Send Successfully."
            });
        }
    }
}

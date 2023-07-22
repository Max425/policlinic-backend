using Data.BLL.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PolyclinicBackend.HubConfig;
using PolyclinicBackend.DataStorage;

namespace PolyclinicBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СonflictController : ControllerBase
    {
        private readonly IHubContext<ConflictHub> _hub;

        public СonflictController(IHubContext<ConflictHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("transferdata", DataManager.GetAll());
            return Ok();
        }
    }
}

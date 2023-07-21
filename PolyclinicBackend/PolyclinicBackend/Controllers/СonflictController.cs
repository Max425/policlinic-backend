using Data.BLL.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PolyclinicBackend.HubConfig;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Polyclinic")]
    public class СonflictController : Controller
    {
        private readonly IHubContext<ConflictHub> _hub;

        public СonflictController(IHubContext<ConflictHub> hub)
        {
            _hub = hub;
        }

/*        [HttpGet]
        public IActionResult Get() 
        { 

        }*/
    }
}

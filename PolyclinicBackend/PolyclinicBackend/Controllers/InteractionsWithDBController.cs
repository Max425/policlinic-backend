using Data.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Polyclinic")]
    public class InteractionsWithDBController : Controller
    {
        private readonly VisitorRepository _visitorRepository;
        public InteractionsWithDBController(VisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        [HttpGet("AddVisitor")]
        public async Task<IActionResult> AddVisitor(int id, string firstName, string lastName, string fatherName, string city, string gender)
        {
            IActionResult res;
            try
            {
                _visitorRepository.AddVisitor(id, firstName, lastName, fatherName, city, gender);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }
    }
}

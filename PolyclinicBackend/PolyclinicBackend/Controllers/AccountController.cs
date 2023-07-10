using Data.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PolyclinicBackend.ViewModels;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Login")]
    public class AccountController : Controller
    {

        private readonly SignInManager<Credential> _signInManager;

        public AccountController(SignInManager<Credential> signInManager)
        {
            _signInManager = signInManager;
        }

/*        [HttpGet("Login")]
        public IActionResult Login()
        {
            
        }*/
    }
}

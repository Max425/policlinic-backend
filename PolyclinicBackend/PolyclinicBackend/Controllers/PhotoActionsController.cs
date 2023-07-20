using Data.BLL.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PythonServiceWorker;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Polyclinic")]
    public class PhotoActionsController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly Facade _facade;
        public PhotoActionsController(Facade facade, IWebHostEnvironment hostingEnvironment)
        {
            _facade = facade;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("UploadPhoto")]
        public async Task<IActionResult> UploadPhoto(IList<IFormFile> files)
        {
            string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads");
            Directory.CreateDirectory(uploads);
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }

            return Ok();
        }
    }
}

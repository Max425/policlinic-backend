using Data.BLL.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.DAL.Entities;
using PythonServiceWork;
using Data.BLL.DTO;

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
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads");
            Directory.CreateDirectory(uploads);
 
            if (file.Length > 0)
            {
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                VisitorDTO visitor = PythonService.GetDataFromPhoto("C:/Python311/python.exe", $"{filePath} false");
                Console.WriteLine(visitor.Gender);
                _facade.VisitorService.CheckVisitorForExisting(visitor); // TODO: тут вызывать чекер
            }

            return Ok();
        }
    }
}

using Data.BLL.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.DAL.Entities;
using PythonServiceWork;
using Data.BLL.DTO;
using PolyclinicBackend.DataStorage;

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
 
            if (file.Length <= 0) return Ok();

            string filePath = Path.Combine(uploads, file.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            try
            {
                VisitorDTO visitor = PythonService.GetDataFromPhoto("C:/Python311/python.exe", $"{filePath} false");
                
                var valid = await _facade.VisitorService.CheckVisitorForExisting(visitor);
                if (valid == Data.DAL.Validator.ValidationEnumerator.Exist)
                {
                    // сохранение записи
                } else if (valid == Data.DAL.Validator.ValidationEnumerator.Perhaps)
                    DataManager.Add(new ConflictDTO(visitor, "Пользователь с такими паспортными данными уже существует. Проверьте данные перед сохранением"));
                else
                    DataManager.Add(new ConflictDTO(visitor, "Не удалось найти пользователя. Проверьте данные перед сохранением"));
            }
            catch (Exception ex) 
            {
                var vis = new VisitorDTO
                {
                    PhotoBase64 = file.FileName
                };
                DataManager.Add(new ConflictDTO(vis, "Не удалось считать текст с изображения")); 
            } 

            return Ok();
        }
    }
}

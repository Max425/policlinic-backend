using Data.BLL.DTO;
using Data.BLL.Facade;
using Data.DAL.Validator;
using Microsoft.AspNetCore.Mvc;
using PolyclinicBackend.DataStorage;

namespace PolyclinicBackend.Controllers;

[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Polyclinic")]
public class PhotoActionsController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly Facade _facade;

    public PhotoActionsController(Facade facade, IWebHostEnvironment hostingEnvironment)
    {
        _facade = facade;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost("UploadPhoto")]
    public async Task<IActionResult> UploadPhoto(IFormFile file)
    {
        var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads");
        Directory.CreateDirectory(uploads);

        if (file.Length <= 0) return Ok();

        var filePath = Path.Combine(uploads, file.FileName);
        await using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await file.CopyToAsync(fileStream);
        }

        try
        {
            var visitor = PythonService.PythonService.GetDataFromPhoto("C:/Python311/python.exe", $"{filePath} false");

            var valid = await _facade.VisitorService.CheckVisitorForExisting(visitor);
            switch (valid)
            {
                case ValidationEnumerator.Exist:
                    // сохранение записи
                    break;
                case ValidationEnumerator.Perhaps:
                    DataManager.Add(new ConflictDTO(visitor,
                        "Пользователь с такими паспортными данными уже существует. Проверьте данные перед сохранением"));
                    break;
                case ValidationEnumerator.NotExist:
                default:
                    DataManager.Add(new ConflictDTO(visitor,
                        "Не удалось найти пользователя. Проверьте данные перед сохранением"));
                    break;
            }
        }
        catch (Exception)
        {
            var vis = new VisitorDTO { PhotoBase64 = file.FileName };
            DataManager.Add(new ConflictDTO(vis, "Не удалось считать текст с изображения"));
        }

        return Ok();
    }
}
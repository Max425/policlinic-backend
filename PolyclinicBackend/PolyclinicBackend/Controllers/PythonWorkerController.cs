using Data.BLL.Converters.EntitiesToDTOs;
using Data.BLL.Facade;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Polyclinic")]
    public class PythonWorkerController : Controller
    {
        private readonly Facade _facade;
        public PythonWorkerController(Facade facade)
        {
            _facade = facade;
        }

        [HttpGet("GetDataFromPhotos")]
        public async Task<IActionResult> GetDataFromPhoto()
        {
            var path = @"C:\Users\tqdes\OneDrive\Рабочий стол\Polyclinic\PolyclinicBackend\PolyclinicBackend\Uploads";
            IActionResult res;

            FileInfo[] files = Directory
                              .CreateDirectory(path)
                              .GetFiles();
            for(int i = 0; i < files.Length; i++)
            {
                await _facade.VisitorService.AddVisitor(VisitorToVisitorDTO.Convert(PythonServiceWork.PythonService.GetDataFromPhoto(path + files[i].Name, "True")));
            }

            return res = Ok();
        }
    }
}

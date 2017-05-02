using System.Configuration;
using System.Linq;
using System.Web.Http;
using FileImporter.Service;

namespace FileImporter.Controllers
{
    [RoutePrefix("file")]
    public class FileController : ApiController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        [Route("import")]
        public IHttpActionResult FileImport(string file)
        {
            var filePath = string.Join(ConfigurationManager.AppSettings["folder"] ?? string.Empty, file);
            var response = _fileService.Parse(filePath);
            if (response != null && response.Any())
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OFXReader.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OFXReader.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private IFileHandler _fileHandler;

        public FileController(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var files = Request.Form.Files;

                long size = files.Sum(f => f.Length);
                
                if (files.Any())
                {
                    await _fileHandler.Upload(files);
                }
                else
                {
                    return BadRequest(new { message = "No files where added to upload.", count = files.Count, size });
                }

                return Ok(new { message = "Upload Complete.", count = files.Count, size });
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new { message = $"Upload Failed:{ex}", count = 0, size = "0" });
            }
        }

    }
}

using DemoApplication.Core.Contract;
using DemoApplication.Core.Domain.RequestModel;
using DemoApplication.Infra.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudResController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly StudResultDBContext _context;

        public StudResController(IResultService resultService, StudResultDBContext context)
        {
            _resultService = resultService;
            _context = context;
        }

        [HttpGet("GetResult")]
        public async Task<IActionResult> GetResult(string? searchTerm = null, int page = 1, int pageSize = 25)
        {
            var results = await _resultService.GetResultsAsync(searchTerm, page, pageSize);
            return Ok(results);
        }

        [HttpPost("InsertResult")]
        public async Task<IActionResult> InsertResult([FromForm] ResultRequestModel result)
        {
            await _resultService.AddResultAsync(result);
            return Created("Results", null);
        }

        [HttpDelete("DeleteResult/{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            await _resultService.DeleteResultAsync(id);
            return NoContent();
        }

        private readonly IWebHostEnvironment env;

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(int resultId)
        {
             var result = await _resultService.DownloadFile(resultId);
             var filepath = result.Split("/");
             var filename = filepath[filepath.Length - 1];


            //image,pdf downloaded but not opened 
            //var bytes = Encoding.UTF8.GetBytes(result);
            //return File(bytes, "image/jpg", filename);





            //Image,pdf downloaded but pdf not supported (only image supported)
            //string url = "https://www.africau.edu/images/default/sample.pdf";

            var path = Path.Combine(Directory.GetCurrentDirectory(), result, filename);
            var memory = new MemoryStream();

            if(System.IO.File.Exists(path))
            {
                var net = new WebClient();
                var data = net.DownloadData(path);
                var content = new MemoryStream(data);
                memory = content;
            }
            memory.Position = 0;
            return File(memory.ToArray(),"image/png",filename);

            //string url = result;
            //using (WebClient client = new WebClient())
            //{
            //    // client.DownloadFileAsync(new Uri(url), $"C:\\Users\\Shiva\\Downloads\\{filename}");
            //    client.DownloadData(new Uri(url));
            //}
            //return Ok();
            

            //return null;
        }

        /*
        [HttpGet("NewDownload")]
        public async Task<PhysicalFileResult> NewDownload(int Id)
        {
            var result = await _resultService.DownloadFile(Id);
            var filepath = result.Split("/");
            var filename = filepath[filepath.Length - 1];
            //Determine the Content Type of the File.
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(filename, out contentType);

            //Build the File Path.
            string path = Path.Combine(Environment.ProcessPath, "C:\\Users\\Shiva\\Downloads\\") + filename;


            //Send the File to Download.
            return new PhysicalFileResult(path, contentType);
        }*/
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartPark.Infrastructure.Services.TextRecognition;

namespace SmartPark.API.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private IHostEnvironment _hostingEnvironment;


        public WeatherForecastController(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("Upload")]
        public ActionResult UploadImage(IFormFile? imageFile)
        {
            string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
            {
                if (imageFile.Length > 0)
                {
                    var t = new TextRecognitionService();
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var a = t.RecognizeFromImageAsync(fileBytes).Result;


                        // act on the Base64 data
                    }
                    //string filePath = Path.Combine(uploads, Guid.NewGuid()+""+imageFile.FileName);
                    //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    //{
                    //    imageFile.CopyToAsync(fileStream);
                    //}
                }
                return Ok();
            }
        }
    }
}
//https://randomnerdtutorials.com/esp32-cam-http-post-php-arduino/
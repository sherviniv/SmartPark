using Microsoft.AspNetCore.Mvc;
using SmartPark.Infrastructure.Services.TextRecognition;

namespace SmartPark.API.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private IHostEnvironment _hostingEnvironment;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IHostEnvironment hostingEnvironment, ILogger<WeatherForecastController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        private readonly List<string> _AllowedPlateNumbers = new List<string>() { "ABC123", "RAV987" };
        [HttpPost("Upload")]
        public ActionResult UploadImage(IFormFile? imageFile)
        {
            bool allowAccess = false;
            if (imageFile.Length > 0)
            {
                _logger.LogInformation("Image received from device");
                var textRecognitionService = new TextRecognitionService();
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    //get plate number from image
                    var plateNumber = textRecognitionService.RecognizeFromImageAsync(fileBytes).Result;
                    if (string.IsNullOrEmpty(plateNumber))
                    {
                        _logger.LogInformation("No plate-number detected");
                    }
                    else
                    {
                        _logger.LogInformation($"{plateNumber} detected");
                        allowAccess = _AllowedPlateNumbers.Contains(plateNumber);
                    }
                }

                string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
                string filePath = Path.Combine(uploads, Guid.NewGuid() + "" + imageFile.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyToAsync(fileStream);
                }
            }
            return Ok(allowAccess ? "ok" : "no");
            //return Ok("ok");
        }
    }
}
//https://randomnerdtutorials.com/esp32-cam-http-post-php-arduino/
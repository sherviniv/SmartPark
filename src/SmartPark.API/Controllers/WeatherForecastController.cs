using Microsoft.AspNetCore.Mvc;
using SmartPark.Infrastructure.Services.TextRecognition;

namespace SmartPark.API.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private IHostEnvironment _hostingEnvironment;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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
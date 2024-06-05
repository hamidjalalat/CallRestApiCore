using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CallRestAppi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Post")]
        public async  Task< IEnumerable<Post>>  Get()
        {
            List<Post> postList = new List<Post>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    postList = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                }
            }

            return postList;

        }
    }
}

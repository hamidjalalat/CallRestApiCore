using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        private readonly PostService _postService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,PostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpGet(Name = "Post")]
        public async  Task< IList<Post>>  Get()
        {

            var postList = await _postService.GetAsync();

            //List<Post> postList = new List<Post>();

            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();

            //        postList = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
            //    }
            //}

            return postList;

        }

        //[HttpPost]
        //public async Task<IActionResult> AddPost(Post Post)
        //{
        //    Post receivedPost = new Post();

        //    using (var httpClient = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(Post), Encoding.UTF8, "application/json");

        //        using (var response = await httpClient.PostAsync("https://localhost:44324/api/Post", content))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            receivedPost = JsonConvert.DeserializeObject<Post>(apiResponse);
        //        }
        //    }
        //    return View(receivedPost);
        //}
    }
}

using static System.Net.Mime.MediaTypeNames;

namespace CallRestAppi
{
    public class PostService:BaseService
    {
        public PostService(HttpClient client) : base(client)
        {
        }

        protected override string GetApiUrl()
        {
            return "posts";
        }

        public async Task<IList<Post>> GetAsync()
        {
            var result = await GetAsync<IList<Post>>();

            return result;
        }

    }
}

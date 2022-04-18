using MoviesFan.Models;
using Newtonsoft.Json;

namespace MoviesFan.Services
{
    /// <summary>
    /// Movie search implementation
    /// </summary>
    public class MovieService : IMovieService
    {
        /// <summary>
        /// the config
        /// </summary>
        private readonly string _apiKey;

        public MovieService(IConfiguration config)
        {
            _apiKey = config["API_KEY"];
        }

        /// <inheritdoc/>
        public List<string> GetPictures()
        {
            string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/upload");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var files = Directory.GetFiles(path, "*.jpg");
            var result = new List<string>();
            foreach (var file in files)
            {
                var fn = Path.GetFileName(file);
                result.Add($"/upload/{fn}");
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<SearchResult?> Search(string query, int page)
        {
            using var client = new HttpClient();
            var address = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language=en-US&query={query}&page={page}&include_adult=false");
            var response = await client.GetAsync(address);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("API did not work!");
            }
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SearchResult>(body);
            return result;
        }

        /// <inheritdoc/>
        public async Task Upload(string name, Stream stream)
        {
            var root = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot/upload");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var path = $"{root}/{name}";
            using FileStream fs = new(path, FileMode.Create);
            await stream.CopyToAsync(fs);
        }
    }
}

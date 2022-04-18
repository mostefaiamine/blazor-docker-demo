using MoviesFan.Models;

namespace MoviesFan.Services
{
    /// <summary>
    /// Movie service
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Gets the uploaded pictures
        /// </summary>
        /// <returns>The list of uploaded pictures</returns>
        List<string> GetPictures();

        /// <summary>
        /// Finds movies
        /// </summary>
        /// <param name="query">The search query</param>
        /// <param name="page">The page</param>
        /// <returns>The search result</returns>
        Task<SearchResult?> Search(string query, int page);

        /// <summary>
        /// Uploads a new picture
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        Task Upload(string name, Stream stream);
    }
}

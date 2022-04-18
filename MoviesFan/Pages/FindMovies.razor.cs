using Microsoft.AspNetCore.Components;
using MoviesFan.Models;
using MoviesFan.Services;

namespace MoviesFan.Pages
{
    public partial class FindMovies
    {
        /// <summary>
        /// indicates that we can search
        /// </summary>
        private bool CanSearch
        {
            get
            {
                return !string.IsNullOrEmpty(QueryText);
            }
        }

        /// <summary>
        /// Current page
        /// </summary>
        private int CurrentPage { get; set; }

        /// <summary>
        /// Indicates an error
        /// </summary>
        private bool Error { get; set; } = false;

        /// <summary>
        /// True if we are loading data
        /// </summary>
        private bool Loading { get; set; } = false;

        /// <summary>
        /// The movie service
        /// </summary>
        [Inject]
        private IMovieService? MovieService { get; set; }

        /// <summary>
        /// query text
        /// </summary>
        private string? QueryText { get; set; }

        /// <summary>
        /// Results
        /// </summary>
        private SearchResult? Results { get; set; } = null;

        /// <summary>
        /// Triggers search
        /// </summary>
        /// <param name="page">The page number</param>
        /// <returns>The search results</returns>
        private async Task Search(int page)
        {
            if (MovieService == null)
            {
                return;
            }
            Error = false;
            Loading = true;
            try
            {
                if (QueryText != null)
                {
                    Results = await MovieService.Search(QueryText, page);
                }
            }
            catch
            {
                Error = true;
            }
            finally
            {
                Loading = false;
            }
        }
    }
}

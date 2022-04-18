namespace MoviesFan.Models
{
    /// <summary>
    /// An item of a movie query result
    /// </summary>
    public class SearchResultItem
    {
        /// <summary>
        /// The movie id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Overview
        /// </summary>
        public string? Overview { get; set; }

        /// <summary>
        /// Poster path
        /// </summary>
        public string? Poster_Path { get; set; }

        /// <summary>
        /// Results
        /// </summary>
        public SearchResultItem[]? Results { get; set; }

        /// <summary>
        /// Release date
        /// </summary>
        public string? Release_date { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string? Title { get; set; }

       
    }
}

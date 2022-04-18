namespace MoviesFan.Models
{
    /// <summary>
    /// Find result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// The current page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Results
        /// </summary>
        public SearchResultItem[]? Results { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public int Total_Pages { get; set; }

        /// <summary>
        /// Total number of results
        /// </summary>
        public int Total_results { get; set; }
    }
}

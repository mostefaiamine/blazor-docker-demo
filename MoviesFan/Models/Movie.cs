namespace MoviesFan.Models
{
    /// <summary>
    /// Represents a movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// The movie id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Release year
        /// </summary>
        public int Year { get; set; }
    }
}

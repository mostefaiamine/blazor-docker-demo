using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MoviesFan.Models;

namespace MoviesFan.Pages
{    

    public partial class Favorites
    {
        /// <summary>
        /// The movie context
        /// </summary>
        [Inject]
        private MovieContext? Context { get; set; }

        /// <summary>
        /// Indicates that an error has happended
        /// </summary>
        private bool Error { get; set; } = false;

        /// <summary>
        /// Indicates we are loading
        /// </summary>
        private bool Loading { get; set; } = false;

        /// <summary>
        /// Movies
        /// </summary>
        private List<Movie>? Movies { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            Error = false;
            try
            {
                if((Context != null)&&(Context.Movies != null))
                {
                    Movies = await Context.Movies.ToListAsync();
                }
            }
            catch (Exception)
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

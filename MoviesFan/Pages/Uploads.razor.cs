using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MoviesFan.Services;

namespace MoviesFan.Pages
{
    public partial class Uploads
    {
        /// <summary>
        /// Upload pictures paths
        /// </summary>
        private List<string>? Uploaded { get; set; }

        /// <summary>
        /// The movie service
        /// </summary>
        [Inject]
        private IMovieService? Service { get; set; }

        protected override void OnInitialized()
        {
            if (Service != null)
            {
                Uploaded = Service.GetPictures();
            }
        }

        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            if (Service == null)
            {
                return;
            }
            var files = e.GetMultipleFiles();
            if ((files.Count == 0) || (files.Count > 1))
            {
                return;
            }
            foreach (var file in files)
            {
                var name = file.Name;
                await Service.Upload(name, file.OpenReadStream());               
            }
            Uploaded= Service.GetPictures();
        }


    }
}

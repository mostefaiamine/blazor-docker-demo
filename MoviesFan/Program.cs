using Microsoft.EntityFrameworkCore;
using MoviesFan.Models;
using MoviesFan.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IMovieService, MovieService>();
var config = builder.Configuration;
builder.Services.AddDbContextPool<MovieContext>(options =>
{
    var cn = config["DB_CONNECTION_STRING"];
    cn = cn ?? "defaultcn";
    options.UseSqlServer(cn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

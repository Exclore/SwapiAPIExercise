using Microsoft.EntityFrameworkCore;
using StarWarsAPIExercise.DataAccess;
using StarWarsAPIExercise.Models;
using Newtonsoft.Json;

string SWAPIConnectionString = "https://swapi.dev/api/starships/";
HttpClient client = new HttpClient();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StarshipContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StarshipContext") ?? throw new InvalidOperationException("Connection string 'StarshipContext' not found.")));

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<StarshipContext>();
    context.Database.EnsureCreated();

    var testStarship = context.Starships.FirstOrDefault(b => b.Name != null);
    if (testStarship == null)
    {
        var starships = await GetSWAPIResponseAsync(SWAPIConnectionString);
        starships.Results.ForEach(s => context.Starships.Add(s));
    }

    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

async Task<SwapiResponse> GetSWAPIResponseAsync(string path)
{
    SwapiResponse swapiResponse = null;

    HttpResponseMessage response = await client.GetAsync(path);
    if (response.IsSuccessStatusCode)
    {
        var stringResponse = await response.Content.ReadAsStringAsync();
        swapiResponse = JsonConvert.DeserializeObject<SwapiResponse>(stringResponse);
    }
    return swapiResponse;
}
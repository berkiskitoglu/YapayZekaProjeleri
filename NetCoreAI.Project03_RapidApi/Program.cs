
using Microsoft.Extensions.Configuration;
using NetCoreAI.Project03_RapidApi.ViewModels;
using Newtonsoft.Json;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var key = config["RapidApi:Key"];
var host = config["RapidApi:Host"];
var client = new HttpClient();
List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", key },
        { "x-rapidapi-host", host },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
    foreach (var movies in apiMovieViewModels)
    {
        Console.WriteLine(movies.rank + "-" + movies.title + "-Film Puanı: " + movies.rating + "-Yapım Yılı: " + movies.year);
    }
    Console.WriteLine();
}

Console.ReadLine();
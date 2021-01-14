using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

public class Genre
{
    public int id { get; set; }
    public string name { get; set; }
}

public class ProductionCompany
{
    public int id { get; set; }
    public string logo_path { get; set; }
    public string name { get; set; }
    public string origin_country { get; set; }
}

public class ProductionCountry
{
    public string iso_3166_1 { get; set; }
    public string name { get; set; }
}

public class SpokenLanguage
{
    public string english_name { get; set; }
    public string iso_639_1 { get; set; }
    public string name { get; set; }
}

public class Root
{
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public object belongs_to_collection { get; set; }
    public int budget { get; set; }
    public List<Genre> genres { get; set; }
    public string homepage { get; set; }
    public int id { get; set; }
    public string imdb_id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path { get; set; }
    public List<ProductionCompany> production_companies { get; set; }
    public List<ProductionCountry> production_countries { get; set; }
    public string release_date { get; set; }
    public int revenue { get; set; }
    public int runtime { get; set; }
    public List<SpokenLanguage> spoken_languages { get; set; }
    public string status { get; set; }
    public string tagline { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
}

public class ImdbAPI
{
    public string MovieDescription { get; set; }
    public string PictureAddress { get; set; }
    public string MovieTitle { set; get; }
    public string MessageContent { set; get; }
    
    public ImdbAPI()
    {

    }

    public async void GetMovieDetails(int movieId)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}?api_key=bbaf97a3069fad0118f94c81a1d7cc9e")
        };

        Root details;
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        details = JsonSerializer.Deserialize<Root>(body, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        MovieDescription = details.overview;
        MovieTitle = details.title;
        PictureAddress = "https://image.tmdb.org/t/p/original" + details.poster_path;
    }
}


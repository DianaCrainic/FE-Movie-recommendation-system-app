﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;




    public class Image
    {
        public int height { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Title
    {
        public string Type { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
        public int runningTimeInMinutes { get; set; }
        public string nextEpisode { get; set; }
        public int numberOfEpisodes { get; set; }
        public int seriesEndYear { get; set; }
        public int seriesStartYear { get; set; }
        public string title { get; set; }
        public string titleType { get; set; }
        public int year { get; set; }
    }

    public class US
    {
        public string certificate { get; set; }
        public string country { get; set; }
    }

    public class Certificates
    {
        public List<US> US { get; set; }
    }

    public class OtherRank
    {
        public string id { get; set; }
        public string label { get; set; }
        public int rank { get; set; }
        public string rankType { get; set; }
    }

    public class Ratings
    {
        public bool canRate { get; set; }
        public double rating { get; set; }
        public int ratingCount { get; set; }
        public List<OtherRank> otherRanks { get; set; }
    }

    public class PlotOutline
    {
        public string author { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class PlotSummary
    {
        public string author { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class DetailsRoot
    {
        public string id { get; set; }
        public Title title { get; set; }
        public Certificates certificates { get; set; }
        public Ratings ratings { get; set; }
        public List<string> genres { get; set; }
        public string releaseDate { get; set; }
        public PlotOutline plotOutline { get; set; }
        public PlotSummary plotSummary { get; set; }
    }



    public class Director
    {
        public string disambiguation { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
        public string legacyNameText { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int endYear { get; set; }
        public int episodeCount { get; set; }
        public int startYear { get; set; }
        public List<string> akas { get; set; }
    }

    public class Writer
    {
        public string id { get; set; }
        public Image image { get; set; }
        public string legacyNameText { get; set; }
        public string name { get; set; }
        public List<string> attr { get; set; }
        public string category { get; set; }
        public int endYear { get; set; }
        public int episodeCount { get; set; }
        public string job { get; set; }
        public int startYear { get; set; }
        public List<string> akas { get; set; }
        public string disambiguation { get; set; }
    }

    public class ActorsRoot
    {
        public List<Director> directors { get; set; }
        public List<Writer> writers { get; set; }
    }


   
    public class ImdbAPI
    {
        public  string MovieDescritpion { get; set; }
        public  string PictureAddress { get; set; }
       public  string MovieTitle { set; get; }
        
        public ImdbAPI()
        {

        }


        public  async void GetMovieDetails(int movieId)
        {

            MovieDescritpion = null;
            PictureAddress = null;
            MovieTitle = null;     

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/get-overview-details?tconst=tt0{movieId}&currentCountry=US"),
                Headers =
                    {
                    { "x-rapidapi-key","9d77eea953msh05a8a5f0a2e1c53p1f3925jsn508123787afb" }, /**/ 
                    { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
                },
            };
            
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                DetailsRoot details = JsonSerializer.Deserialize<DetailsRoot>(body, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (details.plotSummary == null)
                {
                     return;
                }
                MovieDescritpion = details.plotSummary.text;
                MovieTitle = details.title.title;
                PictureAddress = details.title.image.url;
            }
        }
    }   


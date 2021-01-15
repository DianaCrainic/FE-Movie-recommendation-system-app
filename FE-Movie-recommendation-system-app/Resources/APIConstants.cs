public static class APIConstants
{
    public const string BaseUrl = "http://localhost:5000";
    public const string JsonContent = "application/json";
    public const string AuthenticationHeaderValueBearer = "Bearer";
    public const string AuthenticateEndpoint = "/users/authenticate";
    public const string UsersEndpoint = "/users";
    public const string RatingsEndpoint = "/ratings";
    public const string RatingsForUserEndpoint = "/ratings/users";
    public const string MoviesEndpoint = "/movies";
    public const string ActorsFromMovieEndpoint = "/actors/movies";
    public const string RecommendationsForUserEndpoint = "/recommendations";
    public const string NumberOfPagesHeader = "numberOfPages";
    public const string MovieGenresEndpoint = "/genres";
    public const string ImdbApiPictureBaseAddreess = "https://image.tmdb.org/t/p/original";
    public const string ImdbApiRequestBaseAddress = "https://api.themoviedb.org/3/movie";
    public const string ImdbApiRapidKey = "bbaf97a3069fad0118f94c81a1d7cc9e";
}
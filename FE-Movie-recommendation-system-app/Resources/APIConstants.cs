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
}
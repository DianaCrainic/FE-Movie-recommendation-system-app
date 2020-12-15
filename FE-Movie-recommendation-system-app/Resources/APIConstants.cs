public static class APIConstants
{
    public const string BaseUrl = "http://localhost:5000";
    public const string JsonContent = "application/json";
    public const string AuthenticationHeaderValueBearer = "Bearer";
    public const string AuthenticateEndpoint = "/api/v1/users/authenticate";
    public const string UsersEndpoint = "/api/v1/users";
    public const string RatingsEndpoint = "/api/v1/ratings";
    public const string RatingsForUserEndpoint = "/api/v1/ratings/users";
    public const string MoviesEndpoint = "/api/v1/movies";
    public const string ActorsFromMovieEndpoint = "/api/v1/actors/movies";
}
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public HttpService(
        HttpClient httpClient,
        ILocalStorageService localStorageService
    )
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<T> Get<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        return await SendRequest<T>(request);
    }

    public async Task Post(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Post, uri, value);
        await SendRequest(request);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Post, uri, value);
        return await SendRequest<T>(request);
    }

    public async Task Put(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Put, uri, value);
        await SendRequest(request);
    }

    public async Task<T> Put<T>(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Put, uri, value);
        return await SendRequest<T>(request);
    }

    public async Task Delete(string uri)
    {
        var request = CreateRequest(HttpMethod.Delete, uri);
        await SendRequest(request);
    }

    public async Task Delete(string uri, object value)
    {
        var request = CreateRequest(HttpMethod.Delete, uri, value);
        await SendRequest(request);
    }

    public async Task<T> Delete<T>(string uri)
    {
        var request = CreateRequest(HttpMethod.Delete, uri);
        return await SendRequest<T>(request);
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string uri, object value = null)
    {
        var request = new HttpRequestMessage(method, uri);
        if (value != null)
        {
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, APIConstants.JsonContent);
        }
        return request;
    }

    private async Task SendRequest(HttpRequestMessage request)
    {
        await AddJwtHeader(request);

        using var response = await _httpClient.SendAsync(request);

        await HandleErrors(response);
    }

    private async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        await AddJwtHeader(request);

        using var response = await _httpClient.SendAsync(request);

        await HandleErrors(response);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new StringConverter());
        return await response.Content.ReadFromJsonAsync<T>(options);
    }

    private async Task AddJwtHeader(HttpRequestMessage request)
    {
        var user = await _localStorageService.GetItem<User>(LocalStorageConstants.UserItem);
        var isApiUrl = !request.RequestUri.IsAbsoluteUri;
        if (user != null && isApiUrl)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(APIConstants.AuthenticationHeaderValueBearer, user.Token);
        }
    }

    private async Task HandleErrors(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            string error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
    }
}
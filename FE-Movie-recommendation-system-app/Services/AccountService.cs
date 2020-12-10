using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

public class AccountService : IAccountService
{
    private IHttpService _httpService;
    private NavigationManager _navigationManager;
    private ILocalStorageService _localStorageService;
    private readonly string _userKey = "user";

    public User User { get; private set; }

    public AccountService(
        IHttpService httpService,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService
    )
    {
        _httpService = httpService;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task Initialize()
    {
        User = await _localStorageService.GetItem<User>(_userKey);
    }

    public async Task Login(LoginRequest loginRequest)
    {
        User = await _httpService.Post<User>("/api/v1/users/authenticate", loginRequest);
        await _localStorageService.SetItem(_userKey, User);
    }

    public async Task Logout()
    {
        User = null;
        await _localStorageService.RemoveItem(_userKey);
        _navigationManager.NavigateTo("account/login");
    }

    public async Task Register(RegisterRequest registerRequest)
    {
        await _httpService.Post("/api/v1/users", registerRequest);
    }
}


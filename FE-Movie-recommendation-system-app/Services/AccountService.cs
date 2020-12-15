using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

public class AccountService : IAccountService
{
    private readonly IHttpService _httpService;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;

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
        User = await _localStorageService.GetItem<User>(LocalStorageConstants.UserItem);
    }

    public async Task Login(LoginRequest loginRequest)
    {
        User = await _httpService.Post<User>(APIConstants.AuthenticateEndpoint, loginRequest);
        await _localStorageService.SetItem(LocalStorageConstants.UserItem, User);
    }

    public async Task Logout()
    {
        User = null;
        await _localStorageService.RemoveItem(LocalStorageConstants.UserItem);
        _navigationManager.NavigateTo(PagesConstants.LoginPage);
    }

    public async Task Register(RegisterRequest registerRequest)
    {
        await _httpService.Post(APIConstants.UsersEndpoint, registerRequest);
    }
}


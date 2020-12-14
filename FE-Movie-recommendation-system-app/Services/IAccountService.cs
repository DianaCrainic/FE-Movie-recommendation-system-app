using System.Threading.Tasks;

public interface IAccountService
{
    User User { get; }
    Task Initialize();
    Task Login(LoginRequest loginRequest);
    Task Logout();
    Task Register(RegisterRequest registerRequest);
}


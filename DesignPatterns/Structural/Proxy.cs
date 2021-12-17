/**
 * GoF DEFINITION:
 * Provide a surrogate or placeholder for another object to control access to it.
 * 
 * CONCEPT:
 * You need to support this kind of design because, in many situations, direct 
 * communication with an original object is not always possible. This is due to many 
 * factors, including security and performance issues, resource constraints, the final 
 * product is in the development phase, and so forth. Proxies can be of different types, 
 * but fundamentally it is a substitute (or a placeholder) for an original object. As a result, 
 * when a client interacts with a proxy object, it appears that it is directly talking to the 
 * actual object. So, using this pattern, you may want to use a class that can perform as an 
 * interface to the original one.
*/

namespace DesignPatterns.Structural;

public interface ILoginService
{
    public string Login();
}

public class ConcreteLoginService : ILoginService
{
    public string Login()
    {
        // Returning a login token
        return Guid.NewGuid().ToString();
    }
}

public class LoginServiceProxy : ILoginService
{
    private ILoginService _loginService;
    private List<string> _users = new List<string>(new string[] { "fredrick", "alejandro", "alfonso", "dominic" });
        
    public string CurrentUser { get; set; }

    public LoginServiceProxy(string currentUser)
    {
        CurrentUser = currentUser;
    }

    public string Login()
    {
        if (_users.Contains(CurrentUser))
        {
            if (_loginService is null)
            {
                _loginService = new ConcreteLoginService();
            }

            return _loginService.Login();
        }

        return String.Empty;
    }
}
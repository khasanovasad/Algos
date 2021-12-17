namespace Tests.DesignPatterns.Structural;

[TestFixture]
public class ProxyTests
{
    [Test]
    public void Proxy_Should_Login_Existing_User()
    {
        const string validUsername = "fredrick";
        ILoginService loginService = new LoginServiceProxy(validUsername);
            
        var result = loginService.Login();
            
        Assert.IsNotEmpty(result);
    }
        
    [Test]
    public void Proxy_Should_Not_Login_Non_Existing_User()
    {
        const string invalidUsername = "malhotra";
        ILoginService loginService = new LoginServiceProxy(invalidUsername);

        var result = loginService.Login();
            
        Assert.IsEmpty(result);
    }
}
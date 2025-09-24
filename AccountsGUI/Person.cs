using static AccountsGUI.Delegates;
namespace AccountsGUI;
public class Person
{
    private string password;
    private LoginEventHandler onLogin;

    public string Sin { get;}
    public string Name { get;}
    public bool IsAuthenticated { get; private set; }


    public Person(string name, string sin)
    {
        Sin = sin;
        Name = name;
        password = $"{sin[0]}{sin[1]}{sin[2]}";
    }

    public void Login(string password)
    {
        if (password != this.password)
        {
            IsAuthenticated = false;
            onLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
            Logger.LoginHandler(this, new LoginEventArgs($"{this.Name}", false, LoginEventType.Login));
            throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
        }
        Logger.LoginHandler(this, new LoginEventArgs($"{this.Name}", true, LoginEventType.Login));
        IsAuthenticated = true;
        onLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Login));
    }
    public void Logout()
    {
        Logger.LoginHandler(this, new LoginEventArgs($"{this.Name}", true, LoginEventType.Logout));
        IsAuthenticated = false;
        onLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Logout));
    }

    public override string ToString()
    {
        return IsAuthenticated ? $"{Name} - Authenticated" : $"{Name} - Not Authenticated";
    }
}


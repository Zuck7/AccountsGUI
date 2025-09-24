using System.Reflection;

namespace AccountsGUI;

public enum LoginEventType
{
    None,
    Login,
    Logout
}

public class LoginEventArgs : EventArgs
{
    public string PersonName { get; }
    public bool Success { get; }
    public DayTime Time { get; }
    public LoginEventType EventType { get; }

    public LoginEventArgs(string username, bool success, LoginEventType loginEventType) : base() 
    {
        PersonName = username;
        Success = success;
        EventType = loginEventType;
    }

} 
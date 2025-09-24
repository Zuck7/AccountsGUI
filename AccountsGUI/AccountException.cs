namespace AccountsGUI;

public class AccountException : Exception
{
    public AccountException(AccountExceptionType reason) : base(reason.ToString())
    {
    }
}
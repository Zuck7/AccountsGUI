using System.Text.Json;

namespace AccountsGUI;
public static class Bank
{
    static public readonly Dictionary<string, Account> ACCOUNTS = new Dictionary<string, Account>();
    static public readonly Dictionary<string, Person> USERS = new Dictionary<string, Person>();

    static Bank()
    {
        AddPerson("Narendra", "1234-5678"); //0
        AddPerson("Ilia", "2345-6789"); //1
        AddPerson("Mehrdad", "3456-7890"); //2
        AddPerson("Vinay", "4567-8901"); //3
        AddPerson("Arben", "5678-9012"); //4
        AddPerson("Patrick", "6789-0123"); //5
        AddPerson("Yin", "7890-1234"); //6
        AddPerson("Hao", "8901-2345"); //7
        AddPerson("Jake", "9012-3456"); //8
        AddPerson("Mayy", "1224-5678"); //9
        AddPerson("Nicoletta", "2344-6789"); //10
        //initialize the ACCOUNTS collection
        AddAccount(new VisaAccount()); //VS-100000
        AddAccount(new VisaAccount(150, -500)); //VS-100001
        AddAccount(new SavingAccount(5000)); //SV-100002
        AddAccount(new SavingAccount()); //SV-100003
        AddAccount(new CheckingAccount(2000)); //CK-100004
        AddAccount(new CheckingAccount(1500, true));//CK-100005
        AddAccount(new VisaAccount(50, -550)); //VS-100006
        AddAccount(new SavingAccount(1000)); //SV-100007
                                             //associate users with accounts
        string number = "VS-100000";
        AddUserToAccount(number, "Narendra");
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Mehrdad");
        number = "VS-100001";
        AddUserToAccount(number, "Vinay");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Patrick");
        number = "SV-100002";
        AddUserToAccount(number, "Yin");
        AddUserToAccount(number, "Hao");
        AddUserToAccount(number, "Jake");
        number = "SV-100003";
        AddUserToAccount(number, "Mayy");
        AddUserToAccount(number, "Nicoletta");
        number = "CK-100004";
        AddUserToAccount(number, "Mehrdad");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Yin");
        number = "CK-100005";
        AddUserToAccount(number, "Jake");
        AddUserToAccount(number, "Nicoletta");
        number = "VS-100006";
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Vinay");
        number = "SV-100007";
        AddUserToAccount(number, "Patrick");
        AddUserToAccount(number, "Hao");
    }

    public static void AddPerson(string name, string sin)
    {
        if (USERS.ContainsKey(sin))
        {
            throw new AccountException(AccountExceptionType.USER_ALREADY_EXIST);
        }
        else
        {
            Person newUser = new Person(name, sin);
            USERS.Add(sin, newUser);
        }

    }
    public static void AddAccount(Account account)
    {
        if (ACCOUNTS.ContainsKey(account.Number))
        {
            throw new AccountException(AccountExceptionType.ACCOUNT_ALREADY_EXIST);
        }
        else
        {
            foreach (var user in account.users)
            {
                Logger.TransactionHandler(account, new TransactionEventArgs(user.Name, 100, true));
            }
            ACCOUNTS.Add(account.Number, account);
        }
        
    }

    public static void AddUserToAccount(string number, string name)
    {
        Person person = GetUser(name);
        Account account = GetAccount(number);
        account.AddUser(person);
    }
    
    public static Account GetAccount(string number)
    {
        if (!ACCOUNTS.ContainsKey(number))
        {
            throw new AccountException(AccountExceptionType.ACCOUNT_DOES_NOT_EXIST);
        } 
        return ACCOUNTS.GetValueOrDefault(number);
    }
    
    public static Person GetUser(string name)
    {
        foreach (var user in USERS)
        {
            if (user.Value.Name == name)
            {
                return user.Value;
            } 
        }

        throw new AccountException(AccountExceptionType.USER_DOES_NOT_EXIST);
    }
    
    public static void PrintAccounts()
    {
        foreach (var account in ACCOUNTS)
        {
            Console.WriteLine($"{account.ToString()}");
        }
    }
    
    public static void PrintUsers()
    {
        foreach (var user in USERS)
        {
            Console.WriteLine(user.Value.IsAuthenticated ? $"   {user.Value.Name} [{user.Value.Sin}] Authenticated\n" : $"   {user.Value.Name} [{user.Value.Sin}] Not authenticated\n");
        }
    }

    public static void SaveAccounts(string filename)
    {
        StreamWriter writer= new StreamWriter(filename);
        foreach (var account in ACCOUNTS)
        {
            string jsonText = JsonSerializer.Serialize(account);
            writer.Write(jsonText);
        }
        writer.Close();
    }
    public static void SaveUsers(string filename)
    {
        StreamWriter writer= new StreamWriter(filename);
        foreach (var user in USERS)
        {
            string jsonText = JsonSerializer.Serialize(user);
            writer.Write(jsonText);
        }
        writer.Close();
    }

}

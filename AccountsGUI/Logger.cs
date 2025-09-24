namespace AccountsGUI;

public static class Logger
{
    private static List<string> loginEvents = new List<string>();
    private static List<string> transactionEvents = new List<string>();

    public static void LoginHandler(object sender, LoginEventArgs args)
    {
        string log = $"Login attempted by {args.PersonName}, Succsess: {args.Success}";
        loginEvents.Add(log);
    }

    public static void TransactionHandler(object sender, TransactionEventArgs args)
    {
        string log = $"{args.Amount:C} {args.PersonName} on {args.Time}";
        transactionEvents.Add(log);
    }

    public static void DisplayLoginEvents(string filename)
    {
        Console.WriteLine("Login events:");
        int count = 1;
        foreach (string log in loginEvents)
        {
            Console.WriteLine($"{count++}. {log}");
        }
    }

    public static void DisplayTransactionEvents()
    {
        Console.WriteLine("\nTransaction events:");
        int count = 1;
        foreach (string log in transactionEvents)
        {
            Console.WriteLine($"{count++}. {log}");
        }
    }
}

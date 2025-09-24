using System.Transactions;
using System.Xml.Linq;
using static AccountsGUI.Delegates;

namespace AccountsGUI;

public abstract class Account 
{
    public List<Person> users { get; } = new List<Person>();
    public List<Transaction> transactions { get; } = new List<Transaction>();
    private static int LAST_NUMBER = 100_000;
    private event TransactionEventHandler OnTransaction; 
    public decimal Balance { get; protected set; }
    public decimal LowestBalance { get; protected set; }
    public string Number { get; }

    public abstract void PrepareMonthlyReport();

    public Account(string type, decimal balance)
    {
        Number = $"{type}-{LAST_NUMBER}";
        LAST_NUMBER = LAST_NUMBER + 1;
        Balance = balance;
        LowestBalance = Balance; 
    }

    protected void Deposit(decimal balance, Person person)
    {
        Balance += balance;
        if (LowestBalance > Balance)
        {
            LowestBalance = Balance;
        }
        Transaction t = new Transaction(this.Number, balance, person);
        transactions.Add(t);
    }

    public void AddUser(Person user)
    {
        users.Add(user);
    }

    public bool IsUser(Person user)
    {
        foreach (Person person in users)
        {
            if (person.Name == user.Name && person.Sin == user.Sin)
            {
                return true;
            }
        }
        return false;
    }

    public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
    {
        Logger.TransactionHandler(sender, e);
        OnTransaction?.Invoke(sender, e);
    }

    public override string ToString()
    {
        string result = $"{Number}\n";

        foreach (Person user in users)
        {
            result += user.IsAuthenticated ? $"   {user.Name} [{user.Sin}] Authenticated\n" : $"   {user.Name} [{user.Sin}] Not authenticated\n";
        }
        result += $"Balance: {Balance:c}\n";

        if (transactions.Count == 0)
        {
            result += "No transactions available\n";
        }
        else
        {
            foreach (Transaction t in transactions)
            {
                result += $"   {t}\n";
            }
        }
        return result;
    }
}
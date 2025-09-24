namespace AccountsGUI;

class CheckingAccount : Account
{
    private decimal COST_PER_TRANSACTION = 0.05m;
    private decimal INTEREST_RATE = 0.005m;
    private bool hasOverdraft;

    public CheckingAccount(decimal balance = 0, bool hasOverdraft = false) : base ("CK", balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public new void Deposit (decimal amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(person, new TransactionEventArgs(person.Name, amount, false));
    }

    public void Withdraw ( decimal amount, Person person)
    {
        if (!IsUser(person))
        {
            OnTransactionOccur(person, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(AccountExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
        }

        if (!person.IsAuthenticated)
        {
            OnTransactionOccur(person, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(AccountExceptionType.USER_NOT_LOGGED_IN);
        }

        if ( amount > Balance && !hasOverdraft)
        {
            OnTransactionOccur(person, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(AccountExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
        }

        base.Deposit(-amount, person);
        OnTransactionOccur(person, new TransactionEventArgs(person.Name, -amount, true));
    }

    public override void PrepareMonthlyReport()
    {
        decimal serviceCharge = COST_PER_TRANSACTION * transactions.Count;
        decimal interest = (LowestBalance * INTEREST_RATE) / 12;
        
        Balance += interest - serviceCharge;
        transactions.Clear();
    }
}
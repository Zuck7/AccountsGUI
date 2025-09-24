using System;
using System.Security.Principal;
using System.Xml.Linq;

namespace AccountsGUI
{
	class VisaAccount : Account
    {
		private decimal CreditLimit { get; }
		private static decimal INTEREST_RATE = 0.1995M;

        public VisaAccount(decimal balance = 0, decimal creditLimit = 1200M)
            : base("VS", balance) => (this.CreditLimit) = (creditLimit);

        public void Pay(decimal amount, Person person)
        {
            TransactionEventArgs eventArgs = new TransactionEventArgs(person.Name, amount, true);
            Deposit(amount, person);
            OnTransactionOccur(person, eventArgs);
        }
        public void Purchase(decimal amount, Person person)
        {
            if (!IsUser(person))
            {
                TransactionEventArgs t = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, t);
                throw new AccountException(AccountExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            else if (!person.IsAuthenticated)
            {
                TransactionEventArgs t = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, t);
                throw new AccountException(AccountExceptionType.USER_NOT_LOGGED_IN);
            }
            else if(amount > (CreditLimit + Balance)) 
            {
                TransactionEventArgs t = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, t);
                throw new AccountException(AccountExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            else
            {
                TransactionEventArgs t = new TransactionEventArgs(person.Name, amount, true);
                OnTransactionOccur(person, t);
                Deposit(amount * -1, person);
            }
        }

        public override void PrepareMonthlyReport()
        {
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            transactions.Clear();
        }
    }
}
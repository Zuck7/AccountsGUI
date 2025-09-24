using System;

namespace AccountsGUI
{
	public struct Transaction
	{
		public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, decimal amount, Person person)
        {
            this.AccountNumber = accountNumber;
            this.Amount = amount;
            this.Originator = person;
            this.Time = Util.Now;
        }

        public override string ToString()
        {
            return $"{AccountNumber} {Amount:c} {Originator.Name} {Time}";
            // Example VS-100000 $1,500.00 Narendra 2025-03-22 16:17
        }
    }
}


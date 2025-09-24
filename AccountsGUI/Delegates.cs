using System;
using System.Transactions;

namespace AccountsGUI
{
	public class Delegates
	{
        public delegate void TransactionEventHandler(object sender,TransactionEventArgs e);
        public delegate void LoginEventHandler(object sender, LoginEventArgs e);
    }
}


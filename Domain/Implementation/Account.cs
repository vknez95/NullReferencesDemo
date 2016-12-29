using NullReferencesDemo.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NullReferencesDemo.Domain.Implementation
{
    internal class Account: IAccount
    {

        private IList<MoneyTransaction> transactions = new List<MoneyTransaction>();

        public MoneyTransaction Deposit(decimal amount)
        {
        
            MoneyTransaction trans = new MoneyTransaction(amount);
            this.transactions.Add(trans);
            
            return trans;
        
        }

        public MoneyTransaction Withdraw(decimal amount)
        {

            if (this.Balance < amount)
                return null;

            MoneyTransaction trans = new MoneyTransaction(-amount);
            this.transactions.Add(trans);

            return trans;

        }

        public decimal Balance
        {
            get
            {
                return this.transactions.Sum(trans => trans.Amount);
            }
        }
    }
}

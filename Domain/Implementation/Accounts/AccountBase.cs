using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation.Accounts
{
    public abstract class AccountBase : IAccount
    {
        private readonly IList<MoneyTransaction> registeredTransactions = new List<MoneyTransaction>();

        public virtual decimal Balance
        {
            get
            {
                return this.registeredTransactions.Sum(trans => trans.Amount);
            }
        }

        protected void RegisterTransaction(MoneyTransaction trans)
        {
            this.registeredTransactions.Add(trans);
        }

        public abstract MoneyTransaction Deposit(decimal amount);

        public abstract Option<MoneyTransaction> TryWithdraw(decimal amount);

    }
}

using System;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Implementation.Accounts
{
    public class DebitAccount : AccountBase
    {
        public override MoneyTransaction Deposit(decimal amount)
        {
            Contract.Requires<ArgumentException>(amount > 0, "Amount to deposit must be positive.", nameof(amount));

            MoneyTransaction trans = new MoneyTransaction(amount);

            base.RegisterTransaction(trans);

            return trans;

        }

        public override Option<MoneyTransaction> TryWithdraw(decimal amount)
        {
            Contract.Requires<ArgumentException>(amount > 0, "Amount to withdraw must be positive.", nameof(amount));

            if (this.Balance < amount)
                return Option<MoneyTransaction>.CreateEmpty();

            MoneyTransaction trans = new MoneyTransaction(-amount);
            base.RegisterTransaction(trans);

            return Option<MoneyTransaction>.Create(trans);

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation.Accounts.TransactionSelectors
{
    public class FirstTransactionSelector : ITransactionSelector
    {
        public Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions, decimal maxAmount)
        {

            return
                transactions
                    .Take(1)
                    .Where(trans => maxAmount + trans.Amount >= 0)
                    .Select(trans => Option<MoneyTransaction>.Create(trans))
                    .LazyDefaultIfEmpty(() => Option<MoneyTransaction>.CreateEmpty())
                    .Single();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    public class ConformingTransactionSelector : ITransactionSelector
    {
        public Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions, decimal maxAmount)
        {

            return
                transactions
                    .Where(trans => maxAmount + trans.Amount >= 0)
                    .Take(1)
                    .Select(trans => Option<MoneyTransaction>.Create(trans))
                    .DefaultIfEmpty(Option<MoneyTransaction>.CreateEmpty())
                    .Single();

        }
    }
}

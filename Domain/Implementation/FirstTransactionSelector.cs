using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    public class FirstTransactionSelector : ITransactionSelector
    {
        public Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions, decimal maxAmount)
        {

            if (!transactions.Any())
                return Option<MoneyTransaction>.CreateEmpty();

            MoneyTransaction candidate = transactions.First();

            if (maxAmount + candidate.Amount < 0)
                return Option<MoneyTransaction>.CreateEmpty();

            return Option<MoneyTransaction>.Create(candidate);

        }
    }
}

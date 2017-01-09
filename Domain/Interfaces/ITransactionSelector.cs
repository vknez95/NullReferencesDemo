using System.Collections.Generic;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface ITransactionSelector
    {
        Option<MoneyTransaction> TrySelectOne(IEnumerable<MoneyTransaction> transactions, decimal maxAmount);
    }
}

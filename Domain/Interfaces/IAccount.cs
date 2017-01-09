using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IAccount
    {
        MoneyTransaction Deposit(decimal amount);
        Option<MoneyTransaction> TryWithdraw(decimal amount);
        decimal Balance { get; }
    }
}

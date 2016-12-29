namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IAccount
    {
        MoneyTransaction Deposit(decimal amount);
        MoneyTransaction Withdraw(decimal amount);
        decimal Balance { get; }
    }
}

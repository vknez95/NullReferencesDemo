using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class DepositResult: ICommandResult
    {
        public string Username { get; }
        public decimal Amount { get; }
        public decimal Balance { get; }

        public DepositResult(string username, decimal amount, decimal balance)
        {
            this.Username = username ?? string.Empty;
            this.Amount = amount;
            this.Balance = balance;
        }
    }
}

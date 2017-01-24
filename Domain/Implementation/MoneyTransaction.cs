namespace NullReferencesDemo.Domain.Implementation
{
    public class MoneyTransaction
    {
        public decimal Amount { get; private set; }

        public MoneyTransaction(decimal amount)
        {
            this.Amount = amount;
        }

    }
}

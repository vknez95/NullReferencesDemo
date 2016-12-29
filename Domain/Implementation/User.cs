using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Domain.Implementation
{
    internal class User: IUser
    {
        public string Username { get; private set; }
        private readonly IAccount account;

        public User(string username, IAccount account)
        {
            this.Username = username;
            this.account = account;
        }

        public void Deposit(decimal amount)
        {
            this.account.Deposit(amount);
        }

        public decimal Balance
        {
            get
            {
                return this.account.Balance;
            }
        }

        public Receipt Purchase(IProduct product)
        {

            MoneyTransaction transaction = this.account.Withdraw(product.Price);

            if (transaction == null)
                return null;

            return new Receipt(product.Name, product.Price);

        }
    }
}

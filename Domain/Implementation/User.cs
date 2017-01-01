using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Domain.Implementation
{
    internal class User : IUser
    {
        public string Username { get; private set; }
        private readonly IAccount account;
        private readonly IPurchaseReportFactory reportFactory;

        public User(string username, IAccount account, IPurchaseReportFactory reportFactory)
        {
            this.Username = username;
            this.account = account;
            this.reportFactory = reportFactory;
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

        public IPurchaseReport Purchase(IProduct product)
        {

            MoneyTransaction transaction = this.account.Withdraw(product.Price);

            if (transaction == null)
                return this.reportFactory.CreateNotEnoughMoney(this.Username, product.Name, product.Price);

            return this.reportFactory.CreateReport(this.Username, product.Name, product.Price);

        }
    }
}

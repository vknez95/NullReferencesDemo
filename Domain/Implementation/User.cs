using System.Linq;
using NullReferencesDemo.Common;
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
            return
                this.account.TryWithdraw(product.Price)
                    .Select(trans => new Receipt(this.Username, product.Name, product.Price))
                    .LazyDefaultIfEmpty(() => this.NotEnoughMoneyReport(product.Name, product.Price))
                    .Single();
        }

        private IPurchaseReport NotEnoughMoneyReport(string productName, decimal price)
        {
            return
                this.reportFactory
                    .CreateNotEnoughMoney(this.Username, productName, price);
        }
    }
}

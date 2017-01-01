using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Implementation
{
    public class DomainServices : IDomainServices
    {

        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;
        private readonly IPurchaseReportFactory reportFactory;

        public DomainServices(IUserRepository userRepository,
                                IProductRepository productRepository,
                                IPurchaseReportFactory reportFactory)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.reportFactory = reportFactory;
        }

        public void CreateUser(string username)
        {

            IAccount userAccount = new Account();
            IUser user = new User(username, userAccount, this.reportFactory);

            this.userRepository.Add(user);

        }

        public bool IsRegistered(string username)
        {
            return
                this.userRepository
                    .Find(username)
                    .Any();
        }

        public void Deposit(string username, decimal amount)
        {
            this.userRepository
                .Find(username)
                .ForEach(user => user.Deposit(amount));
        }

        public decimal GetBalance(string username)
        {
            return
                this.userRepository
                    .Find(username)
                    .Select(user => user.Balance)
                    .DefaultIfEmpty(0)
                    .Single();
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return
                this.productRepository
                    .GetAll()
                    .Select(product => new StockItem(product.Name, product.Price));
        }

        public IPurchaseReport Purchase(string username, string itemName)
        {
            return
                this.productRepository
                    .Find(username)
                    .Select(product => Purchase(username, product))
                    .DefaultIfEmpty(this.reportFactory.CreateProductNotFound(username, itemName))
                    .Single();
        }

        public IPurchaseReport Purchase(string username, IProduct product)
        {
            return
                this.userRepository
                    .Find(username)
                    .Select(user => user.Purchase(product))
                    .DefaultIfEmpty(this.reportFactory.CreateNotRegistered(username))
                    .Single();
        }
    }
}

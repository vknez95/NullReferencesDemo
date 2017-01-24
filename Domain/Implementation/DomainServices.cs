using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Implementation;

namespace NullReferencesDemo.Domain.Implementation
{
    public class DomainServices : IDomainServices
    {

        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;
        private readonly IAccountTypeRepository accountTypeRepository;
        private readonly IPurchaseReportFactory reportFactory;
        private readonly IAccountFactory accountFactory;

        public DomainServices(IUserRepository userRepository,
                              IProductRepository productRepository,
                              IAccountTypeRepository accountTypeRepository,
                              IPurchaseReportFactory reportFactory,
                              IAccountFactory accountFactory)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.accountTypeRepository = accountTypeRepository;
            this.reportFactory = reportFactory;
            this.accountFactory = accountFactory;
        }

        public void CreateUser(string username, int accountTypeId)
        {
            IAccount account = this.accountFactory.CreateAccount(accountTypeId);

            IUser user = new User(username, account, this.reportFactory);

            this.userRepository.Add(user);

        }

        public bool IsRegistered(string username)
        {
            return
                this.userRepository
                .TryFind(username)
                .Any();
        }

        public void Deposit(string username, decimal amount)
        {
            this.userRepository
                .TryFind(username)
                .ForEach(user => user.Deposit(amount));
        }

        public decimal GetBalance(string username)
        {
            return
                this.userRepository
                .TryFind(username)
                .Select(user => user.Balance)
                .DefaultIfEmpty(0)
                .Single();
        }

        public IEnumerable<IStockItem> GetAvailableItems()
        {
            return this.productRepository.GetAll().Select(product => new StockItem(product.Name, product.Price));
        }

        public IEnumerable<IMoneyAccount> GetAvailableMoneyAccounts()
        {
            return
                this.accountTypeRepository
                    .GetAll()
                    .Select(accountType => new MoneyAccount(accountType.Id,
                                                            accountType.AccountName,
                                                            accountType.Description));
        }

        public IPurchaseReport Purchase(string username, string itemName)
        {
            return
                this.productRepository
                .TryFind(itemName)
                .Select(product => Purchase(username, product))
                .LazyDefaultIfEmpty(() => this.reportFactory.CreateProductNotFound(username, itemName))
                .Single();
        }

        private IPurchaseReport Purchase(string username, IProduct product)
        {
            return
                this.userRepository
                    .TryFind(username)
                    .Select(user => user.Purchase(product))
                    .LazyDefaultIfEmpty(() => this.reportFactory.CreateNotRegistered(username))
                    .Single();
        }

    }
}

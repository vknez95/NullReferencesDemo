using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NullReferencesDemo.Domain.Implementation
{
    public class DomainServices: IDomainServices
    {

        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;

        public DomainServices(IUserRepository userRepository, IProductRepository productRepository)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public void CreateUser(string username)
        {
            
            IAccount userAccount = new Account();
            IUser user = new User(username, userAccount);

            this.userRepository.Add(user);
        
        }

        public bool IsRegistered(string username)
        {
            IUser user = this.userRepository.Find(username);
            return user != null;
        }

        public void Deposit(string username, decimal amount)
        {
            IUser user = this.userRepository.Find(username);
            user.Deposit(amount);
        }

        public decimal GetBalance(string username)
        {
            IUser user = this.userRepository.Find(username);
            return user.Balance;
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return this.productRepository.GetAll().Select(product => new StockItem(product.Name, product.Price));
        }

        public Receipt Purchase(string username, string itemName)
        {

            IProduct product = this.productRepository.Find(itemName);

            if (product == null)
                return null;

            IUser user = this.userRepository.Find(username);

            if (user == null)
                return null;

            return user.Purchase(product);
        
        }

    }
}

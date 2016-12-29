using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;

namespace NullReferencesDemo.Application.Implementation
{
    public class ApplicationServices: IApplicationServices
    {

        private readonly IDomainServices domainServices;
        private string loggedInUsername;

        public ApplicationServices(IDomainServices domainServices)
        {
            this.domainServices = domainServices;
            this.loggedInUsername = string.Empty;
        }

        public void RegisterUser(string username)
        {
            this.domainServices.CreateUser(username);
        }

        public bool Login(string username)
        {
            
            bool loggedIn = this.domainServices.IsRegistered(username);

            if (loggedIn)
                this.loggedInUsername = username;

            return loggedIn;

        }

        public bool IsUserLoggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(this.loggedInUsername);
            }
        }

        public string LoggedInUsername
        {
            get
            {
                this.AssertUserLoggedIn();
                return this.loggedInUsername;
            }
        }

        public void Logout()
        {
            this.loggedInUsername = string.Empty;
        }

        public void Deposit(decimal amount)
        {
            this.AssertUserLoggedIn();
            this.domainServices.Deposit(this.loggedInUsername, amount);
        }

        public decimal LoggedInUserBalance
        {
            get
            {
                this.AssertUserLoggedIn();
                return this.domainServices.GetBalance(this.loggedInUsername);
            }
        }

        private void AssertUserLoggedIn()
        {
            if (!this.IsUserLoggedIn)
                throw new InvalidOperationException("No user logged in.");
        }

        public IEnumerable<StockItem> GetAvailableItems()
        {
            return this.domainServices.GetAvailableItems();
        }

        public Receipt Purchase(string itemName)
        {

            if (!this.IsUserLoggedIn)
                return null;
            
            return this.domainServices.Purchase(this.loggedInUsername, itemName);
        
        }
    }
}

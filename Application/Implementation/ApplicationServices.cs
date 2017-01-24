using NullReferencesDemo.Application.Interfaces;
using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Application.Implementation
{
    public class ApplicationServices : IApplicationServices
    {

        private readonly IDomainServices domainServices;
        private readonly IPurchaseReportFactory reportFactory;
        private string loggedInUsername;
        private string registrationUsername;
        private IMoneyAccount userAccount;

        public ApplicationServices(IDomainServices domainServices, IPurchaseReportFactory reportFactory)
        {
            this.domainServices = domainServices;
            this.loggedInUsername = string.Empty;
            this.reportFactory = reportFactory;
        }

        public void SetRegistrationUsername(string username)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(username), "Username cannot be empty.", nameof(username));

            this.registrationUsername = username;
        }

        public void SetUserAccount(IMoneyAccount account)
        {
            Contract.Requires<ArgumentException>(account != null, "User account cannot be null.", nameof(account));

            this.userAccount = account;
        }

        public bool RegisterUser(string username, int accountTypeId)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(username), "Username cannot be empty.", nameof(username));

            bool userRegistered = this.IsUserRegistered(username);

            if (!userRegistered)
                this.domainServices.CreateUser(username, accountTypeId);

            ClearRegistrationData();

            return !userRegistered;

        }

        public bool Login(string username)
        {

            bool loggedIn = this.IsUserRegistered(username);

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

        public bool IsUserChoosingAccount
        {
            get
            {
                return !string.IsNullOrEmpty(this.registrationUsername) && this.userAccount == null;
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

        public string RegistrationUsername
        {
            get
            {
                return this.registrationUsername;
            }
        }

        public IMoneyAccount UserAccount
        {
            get
            {
                return this.userAccount;
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

        public bool IsUserRegistered(string username)
        {
            return this.domainServices.IsRegistered(username);
        }

        public IEnumerable<IStockItem> GetAvailableItems()
        {
            return this.domainServices.GetAvailableItems();
        }

        public IPurchaseReport Purchase(string itemName)
        {

            if (!this.IsUserLoggedIn)
                return this.reportFactory.CreateNotSignedIn();

            return this.domainServices.Purchase(this.loggedInUsername, itemName);

        }

        private void AssertUserLoggedIn()
        {
            if (!this.IsUserLoggedIn)
                throw new InvalidOperationException("No user logged in.");
        }

        private void ClearRegistrationData()
        {
            this.registrationUsername = null;
            this.userAccount = null;
        }
    }
}

using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation.Accounts
{
    public class AccountType : IAccountType
    {
        private readonly int id;
        private readonly string accountName;
        private readonly string description;

        public AccountType(int accountId, string accountName, string description)
        {
            this.id = accountId;
            this.accountName = accountName;
            this.description = description;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string AccountName
        {
            get
            {
                return this.accountName;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }
    }
}

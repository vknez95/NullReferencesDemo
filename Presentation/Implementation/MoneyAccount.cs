using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class MoneyAccount : IMoneyAccount
    {
        public int AccountTypeId { get; private set; }
        public string AccountName { get; private set; }
        public string Description { get; private set; }

        public MoneyAccount(int accountTypeId, string accountName, string description)
        {
            this.AccountTypeId = accountTypeId;
            this.AccountName = accountName;
            this.Description = description;
        }
    }
}

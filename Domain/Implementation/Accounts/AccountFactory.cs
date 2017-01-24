using NullReferencesDemo.Domain.Implementation.Accounts.TransactionSelectors;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Domain.Implementation.Accounts
{
    public class AccountFactory : IAccountFactory
    {
        public IAccount CreateAccount(int accountTypeId)
        {
            if (accountTypeId == 1)
                return new DebitAccount();
            else if (accountTypeId == 2)
                return new CreditAccount(new ConformingTransactionSelector());
            else
                return new CreditAccount(new FirstTransactionSelector());
        }
    }
}

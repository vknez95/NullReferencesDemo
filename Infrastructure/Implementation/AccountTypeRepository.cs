using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Implementation.Accounts;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private IList<IAccountType> accountTypes = new List<IAccountType>();

        public AccountTypeRepository()
        {
            accountTypes.Add(new AccountType(1, "Debit Account", "0 dollars overdraft limit."));
            accountTypes.Add(new AccountType(2, "Debit Account", "100 dollars overdarft limit."));
            accountTypes.Add(new AccountType(3, "Credit Account", "Conforming transaction selector."));
            accountTypes.Add(new AccountType(4, "Credit Account", "First transaction selector."));
        }

        public IEnumerable<IAccountType> GetAll()
        {
            return accountTypes;
        }

        public Option<IAccountType> TryFind(int accountTypeId)
        {
            return
                this.accountTypes
                    .Where(accountType => accountType.Id == accountTypeId)
                    .Select(accountType => Option<IAccountType>.Create(accountType))
                    .LazyDefaultIfEmpty(() => Option<IAccountType>.CreateEmpty())
                    .Single();
        }
    }
}

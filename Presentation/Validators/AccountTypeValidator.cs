using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Validators
{
    public class AccountTypeValidator : IAccountTypeValidator
    {
        private readonly IEnumerable<IMoneyAccount> moneyAccounts;

        public AccountTypeValidator(IEnumerable<IMoneyAccount> moneyAccounts)
        {
            this.moneyAccounts = moneyAccounts;
        }

        public bool IsValid(char accountTypeId)
        {
            int accountTypeIdInt;

            if (!int.TryParse(accountTypeId.ToString(), out accountTypeIdInt))
                return false;

            return
                this.moneyAccounts
                    .Where(account => account.AccountTypeId == accountTypeIdInt)
                    .Any();
        }
    }
}

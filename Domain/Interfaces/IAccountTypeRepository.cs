using NullReferencesDemo.Common;
using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IAccountTypeRepository
    {
        IEnumerable<IAccountType> GetAll();
        Option<IAccountType> TryFind(int accountTypeId);
    }
}

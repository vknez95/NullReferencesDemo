using NullReferencesDemo.Common;
using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        Option<IProduct> TryFind(string name);
    }
}

using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        IEnumerable<IProduct> Find(string name);
    }
}

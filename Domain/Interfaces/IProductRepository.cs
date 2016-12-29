using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        IProduct Find(string name);
    }
}

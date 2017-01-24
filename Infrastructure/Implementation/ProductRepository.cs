using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Domain.Implementation;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {

        private IList<IProduct> products = new List<IProduct>();

        public ProductRepository()
        {
            products.Add(new ProductData("book", 27.46M));
            products.Add(new ProductData("pen", 6.28M));
            products.Add(new ProductData("ruler", 2.86M));
        }

        public IEnumerable<IProduct> GetAll()
        {
            return this.products;
        }

        public Option<IProduct> TryFind(string name)
        {
            return
                this.products
                    .Where(product => product.Name == name)
                    .Select(product => Option<IProduct>.Create(product))
                    .LazyDefaultIfEmpty(() => Option<IProduct>.CreateEmpty())
                    .Single();
        }
    }
}

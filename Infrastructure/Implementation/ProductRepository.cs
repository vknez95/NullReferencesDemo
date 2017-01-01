using NullReferencesDemo.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {

        private IDictionary<string, decimal> nameToPrice;

        public ProductRepository()
        {

            this.nameToPrice = new Dictionary<string, decimal>();

            this.nameToPrice.Add("book", 27.46M);
            this.nameToPrice.Add("pen", 6.28M);
            this.nameToPrice.Add("ruler", 2.86M);

        }

        public IEnumerable<IProduct> GetAll()
        {
            return this.nameToPrice.Select(pair => new ProductData(pair.Key, pair.Value));
        }

        public IEnumerable<IProduct> Find(string name)
        {
            decimal price;
            if (this.nameToPrice.TryGetValue(name, out price))
                return new[] { new ProductData(name, price) };

            return new IProduct[0];
        }
    }
}

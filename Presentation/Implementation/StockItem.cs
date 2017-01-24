using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class StockItem : IStockItem
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public StockItem(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}

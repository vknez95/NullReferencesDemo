namespace NullReferencesDemo.Presentation.Interfaces
{
    public class Receipt
    {
        public string ItemName { get; private set; }
        public decimal Price { get; private set; }

        public Receipt(string itemName, decimal price)
        {
            this.ItemName = itemName;
            this.Price = price;
        }
    }
}

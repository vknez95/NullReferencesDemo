using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class Receipt: IPurchaseReport
    {
        public string Username { get; }
        public string ProductName { get; }
        public decimal Price { get; }

        public Receipt(string username, string productName, decimal price)
        {
            this.Username = username;
            this.ProductName = productName;
            this.Price = price;
        }
    }
}

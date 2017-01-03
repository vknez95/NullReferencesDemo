using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class NotEnoughMoney: IPurchaseReport
    {

        public string Username { get; }
        public decimal Price { get; }
        public string ProductName { get; }

        public NotEnoughMoney(string username, string productName, decimal price)
        {
            this.Username = username;
            this.Price = price;
            this.ProductName = productName;
        }
    }
}

using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class ProductNotFound: IPurchaseReport
    {

        public string Username { get; }
        public string ProductName { get; }

        public ProductNotFound(string username, string productName)
        {
            this.Username = username;
            this.ProductName = productName;
        }
    }
}

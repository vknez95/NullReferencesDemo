namespace NullReferencesDemo.Presentation.Interfaces
{
    public interface IPurchaseReportFactory
    {
        IPurchaseReport CreateFailedPurchase();
        IPurchaseReport CreateNotSignedIn();
        IPurchaseReport CreateNotRegistered(string username);
        IPurchaseReport CreateProductNotFound(string username, string productName);
        IPurchaseReport CreateNotEnoughMoney(string username, string productName, decimal price);
        IPurchaseReport CreateReport(string username, string productName, decimal price);
    }
}

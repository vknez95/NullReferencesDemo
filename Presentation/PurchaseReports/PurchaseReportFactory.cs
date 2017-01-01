using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    public class PurchaseReportFactory : IPurchaseReportFactory
    {
        public IPurchaseReport CreateFailedPurchase()
        {
            return FailedPurchase.Instance;
        }

        public IPurchaseReport CreateNotEnoughMoney(string username, string productName, decimal price)
        {
            return new NotEnoughMoney(username, productName, price);
        }

        public IPurchaseReport CreateNotRegistered(string username)
        {
            return new NotRegistered(username);
        }

        public IPurchaseReport CreateNotSignedIn()
        {
            return new NotSignedIn();
        }

        public IPurchaseReport CreateProductNotFound(string username, string productName)
        {
            return new ProductNotFound(username, productName);
        }

        public IPurchaseReport CreateReport(string username, string productName, decimal price)
        {
            return new Receipt(username, productName, price);
        }
    }
}

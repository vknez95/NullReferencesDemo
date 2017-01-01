using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class Receipt : IPurchaseReport
    {
        private readonly string username;
        private readonly decimal price;
        private readonly string productName;

        public Receipt(string username, string productName, decimal price)
        {
            this.username = username;
            this.price = price;
            this.productName = productName;
        }

        public string ToUiText()
        {
            return string.Format("Dear {0},\nThank you for buying {1} for {2}.", this.username, this.productName, this.price);
        }
    }
}

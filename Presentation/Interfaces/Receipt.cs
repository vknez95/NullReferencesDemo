using System;

namespace NullReferencesDemo.Presentation.Interfaces
{
    public class Receipt : IPurchaseReport
    {
        public string ItemName { get; private set; }
        public decimal Price { get; private set; }

        public Receipt(string itemName, decimal price)
        {
            this.ItemName = itemName;
            this.Price = price;
        }

        public string ToUiText()
        {
            return string.Format("Thank you for buying {0} for {1:C}", this.ItemName, this.Price);
        }
    }
}

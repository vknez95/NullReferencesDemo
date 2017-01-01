using NullReferencesDemo.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullReferencesDemo.Presentation.PurchaseReports
{
    internal class NotEnoughMoney : IPurchaseReport
    {
        private readonly string username;
        private readonly decimal price;
        private readonly string productName;

        public NotEnoughMoney(string username, string productName, decimal price)
        {
            this.username = username;
            this.price = price;
            this.productName = productName;
        }

        public string ToUiText()
        {
            return string.Format("Dear {0},\nYou do not have {1:C} to pay for the {2}.", this.username, this.price, this.productName);
        }
    }
}

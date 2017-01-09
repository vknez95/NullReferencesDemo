using System;
using NullReferencesDemo.Common;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class NotEnoughMoneyView: IView
    {

        private NotEnoughMoney Data { get; }

        public NotEnoughMoneyView(NotEnoughMoney data)
        {
            Contract.Requires<ArgumentNullException>(data != null, nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Dear {0},\nYou do not have {1:C} to pay for the {2}.",
                              this.Data.Username, this.Data.Price, this.Data.ProductName);
        }
    }
}

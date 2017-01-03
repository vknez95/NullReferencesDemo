using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class ReceiptView: IView
    {

        private Receipt Data { get; }

        public ReceiptView(Receipt data)
        {
            
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Dear {0},\nThank you for buying {1} for {2:C}.",
                              this.Data.Username, this.Data.ProductName,
                              this.Data.Price);
        }
    }
}

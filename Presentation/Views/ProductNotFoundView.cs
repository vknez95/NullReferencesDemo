using System;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.PurchaseReports;

namespace NullReferencesDemo.Presentation.Views
{
    public class ProductNotFoundView: IView
    {
        private ProductNotFound Data { get; }

        public ProductNotFoundView(ProductNotFound data)
        {

            if (data == null)
                throw new ArgumentNullException(nameof(data));

            this.Data = data;

        }

        public void Render()
        {
            Console.WriteLine("Dear {0},\nSorry to inform you that we have no {1} left.",
                              this.Data.Username, this.Data.ProductName);
        }
    }
}

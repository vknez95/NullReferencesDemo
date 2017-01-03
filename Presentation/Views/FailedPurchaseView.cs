using System;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Views
{
    public class FailedPurchaseView: IView
    {
        public void Render()
        {
            Console.WriteLine("Purchase failed.");
        }
    }
}

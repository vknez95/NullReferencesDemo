using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class PurchaseCommand : ICommand
    {

        private readonly IApplicationServices appServices;

        public PurchaseCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public void Execute()
        {

            this.ShowStock();

            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            IPurchaseReport report = this.appServices.Purchase(itemName);

            DisplayReport(report);

        }

        private void ShowStock()
        {
            Console.WriteLine("Available items:");
            foreach (StockItem item in this.appServices.GetAvailableItems())
                Console.WriteLine("{0,10} {1:C}", item.Name, item.Price);
            Console.WriteLine();
            Console.WriteLine();
        }

        private void DisplayReport(IPurchaseReport report)
        {
            Console.WriteLine(report.ToUiText());
        }
    }
}

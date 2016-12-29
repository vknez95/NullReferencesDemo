using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class PurchaseCommand: ICommand
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

            Receipt receipt = this.appServices.Purchase(itemName);

            if (receipt == null)
                Console.WriteLine("Purchase failed.");
            else
                DisplayReceipt(receipt);

        }

        private void ShowStock()
        {
            Console.WriteLine("Available items:");
            foreach (StockItem item in this.appServices.GetAvailableItems())
                Console.WriteLine("{0,10} {1:C}", item.Name, item.Price);
            Console.WriteLine();
            Console.WriteLine();
        }

        private void DisplayReceipt(Receipt receipt)
        {
            Console.WriteLine("Thank you for buying {0} for {1:C}.", receipt.ItemName, receipt.Price);
        }
    }
}

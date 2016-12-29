using NullReferencesDemo.Presentation.Interfaces;
using System;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    public class DepositCommand: ICommand
    {

        private readonly IApplicationServices appServices;

        public DepositCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public void Execute()
        {

            Console.Write("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            this.appServices.Deposit(amount);

        }
    }
}

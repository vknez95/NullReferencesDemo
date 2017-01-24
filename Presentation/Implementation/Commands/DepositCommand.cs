using NullReferencesDemo.Presentation.Interfaces;
using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    public class DepositCommand : ICommand
    {

        private readonly IApplicationServices appServices;
        private readonly IDepositValidator validator;

        public DepositCommand(IApplicationServices appServices, IDepositValidator validator)
        {
            this.appServices = appServices;
            this.validator = validator;
        }

        public ICommandResult Execute()
        {

            Console.Write("Enter amount to deposit: ");
            string amount = Console.ReadLine();

            if (!validator.IsValid(amount))
                return new InvalidDeposit();

            decimal decAmount = decimal.Parse(amount);
            this.appServices.Deposit(decAmount);

            return new DepositResult(this.appServices.LoggedInUsername,
                                     decAmount,
                                     this.appServices.LoggedInUserBalance);

        }
    }
}

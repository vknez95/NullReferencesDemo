using System;
using System.Collections.Generic;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;
using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class RegisterCommand : ICommand
    {

        private readonly IApplicationServices appServices;
        private readonly IRegisterValidator validator;
        private readonly IEnumerable<MenuItem> menu;

        public RegisterCommand(IApplicationServices appServices, IEnumerable<MenuItem> menu, IRegisterValidator validator)
        {
            this.appServices = appServices;
            this.validator = validator;
            this.menu = menu;
        }

        public ICommandResult Execute()
        {

            Console.Write("Enter username to register: ");
            string username = Console.ReadLine();

            if (!validator.IsValid(username))
                return new InvalidUsername(username, validator.MinLength);

            if (this.appServices.IsUserRegistered(username))
                return new UserAlreadyRegistered(username);

            ShowMenu();

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (!validator.IsValid(key.KeyChar))
                return new InvalidAccountType(key.KeyChar);

            int accountTypeId = int.Parse(key.KeyChar.ToString());

            if (this.appServices.RegisterUser(username, accountTypeId))
                return new UserRegistered(username);

            return new RegisterFailed(username);
        }

        private void ShowMenu()
        {

            Console.WriteLine();
            Console.WriteLine("Next choose money account: ");
            Console.WriteLine();

            foreach (MenuItem menuItem in this.menu)
                menuItem.Display();

            Console.WriteLine();

        }
    }
}
